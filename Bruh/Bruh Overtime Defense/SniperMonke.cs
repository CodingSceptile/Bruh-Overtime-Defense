using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
//HEADER=======================================
//Author: Mukund Suresh
//Purpose: To create a tower class that shoots bruhs from all ranges.
//=============================================
namespace Bruh_Overtime_Defense
{
    class SniperMonke : Tower
    {
        public SniperMonke(Rectangle pos, Texture2D spr, int radius, int initialCost, int activitySpeed, GameTime gameTime)
            : base(pos, spr, radius, initialCost, activitySpeed, gameTime)
        {
            radius = int.MaxValue;
            activitySpeed = 3; //arbitrary, can balance later
        }

    }
}
