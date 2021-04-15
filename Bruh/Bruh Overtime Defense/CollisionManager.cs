using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Bruh_Overtime_Defense
{
    //Names: Sami Chamberlain, Mukund Suresh, Caleb Jeon,
    //London Emmerich
    //Date: 3/28/2021
    //Purpose: Establishes level collisions,
    //and interacts with stored Vector2's to
    //change the player's movement
    //Also, checks for collisions between
    //towers and enemies

    class CollisionManager
    {
        //Fields
        private string levelName;
        private Level level;
        private List<Vector2> vectors;
        private List<Rectangle> rectangles;
        private List<string> codes;
        private List<float> rotations;
        private List<Rectangle> trackLocs;

        //Properties

        /// <summary>
        /// Returns the current level data
        /// </summary>
        public Level CurrentLevel 
        {
            get { return level; }
            set { level = value; }
        }

        /// <summary>
        /// Returns the list of texture codes
        /// used by the level
        /// </summary>
        public List<string> Codes
        {
            get { return codes; }
        }

        /// <summary>
        /// Returns the rotation values of each
        /// tile
        /// </summary>
        public List<float> Rotations
        {
            get { return rotations; }
        }


        /// <summary>
        /// Returns the starting position of a
        /// bruh
        /// </summary>
        public Rectangle StartPosition
        {
            get { return rectangles[0]; }
        }


        //Constructor

        /// <summary>
        /// Creates a new instance of a collision manager
        /// </summary>
        public CollisionManager(string levelName)
        {
            this.levelName = levelName;

            this.level = new Level(levelName);
            
            this.codes = level.GenerateMap();
            this.rotations = level.Rotations;
            this.vectors = level.Vectors;
            this.rectangles = level.Locations;         
        }

        //Methods

        /// <summary>
        /// Returns whether or not 
        /// something is intersecting
        /// with the level elements
        /// </summary>
        /// <returns>true - intersecting/ false - not intersecting</returns>
        public void LevelIntersects(Enemy enemy)
        {
            for(int i = 1; i < rectangles.Count; i++)
            {
              //Checks for intersection
                if (enemy.Position.Intersects(rectangles[i]))
                {
                    enemy.Movement = level.Vectors[i - 1] * enemy.Speed;
                }
            }
        }
    }
}
