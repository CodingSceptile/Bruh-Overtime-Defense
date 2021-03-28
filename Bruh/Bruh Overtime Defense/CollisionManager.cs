using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Bruh_Overtime_Defense
{
    class CollisionManager
    {
        //Fields
        private Level level;
        private List<Vector2> vectors;
        private List<Rectangle> rectangles;


        //Properties
        public Level CurrentLevel 
        {
            get { return level; }        
        }



        //Constructor

        /// <summary>
        /// Creates a new instance of a collision manager
        /// </summary>
        public CollisionManager()
        {
            level = new Level("gameLevel.level_Appended");
            vectors = level.Vectors;
            rectangles = level.Locations;
        }

        //Methods

        /// <summary>
        /// returns the starting position of the enemy
        /// </summary>
        /// <returns>starting position of the enemy</returns>
        public Rectangle EnemyStartPoint()
        {
            return rectangles[0];
        }

        /// <summary>
        /// Returns whether or not 
        /// something is intersecting
        /// with the level elements
        /// </summary>
        /// <returns>true - intersecting/ false - not intersecting</returns>
        public bool LevelIntersects()
        {
            return true;
        }



    }
}
