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
        private float speed;
        private Rectangle position;
        private bool isDead;
        private Texture2D texture;

        public int Health { get { return health; } set { health = value; } }
        public float Speed { get { return speed; } set { speed = value; } }
        public bool IsDead { get { return isDead; } set { isDead = value; } }
        public Texture2D Bruh { get { return texture; } }
        public Rectangle Place { get { return position; } }

        public Enemy( Texture2D texture, int health, float speed, Rectangle position)
            : base(position, texture)
        {
            this.texture = texture;
            this.health = health;
            this.speed = speed;
            this.position = position;
        }
    } 
}
