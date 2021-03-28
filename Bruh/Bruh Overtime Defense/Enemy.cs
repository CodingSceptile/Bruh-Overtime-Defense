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
        protected Rectangle position;
        private bool isDead;
        private Texture2D texture;
        private Vector2 movement;
        private int vectorInteractions;

        public int Health { get { return health; } set { health = value; } }
        public float Speed { get { return speed; } set { speed = value; } }
        public bool IsDead { get { return isDead; } set { isDead = value; } }
        public Texture2D Bruh { get { return texture; } }

        /// <summary>
        /// Returns the X coordinate of the
        /// enemy, allows for change
        /// </summary>
        public int X
        {
            get { return position.X; }
            set { position.X = value;}
        }

        /// <summary>
        /// Returns the Y coordinate of the
        /// enemy, allows for change
        /// </summary>
        public int Y
        {
            get { return position.Y; }
            set { position.Y = value; }
        }

        /// <summary>
        /// Gets and sets the movement
        /// of the enemy
        /// </summary>
        public Vector2 Movement
        { 
            get { return movement; }
            set { movement = value; }       
        }

        /// <summary>
        /// Gets and sets the number of times
        /// an enemy has interacted with a vector
        /// </summary>
        public int VectorInteractions 
        {
            get { return vectorInteractions; }
            set { vectorInteractions = value; }      
        }

        public Enemy( Texture2D texture, int health, float speed, Rectangle position)
            : base(position, texture)
        {
            this.texture = texture;
            this.health = health;
            this.speed = speed;
            this.position = position;
            if(position.X == 0)
            {
                this.movement = new Vector2(speed, 0);
            }
            else
            {
                this.movement = new Vector2(0, speed);
            }
            
            this.vectorInteractions = 0;
        }
    } 
}
