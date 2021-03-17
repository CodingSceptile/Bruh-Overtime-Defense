using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace Bruh_Overtime_Defense
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        //Level information and objects
        private Level level;
        private Level overlay;
        private List<string> codes;
        private List<string> overlayCodes;

        //Height and width of the tiles
        private int tileHeight;
        private int tileWidth;

        //mouse states
        MouseState mState;
        MouseState prevMState;

        //Textures
        private List<Texture2D> textures;
        private List<Texture2D> overlayTextures;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        /// <summary>
        /// Initializes main logic of the game
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            textures = new List<Texture2D>();
            overlayTextures = new List<Texture2D>();

            level = new Level("simpleMap.level_Appended");
            overlay = new Level("overlay.level_Appended");
            
            codes = level.GenerateMap();
            overlayCodes = overlay.GenerateMap();

            _graphics.PreferredBackBufferWidth = 750;
            _graphics.PreferredBackBufferHeight = 750;

            tileWidth = _graphics.PreferredBackBufferWidth / level.Width;
            tileHeight = _graphics.PreferredBackBufferHeight / level.Width;

            //initialize the mouse states
            mState = Mouse.GetState();
            prevMState = Mouse.GetState();

            _graphics.ApplyChanges();

            base.Initialize();
        }

        /// <summary>
        /// Loads the Textures, and assigns them to respective lists
        /// </summary>
        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            //Loops through the list of code values garnered from the
            //level editor

            //Main level
            foreach(string code in codes)
            {
                //Loads a texture given the code(Located in the textures folder, basically
                //just the file name)
                Texture2D texture = Content.Load<Texture2D>("Textures/" + code);

                textures.Add(texture);
            }

            //Overlay
            foreach(string code in overlayCodes)
            {
                Texture2D texture = Content.Load<Texture2D>("Textures/" + code);

                overlayTextures.Add(texture);
            }

        }

        /// <summary>
        /// Updates the game logic once per frame
        /// </summary>
        /// <param name="gameTime"></param>
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            //get the current MouseState (first thing to be done)
            mState = Mouse.GetState();

            //make the current state the previous state (last thing to be done)
            prevMState = mState;

            base.Update(gameTime);
        }

        /// <summary>
        /// Draws all necessary assets to the screen
        /// </summary>
        /// <param name="gameTime"></param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            //begin the SpriteBatch
            _spriteBatch.Begin();

            //Manages the tiles locations and sizes
            for(int i = 0; i < level.Width; i++)
            {
                for(int j = 0; j < level.Height; j++)
                {

                    //gets the textures for each collumn,
                    //draws each with an equal widths and heights, 
                    //as well as locates them depending on the individual widths
                    //and heights

                    //Background draw
                    level.Draw(_spriteBatch, textures[(i * 10) + j],
                    new Rectangle(
                        new Point(tileWidth * j, tileHeight * i),
                        new Point(tileWidth, tileHeight)));

                    //Overlay draw
                    overlay.Draw(_spriteBatch, overlayTextures[(i * 10) + j],
                    new Rectangle(
                        new Point(tileWidth * j, tileHeight * i),
                        new Point(tileWidth, tileHeight)));                                      
                }
            }
           
            //end the SpriteBatch
            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
