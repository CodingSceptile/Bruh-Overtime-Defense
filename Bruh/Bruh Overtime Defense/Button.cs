using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Bruh_Overtime_Defense
{
    //HEADER========================================================
    //Name: London Emmerich
    //Purpose: creates a button that can be hovered over and clicked
    //==============================================================

    class Button
    {
        //fields
        private Rectangle bounds;
        private Texture2D defaultSprite;
        private Texture2D activeSprite;

        /// <summary>
        /// Constructor to make a button
        /// </summary>
        /// <param name="x">x of bounds</param>
        /// <param name="y">y of bounds</param>
        /// <param name="width">width of bounds</param>
        /// <param name="height">height of bounds</param>
        public Button(int x, int y, int width, int height)
        {
            bounds = new Rectangle(x, y, width, height);
        }

        /// <summary>
        /// the bounds of the button
        /// </summary>
        public Rectangle Bounds
        {
            get { return bounds; }
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
        /// the active sprite of the button
        /// </summary>
        public Texture2D ActiveSprite
        {
            get { return activeSprite; }
            set { activeSprite = value; }
        }

        /// <summary>
        /// the default sprite of the button
        /// </summary>
        public Texture2D DefaultSprite
        {
            get { return defaultSprite; }
            set { defaultSprite = value; }
        }

        /// <summary>
        /// checks to see if the mouse is hovering over the button
        /// </summary>
        /// <param name="mState">the current mouse state</param>
        /// <returns></returns>
        public bool RollOver(MouseState mState)
        {
            //get the mouse state
            mState = Mouse.GetState();

            //if the x coord is right
            if(mState.X > bounds.X && mState.X < bounds.X + bounds.Width)
            {
                //if the y coord is right
                if (mState.Y > bounds.Y && mState.Y < bounds.Y + bounds.Height)
                {
                    //return true
                    return true;
                }
            }
            //else return false
            return false;
        }

        /// <summary>
        /// checks to see if the button was clicked a single time
        /// </summary>
        /// <param name="mState">the current mouse state</param>
        /// <param name="prevMState">the previous mouse state</param>
        /// <returns></returns>
        public bool Clicked(MouseState mState, MouseState prevMState)
        {
            //get the mouse state
            mState = Mouse.GetState();

            //if the button is rolled over and clicked once
            if(RollOver(mState) && SingleLeftClick(mState, prevMState))
            {
                //return true
                return true;
            }
            //else
            else
            {
                //return false
                return false;
            }
        }

        /// <summary>
        /// if the button was clicked a single time
        /// </summary>
        /// <param name="mState">the current mouse state</param>
        /// <param name="prevMState">the previous mouse state</param>
        /// <returns></returns>
        public bool SingleLeftClick(MouseState mState, MouseState prevMState)
        {
            //get the current mouse state
            mState = Mouse.GetState();

            //if the left button is not the same as before and is currently clicked
            if (mState.LeftButton != prevMState.LeftButton && mState.LeftButton == ButtonState.Pressed)
            {
                //return true
                return true;
            }
            //else
            else
            {
                //return false
                return false;
            }
        }

        /// <summary>
        /// draws the button
        /// </summary>
        /// <param name="sb">the spriteBatch</param>
        /// <param name="mState">the current mouse state</param>
        public void Draw(SpriteBatch sb, MouseState mState)
        {
            //if the button is being rolled over
            if (RollOver(mState))
            {
                //use the active sprite
                sb.Draw(activeSprite, Bounds, Color.White);
            }
            //else
            else
            {
                //use the default sprite
                sb.Draw(defaultSprite, Bounds, Color.White);
            }
        }
    }
}

