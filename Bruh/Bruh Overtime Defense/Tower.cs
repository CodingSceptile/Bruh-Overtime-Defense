using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Bruh_Overtime_Defense
{
    abstract class Tower : GameObject
    {
        //Fields
        private int radius;
        private int initialCost;
        private float originalSalary; 
        private float salary;
        private int activitySpeed;

        //Properties
        /// <summary>
        /// Property to get the radius and set it if value is greater than zero.
        /// </summary>
        public int Radius
        {
            get
            {
                return radius;
            }

            set
            {
                if (value > 0)
                    radius = value;
            }
        }

        /// <summary>
        /// Property to get the initial cost and set it if value is greater than zero.
        /// </summary>
        public int InitialCost
        {
            get
            {
                return initialCost;
            }

            set
            {
                if (value > 0)
                    initialCost = value;
            }
        }

        /// <summary>
        /// Property to get the salary and set it if value is greater than zero.
        /// </summary>
        public float Salary
        {
            get
            {
                return salary;
            }

            set
            {
                if (value > 0)
                    salary = value;
            }
        }

        /// <summary>
        /// Property to get the original salary.
        /// </summary>
        public float OriginalSalary
        {
            get
            {
                return salary;
            }
 
        }

        /// <summary>
        /// Property to get the activity speed and set it if value is greater than zero.
        /// </summary>
        public int ActivitySpeed
        {
            get
            {
                return activitySpeed;
            }

            set
            {
                if (value > 0)
                    activitySpeed = value;
            }
        }


        //Constructor
        /// <summary>
        /// Constructor that initializes Tower class
        /// </summary>
        /// <param name="pos">Rectangle of the tower.</param>
        /// <param name="spr">Texture2D of the tower.</param>
        /// <param name="radius">Hit radius of the tower.</param>
        /// <param name="initialCost">Initial cost to place the tower.</param>
        /// <param name="activitySpeed">Rate at which the tower functions.</param>
        public Tower(Rectangle pos, Texture2D spr, int radius, int initialCost, int activitySpeed):
            base(pos, spr)
        {
            this.radius = radius;
            this.initialCost = initialCost;
            originalSalary = (initialCost / 5);
            salary = originalSalary;
            this.activitySpeed = activitySpeed;
        }
    }
}
