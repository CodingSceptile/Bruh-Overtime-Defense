using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace Bruh_Overtime_Defense
{
    /// <summary>
    /// enum for game states, based mostly on screen
    /// </summary>
    enum GameState
    {
        TitleScreen,
        MapSelect,
        Gameplay,
        PauseScreen,
        GameOver
    }

    /// <summary>
    /// class that runs the game
    /// </summary>
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

        //mouse and keyboard states
        MouseState mState;
        MouseState prevMState;
        KeyboardState kState;
        KeyboardState prevKState;

        //Textures
        private List<Texture2D> textures;
        private List<Texture2D> overlayTextures;

        //game state
        GameState gState;

        //buttons
        Button mapSelect1;

        //SpriteFonts
        SpriteFont arial64;

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

            //initialize the mouse and keyboard states
            mState = Mouse.GetState();
            prevMState = Mouse.GetState();
            kState = Keyboard.GetState();
            prevKState = Keyboard.GetState();

            //set game state to title screen
            gState = GameState.TitleScreen;

            //buttons
            mapSelect1 = new Button(200, 200, 200, 200);

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

            //buttons
            mapSelect1.DefaultSprite = Content.Load<Texture2D>("testTile1");
            mapSelect1.ActiveSprite = Content.Load<Texture2D>("testTile1");

            //SpriteFonts
            arial64 = Content.Load<SpriteFont>("arial64");
        }

        /// <summary>
        /// Updates the game logic once per frame
        /// </summary>
        /// <param name="gameTime"></param>
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            //get the current MouseState and KeyboardState (first thing to be done)
            mState = Mouse.GetState();
            kState = Keyboard.GetState();

            //check the game state and see if it needs to be moved
            FiniteStateMachine();

            //make the current state the previous state (last thing to be done)
            prevMState = mState;
            prevKState = kState;

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

            //draws different things based on the game state
            switch (gState)
            {
                case GameState.TitleScreen:
                    _spriteBatch.DrawString(arial64, "Bruh Tower Defense", new Vector2(0, 300), Color.White);
                    break;
                case GameState.MapSelect:
                    mapSelect1.Draw(_spriteBatch, mState);
                    break;
                case GameState.Gameplay:
                    //draws the map
                    //Manages the tiles locations and sizes
                    for (int i = 0; i < level.Width; i++)
                    {
                        for (int j = 0; j < level.Height; j++)
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
                    break;
                case GameState.PauseScreen:
                    _spriteBatch.DrawString(arial64, "Paused", new Vector2(200, 300), Color.White);
                    break;
                case GameState.GameOver:
                    _spriteBatch.DrawString(arial64, "Game Over", new Vector2(200, 300), Color.Red);
                    break;
            }

            
           
            //end the SpriteBatch
            _spriteBatch.End();

            base.Draw(gameTime);
        }

        /// <summary>
        /// the FSM for the game, to be called during Update()
        /// </summary>
        public void FiniteStateMachine()
        {
            //if the player is on the title screen
            if(gState == GameState.TitleScreen)
            {
                //if the player hits enter or space
                if(SingleKeyPress(Keys.Enter) || SingleKeyPress(Keys.Space))
                {
                    //go to map select
                    gState = GameState.MapSelect;
                }
            }
            //if the player is on the map select screen
            else if(gState == GameState.MapSelect)
            {
                //check to see which map button they pressed
                if(mapSelect1.Clicked(mState, prevMState))
                {
                    gState = GameState.Gameplay;
                }
            }
            //if the player is in gameplay
            else if(gState == GameState.Gameplay)
            {
                //if the player hits escape
                if (SingleKeyPress(Keys.LeftControl) || SingleKeyPress(Keys.RightControl))
                {
                    //return to gameplay
                    gState = GameState.PauseScreen;
                }
            }
            //if the player is on the pause screen
            else if(gState == GameState.PauseScreen)
            {
                //if the player hits escape
                if (SingleKeyPress(Keys.LeftControl) || SingleKeyPress(Keys.RightControl))
                {
                    //return to gameplay
                    gState = GameState.MapSelect;
                }
                //if the player hits escape
                else if (SingleKeyPress(Keys.Enter))
                {
                    //game over
                    gState = GameState.Gameplay;
                }
            }
            //if the player is on the game over screen
            else if(gState == GameState.GameOver)
            {
                //if they hit enter or space
                if (SingleKeyPress(Keys.Enter) || SingleKeyPress(Keys.Space))
                {
                    //return to the map select screen
                    gState = GameState.MapSelect;
                }
            }
        }

        /// <summary>
        /// checks to see if a key was pressed a single time
        /// </summary>
        /// <param name="k">the key to be pressed</param>
        /// <returns></returns>
        public bool SingleKeyPress(Keys k)
        {
            //if the key is down on this frame and was up on the previous frame
            if (kState.IsKeyDown(k) && prevKState.IsKeyUp(k))
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
    }
}
