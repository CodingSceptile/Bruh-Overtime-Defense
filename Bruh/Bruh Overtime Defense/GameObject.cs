using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Bruh_Overtime_Defense
{
    class GameObject
    {
        //fields
        private Rectangle position;
        private Texture2D sprite;

        /// <summary>
        /// constructs a basic game object
        /// </summary>
        /// <param name="pos">position of object</param>
        /// <param name="spr">sprite of object</param>
        public GameObject(Rectangle pos, Texture2D spr)
        {
            position = pos;
            sprite = spr;
        }

        /// <summary>
        /// the position of the object
        /// </summary>
        protected Rectangle Position
        {
            get { return position; }
            set { position = value; }
        }

        /// <summary>
        /// the sprite of the object
        /// </summary>
        protected Texture2D Sprite
        {
            get { return sprite; }
            set { sprite = value; }
        }
    }
}
