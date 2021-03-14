using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

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
    }
}
