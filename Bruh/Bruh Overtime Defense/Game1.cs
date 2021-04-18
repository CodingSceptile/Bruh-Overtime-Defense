using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using System;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Media;

//Names: Sami Chamberlain, Mukund Suresh,
//Caleb Jeon, London Emmerich
//Date: 3/31/2021
//Purpose: Establishes game components, and controls
//the logic present in the game...

namespace Bruh_Overtime_Defense
{
    /// <summary>
    /// enum for game states, based mostly on screen
    /// </summary>
    enum GameState
    {
        TitleScreen,
        MapSelect,
        InstructionsScreen,
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
        BaseTower,
        SniperTower,
        BuffTower,
        GatekeeperTower,
        ErinTower,
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
        private List<float> rotations;

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
        private Button sniperButton;
        private Button buffButton;
        private Button gatekeeperButton;
        private Button notErinButton;
        private Button erinModeButton;
        private bool isActive;
        private bool isErinMode;

        //SpriteFonts
        private SpriteFont arial10;
        private SpriteFont arial16;
        private SpriteFont arial36;
        private SpriteFont arial64;

        private SoundEffect bruhEffect;

        //Collision Manager
        private CollisionManager collisions;

        //Enemies
        private Texture2D enemyTex;
        private Texture2D red;
        private Texture2D blue;
        private Texture2D green;
        private Texture2D hurb;
        private EnemyManager enMan;
        private List<Enemy> enemies;
        private float enemySpeed;
        private int enemyHealth;

        //Towers
        private List<Tower> towers;
        private TowerManager towerManager;
        private Towers selectedTower;
        private Texture2D towerMenuSprite;
        private Rectangle towerMenuPos;
        private bool openTowerMenu;
        private bool placeTower;
        private int[] towerRadii;
        private int[] towerCost;
        private int[] towerSpeed;
        private int salaryDivider;

        //misc
        private Random random;
        private int totalMoney;
        private int gainMoney;
        private bool newWave;
        private int currWave;
        private int waveAmount;
        private int enemyCount;
        private int health;
        private TimeSpan timeSpanSincePause;
        private int screenWidth;
        private int screenHeight;
        private Texture2D uiInstructions;

        //Wave manager
        private WaveManager waveMan;

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
            collisions = new CollisionManager("office1.level_Appended");

            level = collisions.CurrentLevel;
            
            codes = collisions.Codes;
            rotations = collisions.Rotations;

            random = new Random();

            _graphics.PreferredBackBufferWidth = 800;
            _graphics.PreferredBackBufferHeight = 800;
            screenWidth = _graphics.PreferredBackBufferWidth;
            screenHeight = _graphics.PreferredBackBufferHeight;

            tileWidth = screenWidth / level.Width;
            tileHeight = screenHeight / level.Height;

            //initialize the mouse and keyboard states
            mState = Mouse.GetState();
            prevMState = Mouse.GetState();
            kState = Keyboard.GetState();
            prevKState = Keyboard.GetState();

            //set game state to title screen
            gState = GameState.TitleScreen;

            //buttons
            mapSelectButton1 = new Button(200, 200, 200, 200);
            towerMenuButton = new Button(screenWidth - (tileWidth * 2), 
                0, tileWidth, tileHeight);
            pauseButton = new Button(screenWidth - tileWidth,
                0, tileWidth, tileHeight);
            nextWaveButton = new Button(screenWidth - (tileWidth * 4),
                0, tileWidth * 2, tileHeight);
            baseTowerButton = new Button(screenWidth - (tileWidth * 3),
                (tileHeight * 2) - 5, tileWidth, tileHeight);
            sniperButton = new Button(screenWidth - (tileWidth * 3),
                (tileHeight * 3) - 5, tileWidth, tileHeight);
            buffButton = new Button(screenWidth - (tileWidth * 3),
                (tileHeight * 4) - 5, tileWidth, tileHeight);
            gatekeeperButton = new Button(screenWidth - (tileWidth * 3),
                (tileHeight * 5) - 5, tileWidth, tileHeight);
            notErinButton = new Button(screenWidth - (tileWidth * 3),
                (tileHeight * 6) - 5, tileWidth, tileHeight);
            erinModeButton = new Button(screenWidth - (tileWidth * 2),
                0, tileWidth * 2, tileHeight);

