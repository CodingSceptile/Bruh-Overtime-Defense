using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Bruh_Overtime_Defense
{
    class Not_Erin : Tower
    {
        public Not_Erin(Rectangle pos, Texture2D spr, int radius, int initialCost, int activitySpeed)
            : base(pos, spr, radius, initialCost, activitySpeed)
        {

        }

        /// <summary>
        /// Override of Shoot() that calls Vaporize()
        /// </summary>
        /// <param name="enemies">List of enemies in the map</param>
        /// <returns>Money returned by killing the enemy</returns>
        public override int Shoot(List<Enemy> enemies)
        {
           return Vaporize(enemies);
        }

        /// <summary>
        /// Instantly removes the enemies within radius of the tower.
        /// </summary>
        /// <param name="enemies">List of enemies in the map.</param>
        /// <returns>Money returned by killing the enemy</returns>
        private int Vaporize(List<Enemy> enemies)
        {
            //maybe it should be an int and return money?
            //how will I go about returning the money?
            //Store in new enemy class, run through isDead and
            //shoot
            moneyYield.Clear();

            for(int i = 0; i < enemies.Count; i++)
            {
                if (gameTime.TotalGameTime.TotalSeconds % activitySpeed == 0)
                {
                    if (Distance(Position, enemies[i].Position) <= radius)
                    {
                        enemies[i].Health = 0;
                        enemies[i].IsDead = true;
                        moneyYield.Add(enemies[i]);
                    }
                }  
            }

            return moneyYield.Count;
        }
    }
}
