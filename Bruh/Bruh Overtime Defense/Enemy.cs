using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Bruh_Overtime_Defense
{
    class Enemy : GameObject
    {
        private int health;
        private int speed;
        private Vector2 position;
        private bool isDead;
        private Texture2D texture;
        private Rectangle hitBox;

        public int Health { get { return health; } set { health = value; } }
        public int Speed { get { return speed; } set { speed = value; } }
        public bool IsDead { get { return isDead; } }

        public Enemy(Rectangle box, Texture2D texture, int health, int speed)
            : base(box, texture)
        {
            this.hitBox = box;
            this.texture = texture;
            this.health = health;
            this.speed = speed;
        }
    } 
}
