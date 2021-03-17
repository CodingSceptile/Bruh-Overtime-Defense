using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Bruh_Overtime_Defense
{
    class Button
    {
        //fields
        private Rectangle bounds;
        private Texture2D sprite;

        public Button(int x, int y, int width, int height)
        {
            bounds = new Rectangle(x, y, width, height);
        }

        /// <summary>
        /// x coord of the button
        /// </summary>
        public int X
        {
            get { return bounds.X; }
            set { bounds.X = value; }
        }

        /// <summary>
        /// y coord of the button
        /// </summary>
        public int Y
        {
            get { return bounds.Y; }
            set { bounds.Y = value; }
        }

        /// <summary>
        /// width of the button
        /// </summary>
        public int Width
        {
            get { return bounds.Width; }
            set { bounds.Width = value; }
        }

        /// <summary>
        /// height of the button
        /// </summary>
        public int Height
        {
            get { return bounds.Height; }
            set { bounds.Height = value; }
        }

        /// <summary>
        /// the sprite of the button
        /// </summary>
        public Texture2D DefaultSprite
        {
            get { return sprite; }
            set { sprite = value; }
        }

        public bool RollOver(MouseState mState)
        {
            mState = Mouse.GetState();

            if(mState.X > bounds.X && mState.X < bounds.X + bounds.Width)
            {
                if (mState.Y > bounds.Y && mState.Y < bounds.Y + bounds.Height)
                {
                    return true;
                }
            }
            return false;
        }

        public bool Clicked(MouseState mState, MouseState prevMState)
        {
            mState = Mouse.GetState();
            if(RollOver(mState) && SingleLeftClick(mState, prevMState))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool SingleLeftClick(MouseState mState, MouseState prevMState)
        {
            mState = Mouse.GetState();
            if (mState.LeftButton != prevMState.LeftButton && mState.LeftButton == ButtonState.Pressed)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}

