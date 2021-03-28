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
    /// enum to store the tower held by the player
    /// </summary>
    enum Towers
    {
        None,
        BaseTower
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
        private List<string> codes;

        //Height and width of the tiles
        private int tileHeight;
        private int tileWidth;

        //mouse and keyboard states
        private MouseState mState;
        private MouseState prevMState;
        private KeyboardState kState;
        private KeyboardState prevKState;

        //Textures
        private List<Texture2D> textures;

        //game state
        private GameState gState;

        //buttons
        private Button mapSelectButton1;
        private Button towerMenuButton;
        private Button pauseButton;
        private Button nextWaveButton;
        private Button baseTowerButton;

        //SpriteFonts
        private SpriteFont arial64;
        private SpriteFont arial36;

        //Collision Manager
        private CollisionManager collisions;

        //Enemies
        private Texture2D enemyTex;
        private EnemyManager enMan;
        private List<Enemy> enemies;

        //tower manager
        private List<Tower> towers;
        private TowerManager towerManager;

        //misc
        Towers selectedTower;
        Texture2D towerMenuSprite;
        Rectangle towerMenuPos;
        bool openTowerMenu;
        bool placeTower;

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
            collisions = new CollisionManager();

            level = collisions.CurrentLevel;
            
            codes = collisions.Codes;

            _graphics.PreferredBackBufferWidth = 800;
            _graphics.PreferredBackBufferHeight = 800;

            tileWidth = _graphics.PreferredBackBufferWidth / level.Width;
            tileHeight = _graphics.PreferredBackBufferHeight / level.Height;

            //initialize the mouse and keyboard states
            mState = Mouse.GetState();
            prevMState = Mouse.GetState();
            kState = Keyboard.GetState();
            prevKState = Keyboard.GetState();

            //set game state to title screen
            gState = GameState.TitleScreen;

            //buttons
            mapSelectButton1 = new Button(200, 200, 200, 200);
            towerMenuButton = new Button(_graphics.PreferredBackBufferWidth - (tileWidth * 2), 
                0, tileWidth, tileHeight);
            pauseButton = new Button(_graphics.PreferredBackBufferWidth - tileWidth,
                0, tileWidth, tileHeight);
            nextWaveButton = new Button(_graphics.PreferredBackBufferWidth - (tileWidth * 4),
                0, tileWidth * 2, tileHeight);
            baseTowerButton = new Button(_graphics.PreferredBackBufferWidth - (tileWidth * 2) + 5,
                (tileHeight * 2) + 5, tileWidth, tileHeight);

            towerMenuPos = new Rectangle(_graphics.PreferredBackBufferWidth - (tileWidth * 2),
                tileHeight, tileWidth * 2, tileHeight * 6);

            //misc
            selectedTower = Towers.None;
            openTowerMenu = false;
            placeTower = false;

            enemies = new List<Enemy>();
            enMan = new EnemyManager(enemies);
            
            //towers
            towers = new List<Tower>();
            towerManager = new TowerManager(towers);

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

            //buttons
            mapSelectButton1.DefaultSprite = Content.Load<Texture2D>("testMap1");
            mapSelectButton1.ActiveSprite = Content.Load<Texture2D>("testMap1");
            towerMenuButton.DefaultSprite = Content.Load<Texture2D>("Textures/towerDefense_tile086");
            towerMenuButton.ActiveSprite = Content.Load<Texture2D>("Textures/towerDefense_tile090");
            pauseButton.DefaultSprite = Content.Load<Texture2D>("Textures/towerDefense_tile085");
            pauseButton.ActiveSprite = Content.Load<Texture2D>("Textures/towerDefense_tile089");
            nextWaveButton.DefaultSprite = Content.Load<Texture2D>("NextWaveButton");
            nextWaveButton.ActiveSprite = Content.Load<Texture2D>("NextWaveButtonActive");
            baseTowerButton.DefaultSprite = Content.Load<Texture2D>("Textures/towerDefense_tile291");
            baseTowerButton.ActiveSprite = Content.Load<Texture2D>("Textures/towerDefense_tile291");

            towerMenuSprite = Content.Load<Texture2D>("towerSelector");

            //SpriteFonts
            arial64 = Content.Load<SpriteFont>("arial64");
            arial36 = Content.Load<SpriteFont>("arial36");

            enemyTex = Content.Load<Texture2D>("bruh");

            enemies.Add(new Enemy(
                enemyTex,
                5,
                3f,
                collisions.StartPosition));
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
                    _spriteBatch.DrawString(arial36, "Press Enter to start", new Vector2(200, 400), Color.White);
                    break;
                case GameState.MapSelect:
                    _spriteBatch.DrawString(arial64, "Map Select", new Vector2(200, 0), Color.White);
                    mapSelectButton1.Draw(_spriteBatch, mState);
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
                            level.Draw(_spriteBatch, textures[(i * level.Width) + j],
                            new Rectangle(
                                new Point(tileWidth * j, tileHeight * i),
                                new Point(tileWidth, tileHeight)));
                        
                        }
                    }

                    for (int i = level.Width; i < level.Width * 2; i++)
                    {
                        for (int j = 0; j < level.Height; j++)
                        {

                            //gets the textures for each collumn,
                            //draws each with an equal widths and heights, 
                            //as well as locates them depending on the individual widths
                            //and heights

                            //Draws Objects on the screen
                            level.Draw(_spriteBatch, textures[(level.Width * i) + j],
                            new Rectangle(
                                new Point(tileWidth * j, (tileHeight * (i - level.Width))),
                                new Point(tileWidth, tileHeight)));

                        }
                    }
                    enMan.Draw(_spriteBatch);
                    //draws buttons
                    towerMenuButton.Draw(_spriteBatch, mState);
                    pauseButton.Draw(_spriteBatch, mState);
                    nextWaveButton.Draw(_spriteBatch, mState);

                    //draw the towers
                    for(int i = 0; i < towers.Count; i++)
                    {
                        towers[i].Draw(_spriteBatch);
                    }

                    //draw the towerMenu if it is open
                    if(openTowerMenu == true)
                    {
                        _spriteBatch.Draw(towerMenuSprite, towerMenuPos, Color.White);
                        baseTowerButton.Draw(_spriteBatch, mState);
                    }

                    //if the player has a tower to place and clicks
                    if(placeTower == true)
                    {
                        //draw the selected tower (needs to be changed to add a tower to some sort of list to be drawn permanently
                        switch (selectedTower)
                        {
                            case Towers.BaseTower:
                                //values of tower and temp and default
                                towers.Add(new Tower(
                                    new Rectangle(mState.X, mState.Y, tileWidth, tileHeight),
                                    baseTowerButton.DefaultSprite, 20, 20, 20));
                                break;
                        }

                        //turns off place tower and empties the selectedTower
                        placeTower = false;
                        selectedTower = Towers.None;
                    }

                    break;
                case GameState.PauseScreen:
                    _spriteBatch.DrawString(arial64, "Paused",
                        new Vector2(200, 300), Color.White);
                    break;
                case GameState.GameOver:
                    _spriteBatch.DrawString(arial64, "Game Over",
                        new Vector2(200, 300), Color.Red);
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
                if(mapSelectButton1.Clicked(mState, prevMState))
                {
                    gState = GameState.Gameplay;
                }
            }
            //if the player is in gameplay
            else if(gState == GameState.Gameplay)
            {
                //if the mouse button is clicked and none of the buttons are
                if (mState.LeftButton == ButtonState.Pressed && !pauseButton.RollOver(mState) &&
                    !nextWaveButton.RollOver(mState) && !towerMenuButton.RollOver(mState) && !baseTowerButton.RollOver(mState))
                {
                    placeTower = true;
                }

                //if the player hits escape
                if (SingleKeyPress(Keys.LeftControl) || SingleKeyPress(Keys.RightControl))
                {
                    //return to gameplay
                    gState = GameState.PauseScreen;
                }
                //if the player hits the pause button
                if (pauseButton.Clicked(mState, prevMState))
                {
                    //return to gameplay
                    gState = GameState.PauseScreen;
                }

                //if the player hits the towerMenu button while the menu is closed
                if (towerMenuButton.Clicked(mState, prevMState) && openTowerMenu == false)
                {
                    //open the towerMenu
                    openTowerMenu = true;
                }
                //if the player hits the towerMenu button while the menu is open
                else if (towerMenuButton.Clicked(mState, prevMState) && openTowerMenu == true)
                {
                    //close the towerMenu
                    openTowerMenu = false;
                }

                //if the towerMenu is open
                if(openTowerMenu == true)
                {
                    //if the baseTower button is clicked
                    if(baseTowerButton.Clicked(mState, prevMState))
                    {
                        //select the baseTower and close the towerMenu
                        selectedTower = Towers.BaseTower;
                        openTowerMenu = false;
                    }
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