            towerMenuPos = new Rectangle(screenWidth - (tileWidth * 3),
                tileHeight, tileWidth * 3, tileHeight * 6);

            //misc
            selectedTower = Towers.None;
            openTowerMenu = false;
            placeTower = false;
            totalMoney = 100;
            gainMoney = 0;
            health = 10;
            newWave = false;
            currWave = 0;
            isActive = true;
            waveAmount = 0;
            isErinMode = false;

            //Enemies, and enemy manager
            enemies = new List<Enemy>();
            enMan = new EnemyManager(enemies, collisions.StartPosition);
            enemyCount = 0;
            
            //towers
            towers = new List<Tower>();
            towerManager = new TowerManager(towers, collisions.TrackLocations);
            //arrays store values for towers
            //indices correspond to towers as follows:
            //0: Doot Skeleton, 1: Sniper Monke, 2: Buff Doge
            //3: Ryan the Gatekeeper, 4: Not Erin
            towerRadii = new int[] { 200, int.MaxValue, 100, 200, 200 };
            towerCost = new int[]{ 20, 40, 40, 30, 200};
            towerSpeed = new int[] { 1, 3, 3, 1, 2 };
            salaryDivider = 5;
            
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
            LoadButtons();

            //load other things
            bruhEffect = Content.Load<SoundEffect>("bruhEffect");

            towerMenuSprite = Content.Load<Texture2D>("towerSelector");
            uiInstructions = Content.Load<Texture2D>("BOD UI instructions");

            //SpriteFonts
            arial10 = Content.Load<SpriteFont>("arial10");
            arial16 = Content.Load<SpriteFont>("arial16");
            arial36 = Content.Load<SpriteFont>("arial36");
            arial64 = Content.Load<SpriteFont>("arial64");

            //Bruh enemy texture
            enemyTex = Content.Load<Texture2D>("bruh");
            red = Content.Load<Texture2D>("bruhRed");
            blue = Content.Load<Texture2D>("bruhBlue");
            green = Content.Load<Texture2D>("bruhGreen");
            hurb = Content.Load<Texture2D>("hurb");

            waveMan = new WaveManager("enemyWave.wave",
                enemyTex, red, blue, green, hurb, collisions.StartPosition);
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
            FiniteStateMachine(gameTime);

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
                //TITLE SCREEN
                case GameState.TitleScreen:
                    _spriteBatch.DrawString(arial64, "Bruh Overtime \n    Defense", new Vector2(125, 250), Color.White);
                    _spriteBatch.DrawString(arial36, "Press Enter to start", new Vector2(175, 450), Color.White);
                    break;

                //MAP SELECT SCREEN
                case GameState.MapSelect:
                    _spriteBatch.DrawString(arial64, "Map Select", new Vector2(200, 0), Color.White);
                    mapSelectButton1.Draw(_spriteBatch, mState);
                    erinModeButton.Draw(_spriteBatch, mState);
                    _spriteBatch.DrawString(arial36, "Press Enter to view Instructions",
                        new Vector2(70, 700), Color.White);
                    break;

                //INSTRUCTIONS SCREEN
                case GameState.InstructionsScreen:
                    _spriteBatch.DrawString(arial64, "Instructions", new Vector2(200, 0), Color.White);
                    DrawInstructions();
                    _spriteBatch.Draw(uiInstructions, new Rectangle(250, 450, 250, 250), Color.White);
                    _spriteBatch.DrawString(arial36, "Press Enter to return to Map Select", 
                        new Vector2(25, 720), Color.White);
                    break;

                //GAMEPLAY SCREEN
                case GameState.Gameplay:

                    DrawMap();
                    DrawTowerMenu();

