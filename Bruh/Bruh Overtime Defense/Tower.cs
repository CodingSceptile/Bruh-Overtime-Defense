using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
//HEADER=======================================
//Author: Mukund Suresh
//Purpose: To create a tower class that shoots bruhs, and needs to be paid a salary.
//=============================================
namespace Bruh_Overtime_Defense
{
     abstract class Tower : GameObject //not abstract FOR NOW
    {
        //Fields
        protected int radius;
        protected int initialCost;
        protected float originalSalary; 
        protected float salary;
        protected int activitySpeed;
        protected GameTime gameTime;
        protected List<Enemy> moneyYield;
        protected int moneyGiven;
        protected bool madeShot;

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
                return originalSalary;
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

        public bool MadeShot
        {
            get { return madeShot; }
            set { madeShot = value; }
        }
            
        /// <summary>
        /// Property to get gametime. 
        /// </summary>
        public GameTime GameTime { get { return gameTime; } }

        //Constructor
        /// <summary>
        /// Constructor that initializes Tower class
        /// </summary>
        /// <param name="pos">Rectangle of the tower.</param>
        /// <param name="spr">Texture2D of the tower.</param>
        /// <param name="radius">Hit radius of the tower.</param>
        /// <param name="initialCost">Initial cost to place the tower.</param>
        /// <param name="activitySpeed">Rate at which the tower functions.</param>
        public Tower(Rectangle pos, Texture2D spr, int radius, int initialCost, int activitySpeed, GameTime gameTime):
            base(pos, spr)
        {
            this.radius = radius;
            this.initialCost = initialCost;
            originalSalary = initialCost;
            salary = originalSalary;
            this.activitySpeed = activitySpeed;
            moneyYield = new List<Enemy>();
            this.gameTime = gameTime;
            madeShot = false;
        }

        //Methods

        /// <summary>
        /// Draws a tower to the sreen
        /// </summary>
        /// <param name="sb">_spriteBatch</param>
        public void Draw(SpriteBatch sb)
        {
            //if the tower landed a shot, make it flash red as an indicator
            if(madeShot == false)
            {
                sb.Draw(Sprite, Position, Color.White);
            }
            else if(madeShot == true)
            {
                sb.Draw(Sprite, Position, Color.Red);
            }

            sb.Draw()
            
        }

        /// <summary>
        /// If Salary is due and not paid (can change condition so some time should pass later)
        /// then tower resigns and leaves. Will add the bruh generation feature after the enemy class is
        /// worked on a bit more.
        /// </summary>
        /// <returns></returns>
        public bool Resignation()
        {
            if (SalaryDue())
            {
                return true;
            }

            else return false;
        }

        /// <summary>
        /// Checks if salary is due.
        /// </summary>
        /// <returns>True if salary is true, false if not.</returns>
        public bool SalaryDue()
        {
            //I could make it subtract raw, but in this model, all towers 
            //have to be paid at equal times. Could make it so that the expensive
            //ones could be paid less often but we'll see
            salary -= (int)(originalSalary / 4); //5 is arbitrary

            if (salary <= 0)
            {
                salary = 0; //doesn't really matter but don't want it to be -ve
                return true;
            }

            else return false;
        }

        /// <summary>
        /// Shoots the bruh, doing 1 hit point of damage to it
        /// every given number of seconds
        /// </summary>
        /// <param name="enemies">The list of enemies it is aiming to shoot</param>
        /// <returns>The money yielded from killing the enemy</returns>
        public virtual int Shoot(List<Enemy> enemies)
        {
            foreach (Enemy e in enemies)
            {
                //Shoots every activitySpeed amount of seconds.
                if((int)gameTime.TotalGameTime.TotalMilliseconds % (activitySpeed * 1000) == 0)
                {
                    if (Distance(Position, e.Position) <= Radius)
                    {
                        if (e.IsDead == true)
                        {
                            continue;
                        }

                        e.Health -= 1;
                        if (e.Health <= 0)
                        {
                            e.IsDead = true;
                            return 1;
                        }

                    }

                } 
            }
            return 0;
        }

        /// <summary>
        /// Finds the distance between two rectangle positions
        /// </summary>
        /// <param name="p1">First point</param>
        /// <param name="p2">Second point</param>
        /// <returns>Distance between first point and second point</returns>
        public float Distance(Rectangle p1, Rectangle p2)
        {
            float distance = (float)Math.Sqrt(Math.Pow(p1.X - p2.X, 2) + Math.Pow(p1.Y - p2.Y, 2));
            return distance;
        }

        /// <summary>
        /// allows the tower to be clicked
        /// </summary>
        /// <param name="mState"></param>
        /// <param name="prevMState"></param>
        /// <returns></returns>
        public bool Clicked(MouseState mState, MouseState prevMState)
        {
            //if the x coord is right
            if (mState.X > Position.X && mState.X < Position.X + Position.Width)
            {
                //if the y coord is right
                if (mState.Y > Position.Y && mState.Y < Position.Y + Position.Height)
                {
                    if(mState.LeftButton != prevMState.LeftButton && mState.LeftButton == ButtonState.Pressed)
                    {
                        //return true
                        return true;
                    }
                }
            }
            //else return false
            return false;
        }
    }
}
