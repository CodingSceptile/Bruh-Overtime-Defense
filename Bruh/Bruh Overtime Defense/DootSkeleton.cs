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
        /// <summary>
        /// Constructor for doot skeleton. Is what 
        /// tower was in Milestone 2.
        /// </summary>
        /// <param name="pos">Position of the doot skeleton</param>
        /// <param name="spr">Doot skeleton sprite</param>
        /// <param name="radius">Radius of doot skeleton</param>
        /// <param name="initialCost">Initial cost to purchase doot skeleton</param>
        /// <param name="activitySpeed">Rate of fire of doot skeleton</param>
        public DootSkeleton(Rectangle pos, Texture2D spr, int radius, int initialCost, int activitySpeed)
            :base(pos, spr, radius, initialCost, activitySpeed)
        {

        }
    }
}
