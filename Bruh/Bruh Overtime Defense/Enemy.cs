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
        private Vector2 originalMovement;
        private bool startPosSet;
        private RyanTheGateKeeper staller;
        private Texture2D originalTexture;

        private int moneyGained;

        //Properties
        /// <summary>
        /// Gets or sets the health of an enemy
        /// </summary>
        public int Health { get { return health; } set { health = value; } }

        /// <summary>
        /// Gets or sets the speed of the enemy
        /// </summary>
        public float Speed { get { return speed; } set { speed = value; } }

        /// <summary>
        /// gets or sets whether or not the enemy is dead
        /// </summary>
        public bool IsDead { get { return isDead; } set { isDead = value; } }

        /// <summary>
        /// Gets or sets texture of the bruh
        /// </summary>
        public Texture2D Bruh { get { return texture; } set { texture = value; } }

        /// <summary>
        /// Gets or sets whether or not ryan is 
        /// targetting the bruh
        /// </summary>
        public RyanTheGateKeeper Staller { get { return staller; } set { staller = value; } }

        /// <summary>
        /// Gets the original texture of the bruh
        /// </summary>
        public Texture2D OriginalBruh { get { return originalTexture; } }

        /// <summary>
        /// Gets the amount of money given by
        /// a specific bruh
        /// </summary>
        public int MoneyGained { get { return moneyGained; } }

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

        public Vector2 OriginalMovement
        {
            get { return originalMovement; }
            set { originalMovement = value; }
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


        public bool StartPosSet
        {
            get { return startPosSet; }
            set { startPosSet = value; }
        }



        /// <summary>
        /// Constructor that initializes the enemy object.
        /// </summary>
        /// <param name="texture">Texture of the enemy</param>
        /// <param name="health">Health of the enemy</param>
        /// <param name="speed">Movement speed of the enemy</param>
        /// <param name="position">Position of the enemy on the map</param>
        public Enemy(Texture2D texture, int health, float speed, Rectangle position,
            int moneyGained)
            : base(position, texture)
        {
            this.texture = texture;
            originalTexture = texture;
            this.health = health;
            this.speed = speed;
            this.position = position;
            this.isDead = true;

            startPosSet = false;

            if (position.X - position.Y < 0)
            {
                this.movement = new Vector2(speed, 0);
            }
            else if (position.X - position.Y > 0
                && !(position.Y == 0))
            {
                this.Movement = new Vector2(-speed, 0);
            }
            else
            {
                this.movement = new Vector2(0, speed);
            }
            
            this.vectorInteractions = 0;
            this.originalMovement = movement;
            this.moneyGained = moneyGained;
        }
    } 
}
