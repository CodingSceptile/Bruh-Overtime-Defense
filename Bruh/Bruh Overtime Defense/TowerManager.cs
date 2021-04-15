using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
//HEADER================================================
//Author: Mukund Suresh
//Purpose: To create a Tower manager class that keeps track off
//and executes all the tower interactions.
//======================================================
namespace Bruh_Overtime_Defense
{
    class TowerManager
    {
        //Fields
        private List<Tower> towers;
        private List<Rectangle> trackLocs;

        /// <summary>
        /// Constructor that initializes the tower manager
        /// </summary>
        /// <param name="towers">List of towers</param>
        public TowerManager(List<Tower> towers, List<Rectangle> trackLocs)
        {
            this.towers = towers;
            this.trackLocs = trackLocs;
        }

        //Methods
        /// <summary>
        /// This method tops off the salary of the tower.
        /// </summary>
        /// <param name="t">The lucky tower that's getting paid.</param>
        public void SalaryPaid(Tower t)
        {
            t.Salary += t.OriginalSalary;
        }

        /// <summary>
        /// The towers that resign are removed.
        /// </summary>
        /// <returns>True if it's resigning, false if not.</returns>
        public void Resignations(List<Tower> towers, List<Enemy> enemies,
            Texture2D enemyTexture, Rectangle startPos)
        {
            for(int i = 0; i < towers.Count; i++)
            {
                if(towers[i].Resignation())
                {
                    towers.Remove(towers[i]);
                    Enemy newEnemy = new Enemy(enemyTexture, 1, 3, startPos);
                    enemies.Add(newEnemy);
                }
            }
        }

        /// <summary>
        /// Shoot method to pop bruhs
        /// </summary>
        /// <param name="t">The tower that is trying to pop</param>
        /// <param name="enemies">The enemies on the map.</param>
        public int Shoot(Tower t, List<Enemy> enemies)
        {
            return t.Shoot(enemies);
        }

        /// <summary>
        /// Draws the towers on the map (unless it intersects on the path)
        /// </summary>
        /// <param name="sb">SpriteBatch</param>
        public void DrawTowers(SpriteBatch sb)
        {
            for(int i = 0; i < towers.Count; i++)
            {
                foreach(Rectangle r in trackLocs)
                {
                    if(!r.Intersects(towers[i].Position))
                    {
                        towers[i].Draw(sb);
                    }

                    else
                    {
                        System.Diagnostics.Debug.WriteLine("Don't place here!");
                    }
                }
            }
        }
    }
}
