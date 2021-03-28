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
        public bool LevelIntersects(GameObject gameObj)
        {
            for(int i = 1; i < rectangles.Count; i++)
            {
                if (gameObj.Position.Intersects(rectangles[i]))
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Changes the direction of an object
        /// if it collides with an invisible level
        /// object
        /// </summary>
        /// <param name="gameObj">The object being traced</param>
        public void ChangeEnemyDirection(Enemy enemy)
        {
            if(LevelIntersects(enemy) == true)
            {
                int whichVector = enemy.VectorInteractions;
                enemy.VectorInteractions++;
               
                if(enemy.Movement.X == 0)
                {
                    enemy.Movement = new Vector2(enemy.Speed, 0);
                }
                else if(enemy.Movement.Y == 0)
                {
                    enemy.Movement = new Vector2(0, enemy.Speed);                   
                }

                enemy.Movement *= vectors[whichVector];
            }
        }
    }
}
