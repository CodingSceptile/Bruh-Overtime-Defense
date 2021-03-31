using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Bruh_Overtime_Defense
{
    //HEADER================================================
    //Names: Sami Chamberlain, Caleb Jeon
    //Date: 3/31/2021
    //Purpose: Manages all of the enemy objects in the game
    //======================================================

    class EnemyManager
    {
        //Fields
        private List<Enemy> enemies;
        private int enemyNum;
        private Rectangle startPos;
        private int startX;
        private int startY;

        /// <summary>
        /// Creates a new EnemyManager object
        /// </summary>
        /// <param name="enemies">List of enemy objects</param>
        /// <param name="startPos">Start position of the enemies</param>
        public EnemyManager(List<Enemy> enemies, Rectangle startPos)
        {
            this.enemies = enemies;
            enemyNum = 0;
            this.startPos = startPos;
            startX = startPos.X;
            startY = startPos.Y;
            
        }

        /// <summary>
        /// Reduces the health of an enemy
        /// </summary>
        /// <param name="e">an enemy</param>
        public void TakeDamage(Enemy e)
        {
            e.Health -= 1;
            if (e.Health <= 0)
            {
                e.IsDead = true;
            }
        }

        /// <summary>
        /// Slows an enemy (unused currently)
        /// </summary>
        /// <param name="e">An enemy</param>
        public void GetSlowed(Enemy e)
        {
            e.Speed -= 0.15f;
            if(e.Speed <= 0.1f)
            {
                e.Speed = 0.1f;
            }
        }

        /// <summary>
        /// Draws active enemies to the screen
        /// </summary>
        /// <param name="sb">_spriteBatch</param>
        public void Draw(SpriteBatch sb)
        {                     
            for(int i = 0; i < enemies.Count; i++)
            {
                //only draws if they are not dead
                if(enemies[i].IsDead == false)
                {
                    sb.Draw(enemies[i].Bruh, enemies[i].Position, Color.White);
                }                                         
            }
        }

        /// <summary>
        /// Updates the logic of enemies once
        /// per frame
        /// </summary>
        /// <param name="gameTime">keeps track of the time in game</param>
        public void Update(GameTime gameTime)
        {

            //Sets an interval in which enemies can spawn
            if (gameTime.TotalGameTime.TotalMilliseconds % 500 < 1)
            {
                //checks if more enemies need to be spawned
                if (enemyNum < enemies.Count)
                {
                    enemies[enemyNum].X = startX;
                    enemies[enemyNum].Y = startY;
                    enemies[enemyNum].IsDead = false;
                    enemyNum++;
                }           
            }

            //sets the location of the enemies
            for (int i = 0; i < enemies.Count; i++)
            {
                enemies[i].Position = new Rectangle(
                        enemies[i].X, enemies[i].Y,
                        enemies[i].Position.Width, enemies[i].Position.Height);
            }
        }

        /// <summary>
        /// Resets all enemies in the manager's list
        /// </summary>
        public void ResetEnemies()
        {
            enemies.Clear();
            enemyNum = 0;         
        }
    }
}
