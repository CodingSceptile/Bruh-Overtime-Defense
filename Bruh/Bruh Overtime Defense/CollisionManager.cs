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
        private List<string> codes;


        //Properties
        public Level CurrentLevel 
        {
            get { return level; }        
        }
        public List<string> Codes
        {
            get { return codes; }
        }
        public Rectangle StartPosition
        {
            get { return rectangles[0]; }
        }
        //Constructor

        /// <summary>
        /// Creates a new instance of a collision manager
        /// </summary>
        public CollisionManager()
        {
            this.level = new Level("gameLevel.level_Appended");
            codes = level.GenerateMap();
            vectors = level.Vectors;
            rectangles = level.Locations;         
        }

        //Methods

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