                    //if the player has a tower to place and clicks
                    if(placeTower == true)
                    {
                        
                        //draw the selected tower
                        switch (selectedTower)
                        {
                            case Towers.BaseTower:
                                //values of tower and temp and default
                                towers.Add(new DootSkeleton(
                                    new Rectangle(mState.X - tileWidth / 3, mState.Y - tileHeight / 3,
                                    tileWidth, tileHeight),
                                    baseTowerButton.DefaultSprite, towerRadii[0], towerCost[0], towerSpeed[0], gameTime));
                                totalMoney -= towerCost[0];
                                break;
                            case Towers.SniperTower:
                                //values of tower and temp and default
                                towers.Add(new SniperMonke(
                                    new Rectangle(mState.X - tileWidth / 3, mState.Y - tileHeight / 3,
                                    tileWidth, tileHeight),
                                    sniperButton.DefaultSprite, 
                                    towerRadii[1], towerCost[1], towerSpeed[1], gameTime));
                                totalMoney -= towerCost[1];
                                break;
                            case Towers.BuffTower:
                                //values of tower and temp and default
                                towers.Add(new BuffDoge(
                                    new Rectangle(mState.X - tileWidth / 3, mState.Y - tileHeight / 3,
                                    tileWidth, tileHeight),
                                    buffButton.DefaultSprite, 
                                    towerRadii[2], towerCost[2], towerSpeed[2], gameTime));
                                totalMoney -= towerCost[2];
                                break;
                            case Towers.GatekeeperTower:
                                //values of tower and temp and default
                                towers.Add(new RyanTheGateKeeper(
                                    new Rectangle(mState.X - tileWidth / 3, mState.Y - tileHeight / 3,
                                    tileWidth, tileHeight),
                                    gatekeeperButton.DefaultSprite, 
                                    towerRadii[3], towerCost[3], towerSpeed[3], gameTime));
                                totalMoney -= towerCost[3];
                                break;
                            case Towers.ErinTower:
                                //values of tower and temp and default
                                towers.Add(new Not_Erin(
                                    new Rectangle(mState.X - tileWidth/3, mState.Y - tileHeight/3, 
                                    tileWidth, tileHeight),
                                    notErinButton.DefaultSprite, 
                                    towerRadii[4], towerCost[4], towerSpeed[4], gameTime));
                                totalMoney -= towerCost[4];
                                break;
                        }

                        //turns off place tower and empties the selectedTower
                        placeTower = false;
                        selectedTower = Towers.None;
                    }

                    //draw the towers
                    towerManager.DrawTowers(_spriteBatch, arial10);

                    //Only spawns new enemies if a new wave is active
                    if (newWave == true)
                    {
                        enMan.Update(gameTime);
                        enMan.Draw(_spriteBatch);
                    }

                    break;
                //PAUSE SCREEN
                case GameState.PauseScreen:
                    _spriteBatch.DrawString(arial64, "Paused",
                        new Vector2(240, 0), Color.White);
                    DrawInstructions();
                    _spriteBatch.DrawString(arial36, "Press Enter to return to game",
                        new Vector2(80, 490), Color.White);
                    _spriteBatch.DrawString(arial36, "Press Ctrl to return to map select",
                        new Vector2(50, 600), Color.White);
                    break;
                //GAME OVER SCREEN
                case GameState.GameOver:
                    _spriteBatch.DrawString(arial64, "Game Over",
                        new Vector2(200, 300), Color.Red);
                    _spriteBatch.DrawString(arial36, "Press Enter to return to map select",
                        new Vector2(40, 450), Color.Red);
                    break;
            }
                     
            //end the SpriteBatch
            _spriteBatch.End();

