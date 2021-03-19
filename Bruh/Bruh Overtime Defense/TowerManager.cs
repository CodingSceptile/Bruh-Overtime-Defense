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

        //Methods
        /// <summary>
        /// Subtracts salary leftover after every round that it's called and
        /// checks if salary is due yet.
        /// </summary>
        /// <param name="t">The tower it is being checked for.</param>
        /// <returns>True if salary is due, false if not.</returns>
        public bool SalaryDue(Tower t)
        {
            //I could make it subtract raw, but in this model, all towers 
            //have to be paid at equal times. Could make it so that the expensive
            //ones could be paid less often but we'll see
            t.Salary -= (int)(t.Salary / 5); //5 is arbitrary

            if (t.Salary <= 0)
            {
                t.Salary = 0; //doesn't really matter but don't want it to be -ve
                return true;
            }

            else return false;
        }

        /// <summary>
        /// This method tops off the salary of the tower.
        /// </summary>
        /// <param name="t">The lucky tower that's getting paid.</param>
        public void SalaryPaid(Tower t)
        {
            t.Salary = t.OriginalSalary;
        }
    }
}
