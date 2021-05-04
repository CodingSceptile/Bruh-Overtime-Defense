using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
//HEADER================================================
//Author: Mukund Suresh
//Purpose: To create a Tower manager class that keeps track off
//and executes all the tower interactions.
//======================================================
namespace Bruh_Overtime_Defense
{
    class TowerManager
    {
        //Fields
        private List<Tower> towers;
        private List<Rectangle> trackLocs;

        /// <summary>
        /// Constructor that initializes the tower manager
        /// </summary>
        /// <param name="towers">List of towers</param>
        public TowerManager(List<Tower> towers, List<Rectangle> trackLocs)
        {
            this.towers = towers;
            this.trackLocs = trackLocs;
        }

        //Methods
        /// <summary>
        /// This method tops off the salary of the tower.
        /// </summary>
        /// <param name="t">The lucky tower that's getting paid.</param>
        public void SalaryPaid(Tower t)
        {
            t.Salary += t.OriginalSalary/4;
        }

        /// <summary>
        /// The towers that resign are removed.
        /// </summary>
        /// <returns>True if it's resigning, false if not.</returns>
        public void Resignations(List<Tower> towers, List<Enemy> enemies,
            Texture2D enemyTexture, Rectangle startPos, List<bool> towerRollover)
        {
            for(int i = 0; i < towers.Count; i++)
            {
                if(towers[i].Resignation())
                {
                    Enemy newEnemy = null;
                    if (towers[i] is DootSkeleton)
                    {
                        newEnemy = new Enemy(enemyTexture, 1, 3, startPos, 1);
                    }
                    else if (towers[i] is SniperMonke)
                    {
                        newEnemy = new Enemy(enemyTexture, 3, 3, startPos, 2);
                    }
                    else if(towers[i] is BuffDoge)
                    {
                        newEnemy = new Enemy(enemyTexture, 5, 3, startPos, 3);
                    }
                    else if(towers[i] is RyanTheGateKeeper)
                    {
                        newEnemy = new Enemy(enemyTexture, 6, 3, startPos, 4);
                    }
                    else
                    {
                        newEnemy = new Enemy(enemyTexture, 10, 6, startPos, 5);
                    }

                    towers.Remove(towers[i]);
                    towerRollover.RemoveAt(i);
                    enemies.Add(newEnemy);
                }
            }
        }

        /// <summary>
        /// Shoot method to pop bruhs
        /// </summary>
        /// <param name="t">The tower that is trying to pop</param>
        /// <param name="enemies">The enemies on the map.</param>
        public int Shoot(Tower t, List<Enemy> enemies)
        {
            return t.Shoot(enemies);
        }

        /// <summary>
        /// Draws the towers on the map (unless it intersects on the path)
        /// </summary>
        /// <param name="sb">SpriteBatch</param>
        public void DrawTowers(SpriteBatch sb, SpriteFont sf, List<Enemy> enemies, GraphicsDeviceManager _graphics)
        {
            //bool otherTowerPlaced = false;

            //for(int i = 0; i < towers.Count; i++)
            //{
            //    for(int j = 1; j < towers.Count; j++)
            //    {
            //        if(i != j)
            //        {
            //            if(towers[i].Position.Intersects(towers[j].Position))
            //            {
            //                otherTowerPlaced = true;
            //                break;
            //            }
            //        }
            //    }
            //}

            for(int i = 0; i < towers.Count; i++)
            {
                foreach(Rectangle r in trackLocs)
                {
                    //if the tower is not on a track tile
                    if((!r.Intersects(towers[i].Position)) /*&& !otherTowerPlaced*/)
                    {
                        //draw the tower and its remaining pay beneath it
                        towers[i].Draw(sb, _graphics);
                        sb.DrawString(sf, "Pay Left: " + towers[i].Salary,
                            new Vector2(towers[i].Position.X - 20, towers[i].Position.Y + 30),
                            Color.White);
                    }

                }            
            }
        }
    }
}
