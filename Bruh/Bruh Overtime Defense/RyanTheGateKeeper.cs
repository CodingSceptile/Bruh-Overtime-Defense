using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
//HEADER=======================================
//Author: Mukund Suresh
//Purpose: To create a tower class that holds all the bruhs in a waiting room
//for set intervals.
//=============================================
namespace Bruh_Overtime_Defense
{
    class RyanTheGateKeeper : Tower
    {
        public RyanTheGateKeeper(Rectangle pos, Texture2D spr, int radius, int initialCost, int activitySpeed, GameTime gameTime,
            Texture2D radiusSpr)
            : base(pos, spr, radius, initialCost, activitySpeed, gameTime, radiusSpr)
        {

        }

        /// <summary>
        /// Just want to make sure that you can't call this method from
        /// this class with any results. However, can still use this method
        /// to halt things without the need to call an extra method
        /// </summary>
        /// <param name="enemies"></param>
        /// <returns>False. It doesn't shoot anything.</returns>
        public override int Shoot(List<Enemy> enemies)
        {
            WaitingRoom(enemies);
            return 0;
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

                    if (Distance(enemies[i].Position, Position) <= radius)
                     {
                        //apply texture here
                        enemies[i].Movement *= 0;
                     }

                     else
                     {
                        //change textures back
                        //attendance check, one goes in at a time
                        enemies[i].Movement = enemies[i].OriginalMovement;
                    }
                }
                 
            }

            else
            {
                for(int i = 0; i < enemies.Count; i++)
                {
                    enemies[i].Movement = enemies[i].OriginalMovement;
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

            //if time between 1-3, 5-7, 9-10 then tower activates.
            if ((time > 1 && time < 3) ||
                (time > 5 && time < 7) ||
                (time >9))
            {
                System.Diagnostics.Debug.WriteLine(time);
                return true;
            }

            else return false;

        }
    }
}
