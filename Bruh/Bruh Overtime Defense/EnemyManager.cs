using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Bruh_Overtime_Defense
{
    class EnemyManager
    {
        private List<Enemy> enemies;
        private bool dead;

        public EnemyManager(List<Enemy> enemies)
        {
            this.enemies = enemies;
        }
        public void TakeDamage(Enemy e)
        {
            e.Health -= 1;
            if (e.Health <= 0)
            {
                e.IsDead = true;
            }
        }
        public void GetSlowed(Enemy e)
        {
            e.Speed -= 0.15f;
            if(e.Speed <= 0.1f)
            {
                e.Speed = 0.1f;
            }
        }
        public void ChangeDirection(Rectangle r)
        {

        }
        public void Draw(SpriteBatch sb)
        {
            for(int i = 0; i < enemies.Count; i++)
            {
                sb.Draw(enemies[i].Bruh, enemies[i].Position, Color.White);
            }
        }
        public void Update(GameTime gameTime)
        {
            for(int i = 0; i < enemies.Count; i++)
            {
                //if(Collision manager = true)
                //{
                //    TakeDamage(enemies[i]);
                //    GetSlowed(enemies[i]);
                //}

            }
        }
    }
}
