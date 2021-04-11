using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Bruh_Overtime_Defense
{
    class BuffDoge : Tower
    {
        public BuffDoge(Rectangle pos, Texture2D spr, int radius, int initialCost, int activitySpeed)
           : base(pos, spr, radius, initialCost, activitySpeed)
        {

        }

        public override int Shoot(List<Enemy> enemies)
        {
            return Smash(enemies);
        }

        private int Smash(List<Enemy> enemies)
        {
            //maybe it should be an int and return money?
            //how will I go about returning the money?
            //Store in new enemy class, run through isDead and
            //shoot
            moneyYield.Clear();

            if (gameTime.TotalGameTime.TotalSeconds % activitySpeed == 0)
            {
                for (int i = 0; i < enemies.Count; i++)
                {
                    if (Distance(Position, enemies[i].Position) <= radius)
                    {
                        enemies[i].Health--;

                        if(enemies[i].Health == 0)
                        {
                            enemies[i].IsDead = true;
                            moneyYield.Add(enemies[i]);
                        } 
                    }
                }
            }
            
            return moneyYield.Count;
        }
    }
}