            base.Draw(gameTime);
        }

        /// <summary>
        /// the FSM for the game, to be called during Update()
        /// </summary>
        public void FiniteStateMachine(GameTime gameTime)
        {

            //if the player is on the title screen
            if (gState == GameState.TitleScreen)
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
                if (mapSelectButton1.Clicked(mState, prevMState))
                {
                    //reset the game
                    Reset();
                    //if Erin Mode is on
                    if(isErinMode == true)
                    {
                        //massively increase health and money
                        health = 9999;
                        totalMoney = 9999;
                    }

                    //go to the gameplay state
                    gState = GameState.Gameplay;                  
                }

                //if the ErinModeButton is clicked when ErinMode is off
                if(erinModeButton.Clicked(mState, prevMState) && isErinMode == false)
                {
                    //turn on Erin Mode and change the button look
                    isErinMode = true;
                    erinModeButton.DefaultSprite = Content.Load<Texture2D>("ErinModeON");
                    erinModeButton.ActiveSprite = Content.Load<Texture2D>("ErinModeONActive");
                }
                //if the ErinModeButton is clicked when ErinMode is on
                else if (erinModeButton.Clicked(mState, prevMState) && isErinMode == true)
                {
                    //turn off Erin Mode and change the button look
                    isErinMode = false;
                    erinModeButton.DefaultSprite = Content.Load<Texture2D>("ErinModeOFF");
                    erinModeButton.ActiveSprite = Content.Load<Texture2D>("ErinModeOFFActive");
                }

                //if enter is pressed, view the instructions
                if (SingleKeyPress(Keys.Enter))
                {
                    gState = GameState.InstructionsScreen;
                }
            }
            //if the player is viewing the instructions
            else if(gState == GameState.InstructionsScreen)
            {
                //if enter is pressed, return to map select
                if (SingleKeyPress(Keys.Enter))
                {
                    gState = GameState.MapSelect;
                }
            }
            //if the player is in gameplay
            else if(gState == GameState.Gameplay)
            {
                //Check for changes in movement
                for (int i = 0; i < enemies.Count; i++)
                {
                    if (enemies[i].IsDead == false)
                    {
                        collisions.LevelIntersects(enemies[i]);
                        enemies[i].X += (int)enemies[i].Movement.X;
                        enemies[i].Y += (int)enemies[i].Movement.Y;
                    }
                }

                //Checks if the user needs to take damage
                TakeDamage();
                //checks if bruhs are hit
                ResolveShot(gameTime);
                //pay salaries
                PayTowers();

                //No more health left! Game over!
                if(health <= 0)
                {
                    gState = GameState.GameOver;
                }


                //if the mouse button is clicked and none of the buttons are pressed
                if (mState.LeftButton == ButtonState.Pressed && !pauseButton.RollOver(mState) &&
                    !nextWaveButton.RollOver(mState) && !towerMenuButton.RollOver(mState) &&
                    !baseTowerButton.RollOver(mState) && !sniperButton.RollOver(mState) && 
                    !buffButton.RollOver(mState) && !gatekeeperButton.RollOver(mState) && 
                    !notErinButton.RollOver(mState))
                {

                    bool inTrack = false;
                    //let the user place a tower
                    for(int i = 0; i < collisions.TrackLocations.Count; i++)
                    {
                        if(collisions.TrackLocations[i].Contains(mState.Position))
                        {
                            inTrack = true;
                        }
                    }
                    if(!inTrack)
                    {
                        placeTower = true;
                    }  
                }

                //if the player hits left or right control
                if (SingleKeyPress(Keys.LeftControl) || SingleKeyPress(Keys.RightControl))
                {
                    //pause the game
                    gState = GameState.PauseScreen;
                }
                //if the player hits the pause button
                if (pauseButton.Clicked(mState, prevMState))
                {
                    //pause the game
                    gState = GameState.PauseScreen;
                }

                //if the player hits the towerMenu button while the menu is closed
                if (towerMenuButton.Clicked(mState, prevMState) && openTowerMenu == false)
                {
                    //open the towerMenu
                    openTowerMenu = true;
                    //deselect the player's tower
                    selectedTower = Towers.None;
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
                    //if the baseTower button is clicked and the player can afford it
                    if(baseTowerButton.Clicked(mState, prevMState) &&
                    totalMoney >= towerCost[0])
                    {
                        //select the baseTower and close the towerMenu
                        selectedTower = Towers.BaseTower;
                        openTowerMenu = false;
                    }
                    else if(sniperButton.Clicked(mState, prevMState) &&
                    totalMoney >= towerCost[1])
                    {
                        //select the sniperTower and close the towerMenu
                        selectedTower = Towers.SniperTower;
                        openTowerMenu = false;
                    }
                    else if (buffButton.Clicked(mState, prevMState) &&
                    totalMoney >= towerCost[2])
                    {
                        //select the buffTower and close the towerMenu
                        selectedTower = Towers.BuffTower;
                        openTowerMenu = false;
                    }
                    else if (gatekeeperButton.Clicked(mState, prevMState) &&
                    totalMoney >= towerCost[3])
                    {
                        //select the gatekeeperTower and close the towerMenu
                        selectedTower = Towers.GatekeeperTower;
                        openTowerMenu = false;
                    }
                    else if (notErinButton.Clicked(mState, prevMState) &&
                    totalMoney >= towerCost[4])
                    {
                        //select the erinTower and close the towerMenu
                        selectedTower = Towers.ErinTower;
                        openTowerMenu = false;
                    }
                }

                //Next wave button clicked
                if (nextWaveButton.Clicked(mState,prevMState))
                {
                    NextWave();  
                }
            }

            //if the player is on the pause screen
            else if(gState == GameState.PauseScreen)
            {
                timeSpanSincePause = gameTime.TotalGameTime;
                //if the player hits escape
                if (SingleKeyPress(Keys.LeftControl) || SingleKeyPress(Keys.RightControl))
                {
                    //return to gameplay
                    gState = GameState.MapSelect;
                }
                //if the player hits escape
                else if (SingleKeyPress(Keys.Enter))
                {
                    //back to game play
                    gameTime.TotalGameTime = timeSpanSincePause;
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

        /// <summary>
        /// takes damage for the player and kills enemies that are off the map
        /// </summary>
        public void TakeDamage()
        {
            //for each enemy
            for(int i = 0; i < enemies.Count; i++)
            {
                //if the enemy is alive and off the map
                if(enemies[i].IsDead == false && (enemies[i].X > screenWidth
                    || enemies[i].X < -50))
                {
                    //reduce the player's health by one and kill the enemy to prevent repetition
                    health--;
                    enemyCount--;
                    enemies[i].IsDead = true;

                    i--;
                }
            }           
        }

        /// <summary>
        /// resets all variables for a new game
        /// (such as when the player returns to the map select)
        /// </summary>
        public void Reset()
        {
            //game variables
            selectedTower = Towers.None;
            openTowerMenu = false;
            placeTower = false;
            totalMoney = 100;
            gainMoney = 0;
            health = 20;
            waveAmount = 5;
            newWave = false;
            currWave = 0;

            //enemies and towers
            towers.Clear();
            enMan.ResetEnemies();
        }

        /// <summary>
        /// draws the level map
        /// </summary>
        public void DrawMap()
        {
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
                        new Point((tileHeight * j) + tileWidth / 2, (tileWidth * i) + tileHeight / 2),
                        new Point(tileWidth, tileHeight)),
                    rotations[(i * level.Width) + j]);
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

                    //Draws Potential Collision objects on the screen
                    level.Draw(_spriteBatch, textures[(level.Width * i) + j],
                    new Rectangle(
                        new Point((tileWidth * j) + tileWidth / 2, tileHeight * (i - level.Width) + tileHeight / 2),
                        new Point(tileWidth, tileHeight)), rotations[((i * level.Width) + j)]);
                }
            }

            for (int i = level.Width * 2; i < level.Width * 3; i++)
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
                        new Point((tileWidth * j) + tileWidth / 2, (tileHeight * (i - (level.Width * 2))) + tileHeight / 2),
                        new Point(tileWidth, tileHeight)), rotations[((i * level.Width) + j)]);
                }
            }

            //draws buttons
            towerMenuButton.Draw(_spriteBatch, mState);
            pauseButton.Draw(_spriteBatch, mState);
            nextWaveButton.Draw(_spriteBatch, mState);
            _spriteBatch.DrawString(arial16, "Money: $" + totalMoney,
                new Vector2(screenWidth - (300), 0),
                Color.White);
            _spriteBatch.DrawString(arial16, "Health: " + health,
                new Vector2(screenWidth - (450), 0),
                Color.White);
            _spriteBatch.DrawString(arial16, "Wave: " + currWave,
                new Vector2(screenWidth - (600), 0),
                Color.White);
            _spriteBatch.DrawString(arial16, "Number of Enemies: " + enemyCount,
                new Vector2(screenWidth - (600), 40),
                Color.White);
            //prints info about the player's selected tower to the screen
            switch (selectedTower)
            {
                case Towers.BaseTower:
                    _spriteBatch.DrawString(arial16, "Held Tower: Doot Skeleton",
                        new Vector2(screenWidth - (350), 40),
                        Color.White);
                    break;
                case Towers.SniperTower:
                    _spriteBatch.DrawString(arial16, "Held Tower: Sniper Monke",
                        new Vector2(screenWidth - (350), 40),
                        Color.White);
                    break;
                case Towers.BuffTower:
                    _spriteBatch.DrawString(arial16, "Held Tower: Buff Doge",
                        new Vector2(screenWidth - (350), 40),
                        Color.White);
                    break;
                case Towers.GatekeeperTower:
                    _spriteBatch.DrawString(arial16, "Held Tower: Ryan the Gatekeeper",
                        new Vector2(screenWidth - (350), 40),
                        Color.White);
                    break;
                case Towers.ErinTower:
                    _spriteBatch.DrawString(arial16, "Held Tower: Not Erin",
                        new Vector2(screenWidth - (350), 40),
                        Color.White);
                    break;
            }
        }

        /// <summary>
        /// resolves the effects of shooting
        /// </summary>
        /// <param name="gameTime"></param>
        public void ResolveShot(GameTime gameTime)
        {
            if (towers.Count > 0 /*&& gameTime.TotalGameTime.Milliseconds % 1500 < 1*/)
            {
                for (int i = 0; i < towers.Count; i++)
                {
                    gainMoney = towerManager.Shoot(towers[i], enemies);
                    totalMoney += gainMoney;
                    if(gainMoney != 0)
                    {
                        bruhEffect.Play(0.005f, -0.05f, 0);
                    }
                    enemyCount -= gainMoney; //since 1 money is gained for 1 enemy dying
                }
            }
        }

        /// <summary>
        /// draws the tower menu
        /// </summary>
        public void DrawTowerMenu()
        {
            //draw the towerMenu if it is open
            if (openTowerMenu == true)
            {
                _spriteBatch.Draw(towerMenuSprite, towerMenuPos, Color.White);
                _spriteBatch.DrawString(arial10, " Tower  Cost  Salary",
                    new Vector2(screenWidth - (tileWidth * 3), tileHeight),
                    Color.White);
                //Doot Skeleton
                _spriteBatch.DrawString(arial16, $"  {towerCost[0]}  {towerCost[0]/salaryDivider}",
                    new Vector2(screenWidth - (tileWidth * 2),
                    tileHeight * 2),
                    Color.White);
                baseTowerButton.Draw(_spriteBatch, mState);
                //Sniper Monke
                _spriteBatch.DrawString(arial16, $"  {towerCost[1]}  {towerCost[1] / salaryDivider}",
                    new Vector2(screenWidth - (tileWidth * 2),
                    tileHeight * 3),
                    Color.White);
                sniperButton.Draw(_spriteBatch, mState);
                //Buff Doge
                _spriteBatch.DrawString(arial16, $"  {towerCost[2]}  {towerCost[2] / salaryDivider}",
                    new Vector2(screenWidth - (tileWidth * 2),
                    tileHeight * 4),
                    Color.White);
                buffButton.Draw(_spriteBatch, mState);
                //Ryan the Gatekeeper
                _spriteBatch.DrawString(arial16, $"  {towerCost[3]}  {towerCost[3] / salaryDivider}",
                    new Vector2(screenWidth - (tileWidth * 2),
                    tileHeight * 5),
                    Color.White);
                gatekeeperButton.Draw(_spriteBatch, mState);
                //Not Erin
                _spriteBatch.DrawString(arial10, $"  {towerCost[4]}  {towerCost[4] / salaryDivider}",
                    new Vector2(screenWidth - (tileWidth * 2),
                    tileHeight * 6),
                    Color.White);
                notErinButton.Draw(_spriteBatch, mState);
            }
        }

        /// <summary>
        /// loads the sprites for all the buttons
        /// </summary>
        public void LoadButtons()
        {
            //map select buttons
            mapSelectButton1.DefaultSprite = Content.Load<Texture2D>("testMap1");
            mapSelectButton1.ActiveSprite = Content.Load<Texture2D>("testMap1");
            //gameplay UI buttons
            towerMenuButton.DefaultSprite = Content.Load<Texture2D>("Textures/towerDefense_tile087");
            towerMenuButton.ActiveSprite = Content.Load<Texture2D>("Textures/towerDefense_tile091");
            pauseButton.DefaultSprite = Content.Load<Texture2D>("Textures/towerDefense_tile085");
            pauseButton.ActiveSprite = Content.Load<Texture2D>("Textures/towerDefense_tile089");
            nextWaveButton.DefaultSprite = Content.Load<Texture2D>("NextWaveButton");
            nextWaveButton.ActiveSprite = Content.Load<Texture2D>("NextWaveButtonActive");
            //tower buttons
            baseTowerButton.DefaultSprite = Content.Load<Texture2D>("Textures/towerDefense_tile291");
            baseTowerButton.ActiveSprite = Content.Load<Texture2D>("Textures/towerDefense_tile291");
            sniperButton.DefaultSprite = Content.Load<Texture2D>("Textures/towerDefense_tile292");
            sniperButton.ActiveSprite = Content.Load<Texture2D>("Textures/towerDefense_tile292");
            buffButton.DefaultSprite = Content.Load<Texture2D>("towerDefense_tile204");
            buffButton.ActiveSprite = Content.Load<Texture2D>("towerDefense_tile204");
            gatekeeperButton.DefaultSprite = Content.Load<Texture2D>("Textures/towerDefense_tile250");
            gatekeeperButton.ActiveSprite = Content.Load<Texture2D>("Textures/towerDefense_tile250");
            notErinButton.DefaultSprite = Content.Load<Texture2D>("Textures/towerDefense_tile205");
            notErinButton.ActiveSprite = Content.Load<Texture2D>("Textures/towerDefense_tile205");
            //other buttons
            erinModeButton.DefaultSprite = Content.Load<Texture2D>("ErinModeOFF");
            erinModeButton.ActiveSprite = Content.Load<Texture2D>("ErinModeOFFActive");
        }

        /// <summary>
        /// triggers the next wave
        /// </summary>
        public void NextWave()
        {

            //checks if all the enemies in the enemies
            //list are dead
            if (enMan.AllEnemiesDead())
            {
                newWave = true;
                //increment the wave
                currWave += 1;
                //reset the enemy list
                enMan.ResetEnemies();

                //check for resignations (which
                //adds an enemy to the list)
                towerManager.Resignations(towers,
                    enemies, enemyTex, collisions.StartPosition);

                enemies = waveMan.Waves[currWave];

                enMan.Enemies = enemies;

                //changes the display to the current
                //amount of enemies in the list
                enemyCount = enemies.Count;
                //increments the # of enemies
                //for next time
                waveAmount += 5;
            }
        }

        /// <summary>
        /// writes out the game instructions to the screen
        /// </summary>
        public void DrawInstructions()
        {
            string instructions = "Welcome to Bruh Overtime Defense! Protect your workforce by paying " +
                "towers to \nstop the intrusive bruhs from reaching your office at the end of the " +
                "path.\n\n";
            instructions += "Use the Tower Menu in the top right to click on your tower, then click " +
                "again on the \nfield to place it. This costs money, which you get when your towers " +
                "automatically \nshoot the bruhs. Clicking this button while a tower is selected " +
                "also deselects that \ntower.\n\n";
            instructions += "Your towers also have to be paid a salary every few waves, " +
                "which you can do by \nclicking on each tower and pressing the pay button. " +
                "Failing to pay this salary \ncauses the tower to leave and spawn more bruhs " +
                "in retaliation.\n\n";
            instructions += "When your defenses are set up, hit the Next Wave button to let the bruhs " +
                "flow in. \n\nGood luck.";

            _spriteBatch.DrawString(arial16, instructions, new Vector2(20, 100), Color.White);
        }

        /// <summary>
        /// pays a tower's salary if it's clicked on
        /// </summary>
        public void PayTowers()
        {
            //for each tower
            for(int i = 0; i < towers.Count; i++)
            {
                //if the tower is clicked
                if(towers[i].Clicked(mState, prevMState))
                {
                    //if your money is greater than their salary
                    if(totalMoney >= (int)towers[i].OriginalSalary/salaryDivider)
                    {
                        //pay the salary
                        towerManager.SalaryPaid(towers[i]);
                        totalMoney -= (int)towers[i].OriginalSalary/salaryDivider;
                    }
                }
            }
        }
    }
}
