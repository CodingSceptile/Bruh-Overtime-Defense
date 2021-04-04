using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Bruh_Overtime_Defense
{
    class DootSkeleton : Tower
    {
        public DootSkeleton(Rectangle pos, Texture2D spr, int radius, int initialCost, int activitySpeed)
            :base(pos, spr, radius, initialCost, activitySpeed)
        {

        }

        public override bool Shoot(List<Enemy> enemies)
        {
            return base.Shoot(enemies);
        }
    }
}
