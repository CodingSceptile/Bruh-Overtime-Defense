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


        public TowerManager(List<Tower> towers)
        {
            this.towers = towers;
        }

        //Methods
        /// <summary>
        /// This method tops off the salary of the tower.
        /// </summary>
        /// <param name="t">The lucky tower that's getting paid.</param>
        public void SalaryPaid(Tower t)
        {
            t.Salary = t.OriginalSalary;
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
                    newEnemy.IsDead = true;
                    enemies.Add(newEnemy);
                }
            }
        }

        /// <summary>
        /// Shoot method to pop bruhs
        /// </summary>
        /// <param name="t">The tower that is trying to pop</param>
        /// <param name="enemies">The enemies on the map.</param>
        public bool Shoot(Tower t, List<Enemy> enemies)
        {
            foreach (Enemy e in enemies)
            {
                if (Distance(t.Position, e.Position) <= t.Radius)
                {
                    if(e.IsDead == true)
                    {
                        continue;
                    }

                    e.Health -= 1;
                    if(e.Health == 0)
                    {
                        e.IsDead = true;
                        return true;
                    }                   
                }
            }
            return false;
        }

        /// <summary>
        /// Draws the towers on the map.
        /// </summary>
        /// <param name="sb">SpriteBatch</param>
        public void DrawTowers(SpriteBatch sb)
        {
            for(int i = 0; i < towers.Count; i++)
            {
                towers[i].Draw(sb);
            }
        }

        /// <summary>
        /// Places the tower.
        /// </summary>
        /// <param name="t">The tower to be placed</param>
        public void PlaceTower(Tower t)
        {
            
        }

        /// <summary>
        /// Finds the distance between two rectangle positions
        /// </summary>
        /// <param name="p1">First point</param>
        /// <param name="p2">Second point</param>
        /// <returns>Distance between first point and second point</returns>
        public float Distance(Rectangle p1, Rectangle p2)
        {
            float distance = (float)Math.Sqrt(Math.Pow(p1.X - p2.X, 2) + Math.Pow(p1.Y - p2.Y, 2));
            return distance;
        }
    }
}
