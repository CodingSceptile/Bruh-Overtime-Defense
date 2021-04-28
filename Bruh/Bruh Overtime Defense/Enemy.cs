using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Bruh_Overtime_Defense
{
    //HEADER===============================
    //Name: Caleb Jeon
    //Purpose: Creates Enemy objects that
    //can be stopped with tower objects
    //=====================================

    class Enemy : GameObject
    {
        //Fields
        private int health;
        private float speed;
        protected Rectangle position;
        private bool isDead;
        private Texture2D texture;
        private Vector2 movement;
        private int vectorInteractions;
        private float originalSpeed;
        private Rectangle internalHitbox;

        //Properties
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

        /// <summary>
        /// returns the internal hitbox of the enemy
        /// </summary>
        public Rectangle Hitbox { get { return internalHitbox; } }

        /// <summary>
        /// Gets or sets the internal
        /// hitboxes' x value
        /// </summary>
        public int HitX
        {
            get { return internalHitbox.X; }
            set { internalHitbox.X = value; }
        }

        /// <summary>
        /// Gets or sets the internal hitboxes' y value
        /// </summary>
        public int HitY
        {
            get { return internalHitbox.Y; }
            set { internalHitbox.Y = value; }
        }

        /// <summary>
        /// returns the original speed of the enemy
        /// </summary>
        public float OriginalSpeed
        {
            get { return originalSpeed; }
        }

        /// <summary>
        /// Constructor that initializes the enemy object.
        /// </summary>
        /// <param name="texture">Texture of the enemy</param>
        /// <param name="health">Health of the enemy</param>
        /// <param name="speed">Movement speed of the enemy</param>
        /// <param name="position">Position of the enemy on the map</param>
        public Enemy( Texture2D texture, int health, float speed, Rectangle position)
            : base(position, texture)
        {
            this.texture = texture;
            this.health = health;
            this.speed = speed;
            this.position = position;
            this.isDead = true;
            
            //Creates an internal hitbox to fix the 
            //issue of rotation overlap
            internalHitbox =
                new Rectangle(
                    new Point(position.X + (position.Width), position.Y + position.Height),
                    new Point(position.Width / 5, position.Height / 5));

            if(position.X == 0)
            {
                this.movement = new Vector2(speed, 0);
            }
            else
            {
                this.movement = new Vector2(0, speed);
            }
            
            this.vectorInteractions = 0;
            this.originalSpeed = speed;
        }
    } 
}
