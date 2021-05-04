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
    public enum Priority
    {
        First,
        Strong,
        Close
    }
     abstract class Tower : GameObject
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
        protected Vector2 direction;
        protected double rotation;
        protected Enemy targetEnemy;
        protected Priority towerPriority;
        protected Texture2D radii;
        protected int damageGiven;

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

        /// <summary>
        /// Property to get and set the enemy priorities of the tower.
        /// </summary>
        public Priority TowerPriority { get { return towerPriority; } set { towerPriority = value; } }

        //Constructor
        /// <summary>
        /// Constructor that initializes Tower class
        /// </summary>
        /// <param name="pos">Rectangle of the tower.</param>
        /// <param name="spr">Texture2D of the tower.</param>
        /// <param name="radius">Hit radius of the tower.</param>
        /// <param name="initialCost">Initial cost to place the tower.</param>
        /// <param name="activitySpeed">Rate at which the tower functions.</param>
        public Tower(Rectangle pos, Texture2D spr, int radius, int initialCost, int activitySpeed, GameTime gameTime,
            Texture2D radiusSpr):
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
            targetEnemy = null;
            towerPriority = Priority.First;
            radii = radiusSpr;
            damageGiven = 1;
        }

        //Methods

        /// <summary>
        /// Draws a tower to the sreen
        /// </summary>
        /// <param name="sb">_spriteBatch</param>
        public void Draw(SpriteBatch sb,  GraphicsDeviceManager _graphics)
        {  
            Vector2 origin = new Vector2((float)(Sprite.Width / 2f), (float)(Sprite.Height / 2f));
            //if the tower landed a shot, make it flash red as an indicator
            //Using this if else because it only seems to be aiming in the positive directions
            if (madeShot == false)
            {
                //sb.Draw(Sprite, Position, Color.White);
                if (direction.X <= 0)
                    sb.Draw(Sprite,
                        new Rectangle(new Point((int)(Position.X + 15), (int)(Position.Y + 15)),
                        new Point(Position.Width, Position.Height)),
                        null, Color.White, (float)rotation, origin, SpriteEffects.FlipHorizontally, 0f);
                else
                    sb.Draw(Sprite,
                        new Rectangle(new Point((int)(Position.X + 15), (int)(Position.Y + 15)),
                        new Point(Position.Width, Position.Height)),
                        null, Color.White, (float)rotation, origin, SpriteEffects.None, 0f);
            }
            else if (madeShot == true)
            {
                //sb.Draw(Sprite, Position, Color.Red);
                if (direction.X <= 0)
                    sb.Draw(Sprite,
                        new Rectangle(new Point((int)(Position.X + 15), (int)(Position.Y + 15)),
                        new Point(Position.Width, Position.Height)),
                        null, Color.Red, (float)rotation, origin, SpriteEffects.FlipHorizontally, 0f);

                else
                    sb.Draw(Sprite,
                        new Rectangle(new Point((int)(Position.X + 15), (int)(Position.Y + 15)),
                        new Point(Position.Width, Position.Height)),
                        null, Color.Red, (float)rotation, origin, SpriteEffects.None, 0f);
            }
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
            madeShot = false;

            //sets target enemy to first one so null reference is not
            //thrown.
            //First priority

            if(towerPriority == Priority.First)
            {
                if (targetEnemy == null && enemies.Count > 0)
                {
                    foreach (Enemy e in enemies)
                    {
                        if (!e.IsDead)
                        {
                            if (Distance(Position, e.Position) <= Radius)
                            {
                                targetEnemy = e;
                                break;
                            }
                        }
                    }
                }
            }
            
            else if(towerPriority == Priority.Strong)
            {
                if (targetEnemy == null && enemies.Count > 0)
                {
                    targetEnemy = enemies[0];

                    foreach (Enemy e in enemies)
                    {
                        if (!e.IsDead)
                        {
                            if (Distance(Position, e.Position) <= Radius)
                            {
                                if(e.Health > targetEnemy.Health)
                                {
                                    targetEnemy = e;
                                }
                            }
                        }
                    }
                }
            }

            else if(towerPriority == Priority.Close)
            {
                if (targetEnemy == null && enemies.Count > 0)
                {
                    targetEnemy = enemies[0];
                    foreach (Enemy e in enemies)
                    {
                        if (!e.IsDead)
                        {
                            if (Distance(Position, e.Position) <= Radius)
                            {
                                if (Distance(e.Position, Position) < Distance(targetEnemy.Position, Position))
                                {
                                    targetEnemy = e;
                                }
                            }
                        }
                    }
                }
            }

           foreach (Enemy e in enemies)
           {
                //so more money can be returned for stronger enemies
                if(targetEnemy != null)
                {
                    //resets target enemy in case something
                    //is shot down mid-cycle
                    if (targetEnemy.IsDead)
                    {
                        //for First prio
                        if(towerPriority == Priority.First)
                        {
                            if (!e.IsDead)
                            {
                                targetEnemy = e;
                                break;
                            }
                        }
                        
                        //For strong prio
                        else if(towerPriority == Priority.Strong)
                        {
                            foreach (Enemy en in enemies)
                            {
                                if (!en.IsDead)
                                {
                                    if (Distance(Position, en.Position) <= Radius)
                                    {
                                        if (en.Health > targetEnemy.Health)
                                        {
                                            targetEnemy = en;
                                        }
                                    }
                                }
                            }
                        }

                        //For close prio
                        else if(towerPriority == Priority.Close)
                        {
                            foreach (Enemy ene in enemies)
                            {
                                if (!ene.IsDead)
                                {
                                    if (Distance(Position, ene.Position) <= Radius)
                                    {
                                        if (Distance(ene.Position, Position) 
                                            < Distance(targetEnemy.Position, Position))
                                        {
                                            targetEnemy = ene;
                                        }
                                    }
                                }
                            }
                        }
                    }

                    //code for aiming at target enemy
                    if (Distance(Position, targetEnemy.Position) <= Radius && !targetEnemy.IsDead)
                    {
                        Vector2 towerPosition = new Vector2(Position.X, Position.Y);
                        Vector2 enemyPosition = new Vector2(targetEnemy.Position.X, targetEnemy.Position.Y);

                        direction = enemyPosition - towerPosition;
                        rotation = Math.Atan(direction.Y / direction.X);
                    }

                    //Shoots every activitySpeed amount of seconds.
                    if ((int)gameTime.TotalGameTime.TotalMilliseconds % (activitySpeed * 500) == 0)
                    {
                        if (Distance(Position, targetEnemy.Position) <= Radius)
                        {
                            if (targetEnemy.IsDead == true)
                            {
                                continue;
                            }

                            targetEnemy.Health -= damageGiven;
                            madeShot = true;
                            if (targetEnemy.Health <= 0)
                            {
                                targetEnemy.IsDead = true;
                                return targetEnemy.MoneyGained;
                            }
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
        /// checks to see if the tower is being rolled over
        /// </summary>
        /// <param name="mState"></param>
        /// <returns></returns>
        public bool RollOver(MouseState mState)
        {
            //if the x coord is right
            if (mState.X > Position.X && mState.X < Position.X + Position.Width)
            {
                //if the y coord is right
                if (mState.Y > Position.Y && mState.Y < Position.Y + Position.Height)
                {
                    //return true
                    return true;
                }
            }
            //else return false
            return false;
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
