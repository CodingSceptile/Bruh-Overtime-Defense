using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Bruh_Overtime_Defense
{
    class RyanTheGateKeeper : Tower
    {
        public RyanTheGateKeeper(Rectangle pos, Texture2D spr, int radius, int initialCost, int activitySpeed)
            : base(pos, spr, radius, initialCost, activitySpeed)
        {

        }

        /// <summary>
        /// Just want to make sure that you can't call this method from
        /// this class with any results. However, can still use this method
        /// to halt things without the need to call an extra method
        /// </summary>
        /// <param name="enemies"></param>
        /// <returns>False. It doesn't shoot anything.</returns>
        public override bool Shoot(List<Enemy> enemies)
        {
            WaitingRoom(enemies);
            return false;
        }

        /// <summary>
        /// Puts all enemies within range in a waiting room,
        /// (i.e completely halts them) for a certain amount of time
        /// </summary>
        /// <param name="enemies"></param>
        private void WaitingRoom(List<Enemy> enemies)
        {
                if(WaitingRoomSwitch())
                {
                    for(int i = 0; i < enemies.Count; i++)
                    {
                         float originalSpeed = enemies[i].Speed;
                         if (Distance(enemies[i].Position, Position) <= radius)
                         {
                               enemies[i].Speed = 0;
                         }

                         else
                         {
                               enemies[i].Speed = originalSpeed;
                         }
                    }
                     
                }
        }

        /// <summary>
        /// Decides if the waiting room is turned off or on.
        /// </summary>
        /// <returns>True or false depending on the time passed.</returns>
        private bool WaitingRoomSwitch()
        {
            double time = (gameTime.TotalGameTime.TotalSeconds % 10);

            if ((time > 0) && time < 2 ||
               (time > 4 && time < 6) ||
               (time > 8 && time < 9))
            {
                return true;
            }

            else return false;

        }
    }
}
