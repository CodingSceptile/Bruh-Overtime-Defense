using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

//=============================================
//Name: Sami Chamberlain
//Date: 4/23/2021
//Purpose: Handles all of the animated textures
//in the game (PARALLAX EFFECT)
//=============================================

namespace Bruh_Overtime_Defense
{
    class AnimationManager
    {
        //Fields
        private Texture2D clouds;
        private Texture2D buildings;
        private float screenWidth;
        private float screenHeight;

        private Rectangle cloudRect;
        private Rectangle parallaxRectClouds;
        private Rectangle parallaxRectClouds2;

        private Rectangle building1Rect;
        private Rectangle building2Rect;
        private Rectangle building3Rect;
        private Rectangle building4Rect;
        //Properties

        //Constructor
        public AnimationManager(Texture2D clouds, Texture2D buildings,
            float screenWidth, float screenHeight)
        {
            this.clouds = clouds;
            this.buildings = buildings;
            this.screenHeight = screenHeight;
            this.screenWidth = screenWidth;

            cloudRect = new Rectangle(
                new Point(0, 0),
                new Point((int)screenWidth, (int)screenHeight));

            parallaxRectClouds = new Rectangle(
                new Point(-1 * (int)screenWidth, 0),
                new Point((int)screenWidth, (int)screenHeight));

            parallaxRectClouds2 = new Rectangle(
                new Point(-2 * (int)screenWidth, 0),
                new Point((int)screenWidth, (int)screenHeight));

            building1Rect = new Rectangle(
                new Point(0, (int)screenHeight / 2),
                new Point((int)screenWidth / 2, (int)screenHeight / 2));
            building2Rect = new Rectangle(
                new Point((int)screenWidth / 2, (int)screenHeight / 2),
                new Point((int)screenWidth / 2, (int)screenHeight / 2));
            building3Rect = new Rectangle(
                new Point((int)screenWidth, (int)screenHeight / 2),
                new Point((int)screenWidth / 2, (int)screenHeight / 2));
            building4Rect = new Rectangle(
                new Point((int)0 - (int)(screenWidth/2), (int)screenHeight / 2),
                new Point((int)screenWidth / 2, (int)screenHeight / 2));
        }
        
        //Methods    
        public void Draw(SpriteBatch sb)
        {
            sb.Draw(clouds, cloudRect, Color.White);
            sb.Draw(clouds, parallaxRectClouds, Color.White);
            sb.Draw(clouds, parallaxRectClouds2, Color.White);
            sb.Draw(buildings, building1Rect, Color.White);
            sb.Draw(buildings, building2Rect, Color.White);
            sb.Draw(buildings, building3Rect, Color.White);
            sb.Draw(buildings, building4Rect, Color.White);

            ChangePositioning();
            cloudRect.X = Wrap(cloudRect);
            parallaxRectClouds.X = Wrap(parallaxRectClouds);
            parallaxRectClouds2.X = Wrap(parallaxRectClouds2);
            building1Rect.X = Wrap(building1Rect);
            building2Rect.X = Wrap(building2Rect);
            building3Rect.X = Wrap(building3Rect);
            building4Rect.X = Wrap(building4Rect);


            
        }

        private void ChangePositioning()
        {
            cloudRect.X += 1;
            parallaxRectClouds.X += 1;
            parallaxRectClouds2.X += 1;
            building1Rect.X += 2;
            building2Rect.X += 2;
            building3Rect.X += 2;
            building4Rect.X += 2;
        }

        private int Wrap(Rectangle r)
        {
            if (r.X - r.Width > screenWidth)
            {
                return (0 - (r.Width) + 5);
            }
            else
            {
                return r.X;
            }
        }
    }
}
