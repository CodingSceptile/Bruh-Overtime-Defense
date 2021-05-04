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
        Tutorial,
        MapSelect,
        InstructionsScreen,
        Gameplay,
        PauseScreen,
        VictoryScreen,
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
        //FIELDS///////////////////////////////////////////////////////////////////////
        //base MonoGame
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        //Level information and objects
        private Level level;
        private List<string> codes;
        private List<float> rotations;

        //Height and width of the tiles
        private int tileHeight;
        private int tileWidth;

        //screen size
        private int screenWidth;
        private int screenHeight;

        //mouse and keyboard states
        private MouseState mState;
        private MouseState prevMState;
        private KeyboardState kState;
        private KeyboardState prevKState;

        //game state
        private GameState gState;

        //Textures
        private List<Texture2D> textures;

        //buttons
        private Button mapSelectButton1;
        private Button mapSelectButton2;
        private Button mapSelectButton3;
        private Button mapSelectButton4;
        private Button towerMenuButton;
        private Button pauseButton;
        private Button nextWaveButton;
        private Button baseTowerButton;
        private Button sniperButton;
        private Button buffButton;
        private Button gatekeeperButton;
        private Button notErinButton;
        private Button erinModeButton;
        private Button okButton;
        private Button salaryButton;
        private Button fireButton;
        private Button priorityButton;
        private bool isErinMode;

        //SpriteFonts
        private SpriteFont arial10;
        private SpriteFont arial16;
        private SpriteFont arial36;
        private SpriteFont arial64;
        private SpriteFont gameText36;
        private SpriteFont gameText20;

        //sound effects
        private SoundEffect bruhEffect;
        private SoundEffect samiBruh;
        private SoundEffect mukundBruh;
        private SoundEffect calebBruh;
        private SoundEffect londonBruh;

        //Collisions
        private CollisionManager collisions;

        //Enemies
        private EnemyManager enMan;
        private Texture2D enemyTex;
        private Texture2D red;
        private Texture2D blue;
        private Texture2D green;
        private Texture2D hurb;
        private Texture2D waitingTexture;
        private List<Enemy> enemies;
        private float enemySpeed;
        private int enemyHealth;
        private int enemyCount;

        //Towers
        private List<Tower> towers;
        private TowerManager towerManager;
        private Towers selectedTower;
        private Texture2D radius;
        private Texture2D towerMenuSprite;
        private Rectangle towerMenuPos;
        private bool openTowerMenu;
        private bool placeTower;
        private int[] towerRadii;
        private int[] towerCost;
        private int[] towerSpeed;
        private int salaryDivider;

        //Waves
        private WaveManager waveMan;
        private bool newWave;
        private int currWave;
        private int waveAmount;

        //Animation manager
        private AnimationManager aniMan;
        private Texture2D sky;
        private Texture2D buildings;
        private Texture2D nightSky;

        //player stats
        private int totalMoney;
        private int gainMoney;
        private int health;

        //Music
        private Song victory;
        private Song lose;
        private Song gameSong;
        private Song titleSong;
        private SoundManager soundMan;
        private bool soundPlaying;


        //misc
        private Random random;
        private TimeSpan timeSpanSincePause;
        private Texture2D uiInstructions;
        private int instructionsPage;
        private List<bool> towerRollover;
        private int rolledOverTower;

        //track locations (for user feedback)
        private List<Rectangle> trackLocs;
        private Color validPlaceForTower;

        //tutorial
        private TutorialManager tutMan;
        private int tutorialPhase;
        private Texture2D tutorialBG;
        private Texture2D options;
        private Texture2D towerIcon;
        private Texture2D dootSprite;
        private Texture2D sniperSprite;
        private Texture2D dogeSprite;
        private Texture2D ryanSprite;
        private Texture2D erinSprite;

        private bool firstEnemySpawned;
        //MONOGAME GAME LOOP METHODS////////////////////////////////////////
        
        /// <summary>
        /// creates the game; not modified by The Other Group
        /// </summary>
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
            //initialize screen sizes
            _graphics.PreferredBackBufferWidth = 800;
            _graphics.PreferredBackBufferHeight = 800;
            screenWidth = _graphics.PreferredBackBufferWidth;
            screenHeight = _graphics.PreferredBackBufferHeight;

            //initialize tile sizes
            tileWidth = screenWidth / 20;
            tileHeight = screenHeight / 20;

            //initialize the mouse and keyboard states
            mState = Mouse.GetState();
            prevMState = Mouse.GetState();
            kState = Keyboard.GetState();
            prevKState = Keyboard.GetState();

            //set game state to title screen
            gState = GameState.TitleScreen;

            //initialize the buttons to where they'll be during gameplay
            //map select buttons
            mapSelectButton1 = new Button(50, 150, 200, 200);
            mapSelectButton2 = new Button(300, 150, 200, 200);
            mapSelectButton3 = new Button(550, 150, 200, 200);
            mapSelectButton4 = new Button(50, 450, 200, 200);
            //menu buttons
            erinModeButton = new Button(screenWidth - (tileWidth * 2),
                0, tileWidth * 2, tileHeight);
            nextWaveButton = new Button(screenWidth - (tileWidth * 4) - 10,
                0, tileWidth * 2, tileHeight);
            towerMenuButton = new Button(screenWidth - (tileWidth * 2) - 5, 
                0, tileWidth, tileHeight);
            pauseButton = new Button(screenWidth - tileWidth,
                0, tileWidth, tileHeight);
            salaryButton = new Button(0, 0, tileWidth * 2, tileHeight - 3);
            fireButton = new Button(0, 0, tileWidth * 2, tileHeight - 3);
            priorityButton = new Button(0, 0, tileWidth * 3 - 6, tileHeight);
            //tower buttons
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

            okButton = new Button((screenWidth / 4) + 35,
                ((2 * screenHeight) / 3) + 100, 300, 100);
            
            //the position of the Tower Menu
            towerMenuPos = new Rectangle(screenWidth - (tileWidth * 3),
                tileHeight, tileWidth * 3, tileHeight * 6);

            //initialize textures as an empty list
            textures = new List<Texture2D>();

            //initialize enemies and related
            enemies = new List<Enemy>();
            enemyCount = 0;

            //initialize towers and related
            towers = new List<Tower>();
            placeTower = false;
            selectedTower = Towers.None;

            //arrays store values for towers
            //indices correspond to towers as follows:
            //0: Doot Skeleton, 1: Sniper Monke, 2: Buff Doge
            //3: Ryan the Gatekeeper, 4: Not Erin
            towerRadii = new int[] { 130, int.MaxValue, 80, 100, 100 };
            towerCost = new int[] { 20, 40, 60, 80, 200 };
            towerSpeed = new int[] { 3, 6, 1, 1, 1};
            salaryDivider = 4;

            //initialize waves and related
            newWave = false;
            currWave = 0;
            waveAmount = 0;

            //initialize player stats
            totalMoney = 100;
            gainMoney = 0;
            health = 10;

            //Tutorial logic
            firstEnemySpawned = false;

            //misc
            random = new Random();
            openTowerMenu = false;
            isErinMode = false;
            instructionsPage = 0;
            towerRollover = new List<bool>();
            rolledOverTower = -1;

            validPlaceForTower = Color.Green;
            
            //MonoGame stuff
            _graphics.ApplyChanges();

            base.Initialize();
        }

        /// <summary>
        /// Loads the Textures, and assigns them to respective lists
        /// </summary>
        protected override void LoadContent()
        {
            //MonoGame SpriteBatch
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            //buttons
            LoadButtons();

            //load other things
            bruhEffect = Content.Load<SoundEffect>("Music/bruhEffectnew");
            samiBruh = Content.Load<SoundEffect>("Music/samiBruh");
            mukundBruh = Content.Load<SoundEffect>("Music/mukundBruh");
            calebBruh = Content.Load<SoundEffect>("Music/calebBruh");
            londonBruh = Content.Load<SoundEffect>("Music/londonBruh");

            towerMenuSprite = Content.Load<Texture2D>("Textures/towerSelector");
            uiInstructions = Content.Load<Texture2D>("Textures/BOD UI instructions");

            //SpriteFonts
            arial10 = Content.Load<SpriteFont>("Fonts/arial10");
            arial16 = Content.Load<SpriteFont>("Fonts/arial16");
            arial36 = Content.Load<SpriteFont>("Fonts/arial36");
            arial64 = Content.Load<SpriteFont>("Fonts/arial64");
            gameText36 = Content.Load<SpriteFont>("Fonts/gameFont");
            gameText20 = Content.Load<SpriteFont>("Fonts/gameText20");

            //Bruh enemy texture
            enemyTex = Content.Load<Texture2D>("Textures/bruh");
            red = Content.Load<Texture2D>("Textures/bruhRed");
            blue = Content.Load<Texture2D>("Textures/bruhBlue");
            green = Content.Load<Texture2D>("Textures/bruhGreen");
            hurb = Content.Load<Texture2D>("Textures/hurb");
            waitingTexture = Content.Load<Texture2D>("Textures/waitingRoom");

            //title textures
            sky = Content.Load<Texture2D>("Textures/Sky-layer");
            buildings = Content.Load<Texture2D>("Textures/buildings-layer");
            nightSky = Content.Load<Texture2D>("Textures/Ruined City Background Preview");

            //Songs
            victory = Content.Load<Song>("Music/Victory!");
            lose = Content.Load<Song>("Music/Icy Game Over");
            titleSong = Content.Load<Song>("Music/8_bit_iced_village_lofi");
            gameSong = Content.Load<Song>("Music/ChillLofiR");



            //animation manager
            aniMan = new AnimationManager(sky, buildings, nightSky,
                _graphics.PreferredBackBufferWidth, _graphics.PreferredBackBufferHeight);

            //Sound Manager
            soundMan = new SoundManager(bruhEffect, titleSong, gameSong, victory, lose,
                samiBruh, mukundBruh, londonBruh, calebBruh);

            //tutorial manager
            tutorialBG = Content.Load<Texture2D>("Textures/tutorialBackground");
            options = Content.Load<Texture2D>("Textures/OptionsButton");
            towerIcon = Content.Load<Texture2D>("Textures/TowerButton");
            dootSprite = Content.Load<Texture2D>("Textures/towerDefense_tile291");
            sniperSprite = Content.Load<Texture2D>("Textures/towerDefense_tile292");
            dogeSprite = Content.Load<Texture2D>("Textures/towerDefense_tile204");
            ryanSprite = Content.Load<Texture2D>("Textures/towerDefense_tile250");
            erinSprite = Content.Load<Texture2D>("Textures/towerDefense_tile205");

            tutMan = new TutorialManager(okButton, gameText20,
                tutorialBG, options, towerIcon, dootSprite,
                sniperSprite, dogeSprite, ryanSprite, erinSprite);

            //Tower radius
            radius = Content.Load<Texture2D>("Textures/radius");
        }

        /// <summary>
        /// Updates the game logic once per frame
        /// </summary>
        /// <param name="gameTime"></param>
        protected override void Update(GameTime gameTime)
        {
            //MonoGame: escape exits the game
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed 
                || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            //get the current MouseState and KeyboardState (first thing to be done)
            mState = Mouse.GetState();
            kState = Keyboard.GetState();

            //shortcuts to view game over and victory screens
            if (Keyboard.GetState().IsKeyDown(Keys.G))
            {
                soundPlaying = false;
                gState = GameState.GameOver;
            }
            else if (Keyboard.GetState().IsKeyDown(Keys.V))
            {
                gState = GameState.VictoryScreen;
                soundPlaying = false;
            }

            //check the game state and see if it needs to be moved
            FiniteStateMachine(gameTime);

            //make the current state the previous state (last thing to be done)
            prevMState = mState;
            prevKState = kState;

            //MonoGame: update the game with gameTime
            base.Update(gameTime);
        }

        /// <summary>
        /// Draws all necessary assets to the screen
        /// </summary>
        /// <param name="gameTime"></param>
        protected override void Draw(GameTime gameTime)
        {
            //MonoGame: sets the default background to blue
            GraphicsDevice.Clear(Color.CornflowerBlue);

            //begin the SpriteBatch
            _spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend);

            //draws different things based on the game state
            switch (gState)
            {
                //TITLE SCREEN
                case GameState.TitleScreen:
                    //animate the parallax background
                    aniMan.Draw(_spriteBatch);

                    //draw the title and starting instructions
                    _spriteBatch.DrawString(gameText36, "Bruh Overtime \n   Defense", new Vector2(75, 250), Color.Gray);
                    _spriteBatch.DrawString(gameText36, "Bruh Overtime \n   Defense", new Vector2(78, 253), Color.Black);
                    _spriteBatch.DrawString(gameText20, "Press Enter to start", new Vector2(130, 450), Color.Black);

                    break;

                case GameState.Tutorial:
                    aniMan.Draw(_spriteBatch);
                    break;

                //MAP SELECT SCREEN
                case GameState.MapSelect:
                    //animate the parallax background
                    aniMan.Draw(_spriteBatch);

                    //draw the header and base instructions
                    _spriteBatch.DrawString(gameText36, "Map Select", new Vector2(135, 25), Color.Black);
                    _spriteBatch.DrawString(gameText20, "     Press Enter to view \n        Instructions",
                        new Vector2(0, 700), Color.Black);

                    //draw the map select buttons
                    mapSelectButton1.Draw(_spriteBatch, mState);
                    _spriteBatch.DrawString(gameText20, "Office 1", new Vector2(50, 360), Color.Black);

                    mapSelectButton2.Draw(_spriteBatch, mState);
                    _spriteBatch.DrawString(gameText20, "Office 2", new Vector2(310, 360), Color.Black);

                    mapSelectButton3.Draw(_spriteBatch, mState);
                    _spriteBatch.DrawString(gameText20, "Office 3", new Vector2(560, 360), Color.Black);

                    mapSelectButton4.Draw(_spriteBatch, mState);
                    _spriteBatch.DrawString(gameText20, "Office 4", new Vector2(50, 660), Color.Black);

                    //draw the ErinMode button
                    erinModeButton.Draw(_spriteBatch, mState);
                    
                    break;

                //INSTRUCTIONS SCREEN
                case GameState.InstructionsScreen:
                    aniMan.Draw(_spriteBatch);
                    //draw the instructions
                    _spriteBatch.DrawString(gameText36, "Instructions", new Vector2(100, 25), Color.Black);
                    DrawInstructions();
                    if(instructionsPage == 0)
                    {
                        _spriteBatch.Draw(uiInstructions, new Rectangle(250, 420, 220, 220), Color.White);
                    }
                    _spriteBatch.DrawString(arial36, "Press Enter to change page",
                        new Vector2(75, 660), Color.Black);
                    _spriteBatch.DrawString(arial36, "Press Ctrl to return to Map Select", 
                        new Vector2(25, 720), Color.Black);

                    break;

                //GAMEPLAY SCREEN
                case GameState.Gameplay:
                    //draw the map and tower menu
                    DrawMap();

                    //constructs a rectangle where the mouse currently is,
                    //sizes it to the size of the tower selected
                    Rectangle currMousePos = new Rectangle(
                                    new Point(mState.Position.X - 20,
                                    mState.Position.Y - 20),
                                    new Point(40,
                                    40));

                    //Gets another rectangle for collisions with the mouse
                    Rectangle mouseCheck = new Rectangle(
                        mState.Position, new Point(1, 1));

                    int radius = 0;

                    //Checks if there is an intersection with any
                    //of the track rectangles, if so, it changes the color
                    //to red instead of green, indicating that the player
                    //cannot place a tower in that given area
                    foreach (Rectangle r in trackLocs)
                    {
                        {
                            if (r.Intersects(mouseCheck))
                            {
                                validPlaceForTower = Color.Red;
                                break;
                            }
                            else
                            {
                                validPlaceForTower = Color.Green;
                            }
                        }
                    }

                    //draw the selected tower to the mouse
                    //cursor
                    switch (selectedTower)
                    {
                        //BASE TOWER
                        case Towers.BaseTower:
                            _spriteBatch.Draw(baseTowerButton.DefaultSprite,
                                currMousePos, 
                                validPlaceForTower);

                            radius = towerRadii[0];
                            break;
                        //SNIPER TOWER
                        case Towers.SniperTower:
                            _spriteBatch.Draw(sniperButton.DefaultSprite,
                                currMousePos,
                                validPlaceForTower);

                            radius = towerRadii[1];
                            break;

                        //BUFF TOWER
                        case Towers.BuffTower:
                            _spriteBatch.Draw(buffButton.DefaultSprite,
                                currMousePos,
                                validPlaceForTower);

                            radius = towerRadii[2];
                            break;
                        //GATEKEEPER TOWER
                        case Towers.GatekeeperTower:
                            _spriteBatch.Draw(gatekeeperButton.DefaultSprite,
                                currMousePos,
                                validPlaceForTower);

                            radius = towerRadii[3];
                            break;
                        //NOT_ERIN Tower
                        case Towers.ErinTower:
                            _spriteBatch.Draw(notErinButton.DefaultSprite,
                                currMousePos,
                                validPlaceForTower);

                            radius = towerRadii[4];
                            break;
                    }

                    

                    //Maneuvring to get shapebatch to work
                    _spriteBatch.End();
                    ShapeBatch.Begin(_graphics.GraphicsDevice);

                    //draws the radius of the tower
                    ShapeBatch.CircleOutline(new Vector2(mState.Position.X,
                        mState.Position.Y),
                        radius,
                        validPlaceForTower);

                    ShapeBatch.End();
                    _spriteBatch.Begin();

                    PlaceTower(gameTime);

                    //draw the towers
                    towerManager.DrawTowers(_spriteBatch, arial10, enemies, _graphics);

                    //Only spawns new enemies if a new wave is active
                    if (newWave == true)
                    {
                        enMan.Update(gameTime);
                        enMan.Draw(_spriteBatch);
                    }

                    if (collisions.LevelName == "tutorialFixed.level_Appended")
                    {
                        TutorialDraw(_spriteBatch);
                    }

                    //mark the tower that is being rolled over
                    rolledOverTower = CheckTowerRollover();

                    DrawTowerMenu();
                    break;

                //PAUSE SCREEN
                case GameState.PauseScreen:
                    aniMan.Draw(_spriteBatch);
                    //draw the header and instructions
                    _spriteBatch.DrawString(gameText36, "Paused",
                        new Vector2(240, 30), Color.Black);
                    DrawInstructions();
                    _spriteBatch.DrawString(arial36, "Press Enter to return to game",
                        new Vector2(80, 490), Color.Black);
                    _spriteBatch.DrawString(arial36, "Press Ctrl to return to map select",
                        new Vector2(50, 600), Color.Black);
                    break;

                //VICTORY SCREEN
                case GameState.VictoryScreen:
                    aniMan.Draw(_spriteBatch);
                    //draw the header and base instructions
                    _spriteBatch.DrawString(gameText36, "VICTORY!!!",
                        new Vector2(160, 300), Color.Green);
                    _spriteBatch.DrawString(gameText20, "Press Enter to return to map select",
                        new Vector2(25, 450), Color.Green);

                    break;

                //GAME OVER SCREEN
                case GameState.GameOver:
                    aniMan.DrawGameOver(_spriteBatch);
                    //draw the header and base instructions
                    _spriteBatch.DrawString(gameText36, "Game Over",
                        new Vector2(180, 300), Color.Red);
                    _spriteBatch.DrawString(gameText20, "Press Enter to return to map select",
                        new Vector2(25, 450), Color.Red);
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
                if(soundPlaying == false)
                {
                    soundMan.PlayTitle();
                    soundPlaying = true;
                }

                //if the player hits enter or space
                if(SingleKeyPress(Keys.Enter) || SingleKeyPress(Keys.Space))
                {
                    //go to tutorial level
                    tutorialPhase = 0;
                    gState = GameState.Tutorial;
                }
            }
            else if(gState == GameState.Tutorial)
            {
                InitializeCollisions("tutorialFixed.level_Appended");

                Reset();

                totalMoney = 20;    
                //go to the gameplay state
                gState = GameState.Gameplay;
                soundPlaying = false;
            }
            //if the player is on the map select screen
            else if(gState == GameState.MapSelect)
            {
                if(soundPlaying == false)
                {
                    soundMan.PlayTitle();
                    soundPlaying = true;
                }

                //check to see which map button they pressed
                if (mapSelectButton1.Clicked(mState, prevMState))
                {
                    InitializeCollisions("newMap2FIXED.level_Appended");
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
                    soundPlaying = false;
                }
                //check to see which map button they pressed
                else if (mapSelectButton2.Clicked(mState, prevMState))
                {
                    InitializeCollisions("map3Fixed.level_Appended");
                    //reset the game
                    Reset();
                    //if Erin Mode is on
                    if (isErinMode == true)
                    {
                        //massively increase health and money
                        health = 9999;
                        totalMoney = 9999;
                    }

                    //go to the gameplay state
                    gState = GameState.Gameplay;
                    soundPlaying = false;
                }

                //Second map select button pressed
                else if(mapSelectButton3.Clicked(mState, prevMState))
                {
                    InitializeCollisions("map4Fixed.level_Appended");
                    //reset the game
                    Reset();
                    //if Erin Mode is on
                    if (isErinMode == true)
                    {
                        //massively increase health and money
                        health = 9999;
                        totalMoney = 9999;
                    }

                    //go to the gameplay state
                    gState = GameState.Gameplay;
                    soundPlaying = false;
                }

                //third map select button pressed
                else if (mapSelectButton3.Clicked(mState, prevMState))
                {
                    InitializeCollisions("map4Fixed.level_Appended");
                    //reset the game
                    Reset();
                    //if Erin Mode is on
                    if (isErinMode == true)
                    {
                        //massively increase health and money
                        health = 9999;
                        totalMoney = 9999;
                    }

                    //go to the gameplay state
                    gState = GameState.Gameplay;
                    soundPlaying = false;
                }

                //fourth map select button pressed
                else if (mapSelectButton4.Clicked(mState, prevMState))
                {
                    InitializeCollisions("map5Fixed3.level_Appended");
                    //reset the game
                    Reset();
                    //if Erin Mode is on
                    if (isErinMode == true)
                    {
                        //massively increase health and money
                        health = 9999;
                        totalMoney = 9999;
                    }

                    //go to the gameplay state
                    gState = GameState.Gameplay;
                    soundPlaying = false;
                }

                //if the ErinModeButton is clicked when ErinMode is off
                if (erinModeButton.Clicked(mState, prevMState) && isErinMode == false)
                {
                    //turn on Erin Mode and change the button look
                    isErinMode = true;
                    erinModeButton.DefaultSprite = Content.Load<Texture2D>("Textures/ErinModeON");
                    erinModeButton.ActiveSprite = Content.Load<Texture2D>("Textures/ErinModeONActive");
                }
                //if the ErinModeButton is clicked when ErinMode is on
                else if (erinModeButton.Clicked(mState, prevMState) && isErinMode == true)
                {
                    //turn off Erin Mode and change the button look
                    isErinMode = false;
                    erinModeButton.DefaultSprite = Content.Load<Texture2D>("Textures/ErinModeOFF");
                    erinModeButton.ActiveSprite = Content.Load<Texture2D>("Textures/ErinModeOFFActive");
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
                //change the instructions page by pressing enter
                if (SingleKeyPress(Keys.Enter) && instructionsPage == 0)
                {
                    instructionsPage = 1;
                }
                else if(SingleKeyPress(Keys.Enter) && instructionsPage == 1)
                {
                    instructionsPage = 2;
                }
                else if (SingleKeyPress(Keys.Enter) && instructionsPage == 2)
                {
                    instructionsPage = 0;
                }

                //if control is pressed, return to map select
                if (SingleKeyPress(Keys.LeftControl) || SingleKeyPress(Keys.RightControl))
                {
                    gState = GameState.MapSelect;
                }
            }
            //if the player is in gameplay
            else if(gState == GameState.Gameplay)
            {
                if(soundPlaying == false)
                {
                    soundMan.PlayGameTheme();
                    soundPlaying = true;
                }
                
                //checks if the tutorial level is active
                if(collisions.LevelName == "tutorialFixed.level_Appended")
                {
                    //progresses the tutorial when a
                    //user presses the ok button
                    if ((okButton.Clicked(mState, prevMState))
                        && !(tutorialPhase == 3) && !(tutorialPhase == 5)
                        && !(tutorialPhase == 12) && !(tutorialPhase == 14)
                        && !(tutorialPhase == 16) && !(tutorialPhase == 18))
                    {
                        tutorialPhase++;
                    }
                    //if the player hits the pause button
                    if (pauseButton.Clicked(mState, prevMState))
                    {
                        //pause the game
                        gState = GameState.PauseScreen;
                    }
                    //if the player hits left or right control
                    if (SingleKeyPress(Keys.LeftControl) || SingleKeyPress(Keys.RightControl))
                    {
                        //pause the game
                        gState = GameState.PauseScreen;
                    }
                    //if the player hits left or right control
                    if (SingleKeyPress(Keys.Back) || SingleKeyPress(Keys.Back))
                    {
                        //pause the game
                        gState = GameState.MapSelect;
                        soundPlaying = false;
                    }

                    //enables tower function on the
                    //third stage, when it is
                    //introduced
                    if (tutorialPhase == 3)
                    {
                        TowerFunction(gameTime);

                        if(towers.Count == 1 &&
                            !(tutorialPhase >= 4))
                        {
                            tutorialPhase++;
                        }
                    }
                    
                    //implements wave and enemy function
                    if(tutorialPhase == 5
                        || tutorialPhase == 12
                        || tutorialPhase == 14
                        || tutorialPhase == 16
                        || tutorialPhase == 18
                        || tutorialPhase == 23)
                    {
                        if(tutorialPhase == 5)
                        {
                            totalMoney = 0;
                        }
                        //Next wave button clicked
                        if (nextWaveButton.Clicked(mState, prevMState))
                        {
                            if(tutorialPhase != 23)
                            {
                                NextWave();
                            }
                            
                            if(firstEnemySpawned == false)
                            {
                                enemies[0].IsDead = false;
                                firstEnemySpawned = true;
                            }
                        }
                       
                        //Check for changes in movement
                        for (int i = 0; i < enemies.Count; i++)
                        {                           
                            if (enemies[i].IsDead == false)
                            {
                                collisions.LevelIntersects(enemies[i]);
                                enemies[i].X += (int)enemies[i].Movement.X;
                                enemies[i].Y += (int)enemies[i].Movement.Y;
                            }

                            if (enMan.AllEnemiesDead()
                                && tutorialPhase == 5 && currWave == 1)
                            {
                                tutorialPhase++;
                            }
                        }

                        TowerFunction(gameTime);
                        //Checks if the user needs to take damage
                        TakeDamage();
                    }

                    //stage that tells the user
                    //to pay salary
                    if(tutorialPhase == 7)
                    {
                        totalMoney = 5;
                    }
                    else if(tutorialPhase == 8)
                    {
                        TowerFunction(gameTime);
                        if(towers[0].Salary >= 20)
                        {
                            tutorialPhase++;
                            firstEnemySpawned = false;
                        }
                    }

                    //resets the waves, 
                    //spawns a few sniper monkes
                    //for demonstration.
                    else if(tutorialPhase == 12
                        || tutorialPhase == 14
                        || tutorialPhase == 16
                        || tutorialPhase == 18)
                    {
                        //Sniper monke being shown off
                        if(towers[0] is DootSkeleton)
                        {
                            //Resets the game (as if a 
                            //new game is starting)
                            Reset();
                            NextWave();

                            //spawns the first enemy immediately
                            if (firstEnemySpawned == false)
                            {
                                enemies[0].IsDead = false;
                                firstEnemySpawned = true;
                            }
                            
                            //sets the total money to 0,
                            //spawns a singular tower
                            totalMoney = 0;
                            towers.Add(new SniperMonke
                            (new Rectangle(new Point(500, 300),
                            new Point(tileWidth, tileHeight)),
                            sniperSprite, towerRadii[1], 40, towerSpeed[1],
                            gameTime, radius));
                            towerRollover.Add(false);
                        }

                        //buff doge showoff
                        else if(towers[0] is SniperMonke
                            && tutorialPhase == 14)
                        {
                            Reset();
                            NextWave();
                            firstEnemySpawned = false;

                            enemies[0].IsDead = false;

                            totalMoney = 0;

                            towers.Add(new BuffDoge
                            (new Rectangle(new Point(350, 325),
                            new Point(tileWidth, tileHeight)),
                            dogeSprite, towerRadii[2], 40, towerSpeed[2],
                            gameTime, radius));
                            towerRollover.Add(false);
                        }

                        //ryan showoff
                        else if (towers[0] is BuffDoge
                            && tutorialPhase == 16)
                        {
                            Reset();
                            NextWave();
                            firstEnemySpawned = false;

                            enemies[0].IsDead = false;

                            totalMoney = 0;

                            towers.Add(new RyanTheGateKeeper
                            (new Rectangle(new Point(350, 325),
                            new Point(tileWidth, tileHeight)),
                            ryanSprite, towerRadii[3], 40, towerSpeed[2],
                            gameTime, radius, waitingTexture));
                            towerRollover.Add(false);
                        }

                        //Erin showoff
                        else if (towers[0] is RyanTheGateKeeper
                            && tutorialPhase == 18)
                        {
                            Reset();
                            NextWave();
                            firstEnemySpawned = false;

                            enemies[0].IsDead = false;

                            totalMoney = 0;

                            towers.Add(new Not_Erin
                            (new Rectangle(new Point(350, 325),
                            new Point(tileWidth, tileHeight)),
                            erinSprite, towerRadii[4], 40, towerSpeed[2],
                            gameTime, radius));
                            towerRollover.Add(false);
                        }

                        if (enMan.AllEnemiesDead() && currWave == 1)
                        {
                            tutorialPhase++;
                        }
                    }

                    //Showcases each of the bruhs
                    else if(tutorialPhase == 23)
                    {
                        soundPlaying = false;
                        gState = GameState.MapSelect;
                    }
                }
                else
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

                    TowerFunction(gameTime);

                    //Checks if the user needs to take damage
                    TakeDamage();


                    //No more health left! Game over!
                    if (health <= 0)
                    {
                        soundPlaying = false;
                        gState = GameState.GameOver;
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
                    

                    //Next wave button clicked
                    if (nextWaveButton.Clicked(mState, prevMState))
                    {
                        NextWave();
                    }

                    if (currWave == 21)
                    {
                        gState = GameState.VictoryScreen;
                        soundPlaying = false;
                    }
                }               
            }
            //if the player is on the pause screen
            else if(gState == GameState.PauseScreen)
            {
                instructionsPage = 0;
                timeSpanSincePause = gameTime.TotalGameTime;
                //if the player hits escape
                if (SingleKeyPress(Keys.LeftControl) || SingleKeyPress(Keys.RightControl))
                {
                    //return to gameplay
                    gState = GameState.MapSelect;
                    soundPlaying = false;
                }
                //if the player hits escape
                else if (SingleKeyPress(Keys.Enter))
                {
                    //back to game play
                    gameTime.TotalGameTime = timeSpanSincePause;
                    gState = GameState.Gameplay;
                }
            }
            //if the player is on the victory screen
            else if(gState == GameState.VictoryScreen)
            {
                if (soundPlaying == false)
                {
                    soundMan.PlayVictoryTheme();
                    soundPlaying = true;
                }

                //if they hit enter or space
                if (SingleKeyPress(Keys.Enter) || SingleKeyPress(Keys.Space))
                {
                    soundPlaying = false;
                    //return to the map select screen
                    gState = GameState.MapSelect;
                }
            }
            //if the player is on the game over screen
            else if(gState == GameState.GameOver)
            {
                if (soundPlaying == false)
                {
                    soundMan.PlayLoseTheme();
                    soundPlaying = true;
                }                
                //if they hit enter or space
                if (SingleKeyPress(Keys.Enter) || SingleKeyPress(Keys.Space))
                {
                    soundPlaying = false;
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
                    || enemies[i].X < -50 || enemies[i].Y > screenHeight || enemies[i].Y < -50))
                {
                    //reduce the player's health by the enemy's health 
                    //kill the enemy to prevent repetition
                    health -= enemies[i].Health;
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
            health = 50;
            waveAmount = 5;
            newWave = false;
            currWave = 0;
            enemyCount = 0;
            waveMan.GenerateBruhStats();
            towerRollover.Clear();

            //enemies and towers
            towers.Clear();
            enemies.Clear();
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
                new Vector2(screenWidth - (310), 0),
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
                        soundMan.PlayBruhSFX();
                        towers[i].MadeShot = true;
                    }
                    else
                    {
                        towers[i].MadeShot = false;
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

                //draw applicable tower instructions
                CheckMenuRollover();
            }
        }

        /// <summary>
        /// loads the sprites for all the buttons
        /// </summary>
        public void LoadButtons()
        {
            //map select buttons
            mapSelectButton1.DefaultSprite = Content.Load<Texture2D>("Textures/preview1");
            mapSelectButton1.ActiveSprite = Content.Load<Texture2D>("Textures/preview1");

            mapSelectButton2.DefaultSprite = Content.Load<Texture2D>("Textures/preview2");
            mapSelectButton2.ActiveSprite = Content.Load<Texture2D>("Textures/preview2");

            mapSelectButton3.DefaultSprite = Content.Load<Texture2D>("Textures/preview3");
            mapSelectButton3.ActiveSprite = Content.Load<Texture2D>("Textures/preview3");

            mapSelectButton4.DefaultSprite = Content.Load<Texture2D>("Textures/preview4");
            mapSelectButton4.ActiveSprite = Content.Load<Texture2D>("Textures/preview4");

            //gameplay UI buttons
            towerMenuButton.DefaultSprite = Content.Load<Texture2D>("Textures/towerButton");
            towerMenuButton.ActiveSprite = Content.Load<Texture2D>("Textures/towerButtonActive");
            pauseButton.DefaultSprite = Content.Load<Texture2D>("Textures/optionsButton");
            pauseButton.ActiveSprite = Content.Load<Texture2D>("Textures/optionsButtonActive");
            nextWaveButton.DefaultSprite = Content.Load<Texture2D>("Textures/NextWaveButton");
            nextWaveButton.ActiveSprite = Content.Load<Texture2D>("Textures/NextWaveButtonActive");
            salaryButton.DefaultSprite = Content.Load<Texture2D>("SalaryButton");
            salaryButton.ActiveSprite = Content.Load<Texture2D>("PaySalaryButton");
            fireButton.DefaultSprite = Content.Load<Texture2D>("FireTowerButton");
            fireButton.ActiveSprite = Content.Load<Texture2D>("FireTowerButtonActive");
            priorityButton.DefaultSprite = Content.Load<Texture2D>("PFirstButton");
            priorityButton.ActiveSprite = Content.Load<Texture2D>("PFirstButtonActive");

            //tower buttons
            baseTowerButton.DefaultSprite = Content.Load<Texture2D>("Textures/towerDefense_tile291");
            baseTowerButton.ActiveSprite = Content.Load<Texture2D>("Textures/towerDefense_tile291");
            sniperButton.DefaultSprite = Content.Load<Texture2D>("Textures/towerDefense_tile292");
            sniperButton.ActiveSprite = Content.Load<Texture2D>("Textures/towerDefense_tile292");
            buffButton.DefaultSprite = Content.Load<Texture2D>("Textures/towerDefense_tile204");
            buffButton.ActiveSprite = Content.Load<Texture2D>("Textures/towerDefense_tile204");
            gatekeeperButton.DefaultSprite = Content.Load<Texture2D>("Textures/towerDefense_tile250");
            gatekeeperButton.ActiveSprite = Content.Load<Texture2D>("Textures/towerDefense_tile250");
            notErinButton.DefaultSprite = Content.Load<Texture2D>("Textures/towerDefense_tile205");
            notErinButton.ActiveSprite = Content.Load<Texture2D>("Textures/towerDefense_tile205");


            //other buttons
            erinModeButton.DefaultSprite = Content.Load<Texture2D>("Textures/ErinModeOFF");
            erinModeButton.ActiveSprite = Content.Load<Texture2D>("Textures/ErinModeOFFActive");

            //Ok button
            okButton.DefaultSprite = Content.Load<Texture2D>("Textures/ok");
            okButton.ActiveSprite = Content.Load<Texture2D>("Textures/okActive");
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

                foreach(Tower tower in towers)
                {
                    if (tower is DootSkeleton)
                    {
                        totalMoney += 1;
                    }
                    else if (tower is SniperMonke)
                    {
                        totalMoney += 4;
                    }
                    else if(tower is BuffDoge)
                    {
                        totalMoney += 6;
                    }
                    else if(tower is RyanTheGateKeeper)
                    {
                        totalMoney += 8;
                    }
                    else if(tower is Not_Erin)
                    {
                        totalMoney += 10;
                    }
                }
                
                //reset the enemy list
                enMan.ResetEnemies();

                if (currWave == 21)
                {
                    return;
                }

                enemies = waveMan.Waves[currWave];

                enMan.Enemies = enemies;

                //check for resignations (which
                //adds an enemy to the list)

                towerManager.Resignations(towers,
                    enemies, blue, collisions.StartPosition, towerRollover);

                //changes the display to the current
                //amount of enemies in the list
                enemyCount = enemies.Count;
            }
        }

        /// <summary>
        /// writes out the game instructions to the screen
        /// </summary>
        public void DrawInstructions()
        {
            string instructions = "";
            //first instructions page
            if(instructionsPage == 0)
            {
                instructions = "Welcome to Bruh Overtime Defense! Protect your workforce by paying " +
                    "towers to \nstop the intrusive bruhs from reaching your office at the end of the " +
                    "path.\n\n";
                instructions += "Use the Tower Menu in the top right to click on your tower, then click " +
                    "again on the \nfield to place it. This costs money, which you get when your towers " +
                    "automatically \nshoot the bruhs. Clicking this button while a tower is selected " +
                    "also deselects that \ntower.\n\n";
                instructions += "Your towers also have to be paid a salary every wave, " +
                    "which you can do by \nclicking on a tower. " +
                    "Failing to pay this salary causes the tower to leave and \nspawn more bruhs " +
                    "in retaliation.\n\n";
                instructions += "When your defenses are set up, hit the Next Wave button to let the bruhs " +
                    "flow in. \n\nGood luck.";
                //draws the instructions to the screen
                _spriteBatch.DrawString(arial16, instructions, new Vector2(20, 100), Color.Black);
            }
            //second instructions page
            else if(instructionsPage == 1)
            {
                instructions = "There are five towers that you can use to defend yourself. Here's " +
                    "what they are \nand what they do.\n\n";
                instructions += "DOOT SKELETON: Fires bullets at a moderate speed in a moderate radius, " +
                    "dealing \none damage per shot. It can only hit a single bruh at once, but is the " +
                    "cheapest \ntower and has a low salary to boot.\n\n";
                instructions += "SNIPER MONKE: This tower has unlimited range and can shoot bruhs from " +
                    "\nanywhere on the map, although it's fire speed is somewhat slow.\n\n";
                instructions += "BUFF DOGE: Despite having a small radius, this tower can hit all " +
                    "bruhs in it's range \nat once, dealing damage across the board. It's attack speed " +
                    "is also fair, although it \nis a bit pricey.\n\n";
                instructions += "RYAN THE GATEKEEPER: Despite not dealing damage, this tower temporarily " +
                    "\nhalts enemies in place by placing them in the waiting room. It's speed is fair, but " +
                    "it's \nrange is very small, only stopping bruhs close by.\n\n";
                instructions += "NOT ERIN: This tower has moderate range, and is very expensive, but it " +
                    "vaporizes \nall bruhs in range at a decent speed, being just as quick as the " +
                    "DOOT SKELETON.\n\n";
                //draws the instructions to the screen
                _spriteBatch.DrawString(arial16, instructions, new Vector2(20, 100), Color.Black);
            }
            //third instructions page (credits)
            else if(instructionsPage == 2)
            {
                _spriteBatch.DrawString(gameText36, "Credits", new Vector2(230, 80), Color.White);
                _spriteBatch.DrawString(gameText20, "Main Programmers", new Vector2(200, 140), Color.White);
                _spriteBatch.DrawString(arial16, "Sami Chamberlain, London Emmerich, Caleb Jeon, Mukund Suresh",
                    new Vector2(100, 170), Color.White);

                _spriteBatch.DrawString(gameText20, "External Assets", new Vector2(200, 230), Color.White);
                _spriteBatch.DrawString(arial16, "ansimuz: Urban Landscape Background parallax",
                    new Vector2(100, 260), Color.White);
                _spriteBatch.DrawString(arial16, "Big Purp: Doot Skeleton image",
                    new Vector2(100, 290), Color.White);
                _spriteBatch.DrawString(arial16, "Chris Cascioli: ShapeBatch library",
                    new Vector2(100, 320), Color.White);
                _spriteBatch.DrawString(arial16, "Game Developer Studio: Sniper Rifle image",
                    new Vector2(100, 350), Color.White);
                _spriteBatch.DrawString(arial16, "jkfite01: Victory! song",
                    new Vector2(100, 380), Color.White);
                _spriteBatch.DrawString(arial16, "omfgdude: Chill Lofi Inspired song",
                    new Vector2(100, 410), Color.White);
                _spriteBatch.DrawString(arial16, "Sudocolon: Icy Game Over song",
                    new Vector2(100, 440), Color.White);
                _spriteBatch.DrawString(arial16, "TAD: Iced Village (8 Bit Lofi Hip Hop) song",
                    new Vector2(100, 470), Color.White);
                _spriteBatch.DrawString(arial16, "TokyoGeisha: Ruined City Background parallax",
                    new Vector2(100, 500), Color.White);

                _spriteBatch.DrawString(gameText20, "Special Thanks", new Vector2(200, 560), Color.White);
                _spriteBatch.DrawString(arial16, "Erin Cascioli, Ryan Ress",
                    new Vector2(250, 600), Color.White);
            }

            
        }

        /// <summary>
        /// initializes collisions whenever a new level is selected
        /// </summary>
        /// <param name="levelName">the name of the level</param>
        public void InitializeCollisions(string levelName)
        {
            //FROM INITIALIZE
            //creates the collisionManager
            collisions = new CollisionManager(levelName);


            //initializes the level, codes, and rotations from the collisions
            level = collisions.CurrentLevel;
            codes = collisions.Codes;
            rotations = collisions.Rotations;
            trackLocs = collisions.TrackLocations;

            //initialize managers
            enMan = new EnemyManager(enemies, collisions.StartPosition, arial10);
            waveMan = new WaveManager("enemyWaveFixed.wave",
                enemyTex, red, blue, green, hurb, collisions.StartPosition);

            towerManager = new TowerManager(towers, collisions.TrackLocations);

            textures.Clear();
            //FROM LOAD_CONTENT
            //Main level
            foreach (string code in codes)
            {
                //Loads a texture given the code(Located in the textures folder, basically
                //just the file name)
                Texture2D texture = Content.Load<Texture2D>("Textures/" + code);

                textures.Add(texture);
            }
        }

        /// <summary>
        /// determines whether a tower will be placed and what tower it will be
        /// </summary>
        public void PlaceTower(GameTime gameTime)
        {
            //if the player has a tower to place and clicks
            if (placeTower == true)
            {
                //draw the selected tower
                switch (selectedTower)
                {
                    //BASE TOWER
                    case Towers.BaseTower:
                        //add the tower to the list, position centered on the mouse, and pay the cost
                        towers.Add(new DootSkeleton(
                            new Rectangle(mState.X - tileWidth / 3, mState.Y - tileHeight / 3,
                            tileWidth, tileHeight),
                            baseTowerButton.DefaultSprite,
                            towerRadii[0], towerCost[0], towerSpeed[0], gameTime, radius));
                        totalMoney -= towerCost[0];
                        break;
                    //SNIPER TOWER
                    case Towers.SniperTower:
                        //add the tower to the list, position centered on the mouse, and pay the cost
                        towers.Add(new SniperMonke(
                            new Rectangle(mState.X - tileWidth / 3, mState.Y - tileHeight / 3,
                            tileWidth, tileHeight),
                            sniperButton.DefaultSprite,
                            towerRadii[1], towerCost[1], towerSpeed[1], gameTime, radius));
                        totalMoney -= towerCost[1];
                        break;
                    //BUFF TOWER
                    case Towers.BuffTower:
                        //add the tower to the list, position centered on the mouse, and pay the cost
                        towers.Add(new BuffDoge(
                            new Rectangle(mState.X - tileWidth / 3, mState.Y - tileHeight / 3,
                            tileWidth, tileHeight),
                            buffButton.DefaultSprite,
                            towerRadii[2], towerCost[2], towerSpeed[2], gameTime, radius));
                        totalMoney -= towerCost[2];
                        break;
                    //GATEKEEPER TOWER
                    case Towers.GatekeeperTower:
                        //add the tower to the list, position centered on the mouse, and pay the cost
                        towers.Add(new RyanTheGateKeeper(
                            new Rectangle(mState.X - tileWidth / 3, mState.Y - tileHeight / 3,
                            tileWidth, tileHeight),
                            gatekeeperButton.DefaultSprite,
                            towerRadii[3], towerCost[3], towerSpeed[3], gameTime, radius, waitingTexture));
                        totalMoney -= towerCost[3];
                        break;
                    //NOT_ERIN Tower
                    case Towers.ErinTower:
                        //add the tower to the list, position centered on the mouse, and pay the cost
                        towers.Add(new Not_Erin(
                            new Rectangle(mState.X - tileWidth / 3, mState.Y - tileHeight / 3,
                            tileWidth, tileHeight),
                            notErinButton.DefaultSprite,
                            towerRadii[4], towerCost[4], towerSpeed[4], gameTime, radius));
                        totalMoney -= towerCost[4];
                        break;
                }

                //turns off place tower and empties the selectedTower
                placeTower = false;
                towerRollover.Add(false);
                selectedTower = Towers.None;
            }
        }

        /// <summary>
        /// draws aspects of the tutorial
        /// </summary>
        /// <param name="_spriteBatch"></param>
        public void TutorialDraw(SpriteBatch _spriteBatch)
        {
            tutMan.DrawInstructions(_spriteBatch, mState, prevMState, tutorialPhase);
        }

        /// <summary>
        /// Moves the tower code previously in the FSM
        /// to it's own method, in order to cut down
        /// on code that is being copy and pasted
        /// </summary>
        /// <param name="gameTime"></param>
        public void TowerFunction(GameTime gameTime)
        {
            //if the mouse button is clicked and none of the buttons are pressed
            if (mState.LeftButton == ButtonState.Pressed && !pauseButton.RollOver(mState) &&
                !nextWaveButton.RollOver(mState) && !towerMenuButton.RollOver(mState) &&
                !baseTowerButton.RollOver(mState) && !sniperButton.RollOver(mState) &&
                !buffButton.RollOver(mState) && !gatekeeperButton.RollOver(mState) &&
                !notErinButton.RollOver(mState))
            {
                bool inTrack = false;
                //let the user place a tower
                for (int i = 0; i < collisions.TrackLocations.Count; i++)
                {
                    if (collisions.TrackLocations[i].Contains(mState.Position))
                    {
                        inTrack = true;
                    }
                }
                if (!inTrack)
                {
                    placeTower = true;
                }
            }

            //checks if bruhs are hit
            ResolveShot(gameTime);

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
            if (openTowerMenu == true)
            {
                //if the baseTower button is clicked and the player can afford it
                if (baseTowerButton.Clicked(mState, prevMState) &&
                totalMoney >= towerCost[0])
                {
                    //select the baseTower and close the towerMenu
                    selectedTower = Towers.BaseTower;
                    openTowerMenu = false;
                }
                else if (sniperButton.Clicked(mState, prevMState) &&
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

            //for each tower
            for(int i = 0; i < towers.Count; i++)
            {
                //if the tower is currently being rolled over
                if(i == rolledOverTower)
                {
                    //salary button
                    if (salaryButton.Clicked(mState, prevMState))
                    {
                        //if your money is greater than their salary
                        if (totalMoney >= (int)towers[i].OriginalSalary / salaryDivider)
                        {
                            //pay the salary
                            towerManager.SalaryPaid(towers[i]);
                            totalMoney -= (int)towers[i].OriginalSalary / salaryDivider;
                        }
                    }

                    if(collisions.LevelName != "tutorialFixed.level_Appended")
                    {
                        //fire button
                        if (fireButton.Clicked(mState, prevMState))
                        {
                            //remove the tower
                            totalMoney += (int)towers[i].Salary;
                            towerRollover.RemoveAt(i);
                            towers.RemoveAt(i);
                        }
                    }

                    if (i < towers.Count)
                    {
                        //priority button
                        //display the correct button based on the tower's priority
                        switch (towers[i].TowerPriority)
                        {
                            case Priority.First:
                                priorityButton.DefaultSprite = Content.Load<Texture2D>("PFirstButton");
                                priorityButton.ActiveSprite = Content.Load<Texture2D>("PFirstButtonActive");
                                break;
                            case Priority.Strong:
                                priorityButton.DefaultSprite = Content.Load<Texture2D>("PStrongButton");
                                priorityButton.ActiveSprite = Content.Load<Texture2D>("PStrongButtonActive");
                                break;
                            case Priority.Close:
                                priorityButton.DefaultSprite = Content.Load<Texture2D>("PCloseButton");
                                priorityButton.ActiveSprite = Content.Load<Texture2D>("PCloseButtonActive");
                                break;
                        }
                        //if the button is clicked, change the priority
                        if (priorityButton.Clicked(mState, prevMState))
                        {
                            switch (towers[i].TowerPriority)
                            {
                                case Priority.First:
                                    towers[i].TowerPriority = Priority.Strong;
                                    break;
                                case Priority.Strong:
                                    towers[i].TowerPriority = Priority.Close;
                                    break;
                                case Priority.Close:
                                    towers[i].TowerPriority = Priority.First;
                                    break;
                            }
                        }
                    }
                  
                }              
            }
        }

        /// <summary>
        /// draws a little help box when rolling over a tower button
        /// </summary>
        /// <param name="instructions">the instructions</param>
        /// <param name="y">the y value of the tower</param>
        public void DrawTowerInstructions(string instructions, int y)
        {
            //draw the background box next to the tower
            _spriteBatch.Draw(towerMenuSprite, 
                new Rectangle(screenWidth - tileWidth * 6, y, tileWidth * 3, tileHeight * 2), 
                Color.White);
            //draw the instructions
            _spriteBatch.DrawString(arial10, instructions, 
                new Vector2(screenWidth - tileWidth * 6, y), Color.White);
        }

        /// <summary>
        /// draws the tower options
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public void DrawTowerOptions(int x, int y, int salary)
        {
            //draws the back panel
            _spriteBatch.Draw(towerMenuSprite,
                new Rectangle(x, y, tileWidth * 3, tileHeight * 3),
                Color.White);
            //adjusts the location of the salary button and draws it
            salaryButton.X = x + 5;
            salaryButton.Y = y + 3;
            salaryButton.Draw(_spriteBatch, mState);
            //print the salary of the tower
            _spriteBatch.DrawString(arial10, "$" + salary, 
                new Vector2(x + 10 + tileWidth * 2, y + 10), 
                Color.White);
            //adjusts the location of the fire button and draws it
            fireButton.X = x + tileWidth / 2;
            fireButton.Y = y + tileHeight;
            fireButton.Draw(_spriteBatch, mState);
            //adjusts the location of the priority button and draws it
            priorityButton.X = x + 3;
            priorityButton.Y = y - 3 + tileHeight * 2;
            priorityButton.Draw(_spriteBatch, mState);
        }

        /// <summary>
        /// checks the tower button rollovers to print instructions
        /// </summary>
        public void CheckMenuRollover()
        {
            //if rolling over Doot Skeleton
            if (baseTowerButton.RollOver(mState))
            {
                DrawTowerInstructions("  Doot Skeleton:\n  -high range\n  -high speed", baseTowerButton.Y);
            }
            //if rolling over Sniper Monke
            else if (sniperButton.RollOver(mState))
            {
                DrawTowerInstructions("  Sniper Monke:\n  -infinte range\n  -slow speed", sniperButton.Y);
            }
            //if rolling over Buff Doge
            else if (buffButton.RollOver(mState))
            {
                DrawTowerInstructions("  Buff Doge:\n  -small range\n  -high speed\n  " +
                    "-hits multiple \n  bruhs at once", buffButton.Y);
            }
            //if rolling over Ryan the Gatekeeper
            else if (gatekeeperButton.RollOver(mState))
            {
                DrawTowerInstructions("  Ryan the \n  Gatekeeper:\n  -medium range\n  -medium speed\n  " +
                    "-stops bruhs", gatekeeperButton.Y);
            }
            //if rolling over Not Erin
            else if (notErinButton.RollOver(mState))
            {
                DrawTowerInstructions("  Not Erin:\n  -medium range\n  -high speed\n  " +
                    "-instantly kills \n  bruhs in range", notErinButton.Y);
            }
        }

        /// <summary>
        /// checks to see if a tower is being rolled over, and returns the index of the tower being rolled over
        /// </summary>
        /// <returns></returns>
        public int CheckTowerRollover()
        {
            //check each tower
            for (int i = 0; i < towers.Count; i++)
            {
                
                //if the tower is marked as being rolled over
                if(towerRollover[i] == true)
                {
                    //if the tower is below the top of the map
                    if (towers[i].Position.Y > 100)
                    {
                        if (mState.Position.X < towers[i].Position.X + (tileWidth * 2) &&
                            mState.Position.X > towers[i].Position.X - tileWidth &&
                            mState.Position.Y < towers[i].Position.Y + tileWidth &&
                            mState.Position.Y > towers[i].Position.Y - (tileHeight * 3))
                        {
                            DrawTowerOptions(towers[i].Position.X - tileWidth,
                                towers[i].Position.Y - tileHeight * 3,
                            (int)towers[i].OriginalSalary / salaryDivider);
                            //keep the tower as being rolled over and return the index of the tower
                            towerRollover[i] = true;
                            return i;
                        }
                    }
                    //if the tower is at the top of the map, change the position of the menu
                    else if(towers[i].Position.Y <= 100)
                    {
                        if (mState.Position.X < towers[i].Position.X + (tileWidth * 2) &&
                            mState.Position.X > towers[i].Position.X - tileWidth &&
                            mState.Position.Y < towers[i].Position.Y  + tileHeight * 4 &&
                            mState.Position.Y > towers[i].Position.Y)
                        {
                            DrawTowerOptions(towers[i].Position.X - tileWidth, 
                                towers[i].Position.Y + tileHeight,
                                (int)towers[i].OriginalSalary / salaryDivider);
                            //keep the tower as being rolled over and return the index of the tower
                            towerRollover[i] = true;
                            return i;
                        }
                    }
                }
                //if the tower is being rolled over
                else if (towers[i].RollOver(mState))
                {
                    //draw the tower options and mark the tower as being rolled over
                    if (towers[i].Position.Y > 100)
                    {
                        DrawTowerOptions(towers[i].Position.X - tileWidth, towers[i].Position.Y - tileHeight * 3,
                        (int)towers[i].OriginalSalary / salaryDivider);
                        towerRollover[i] = true;
                        return i;
                    }
                    //changes the position of the menu so it doesn't go off the top of the screen
                    else if (towers[i].Position.Y <= 100)
                    {
                        DrawTowerOptions(towers[i].Position.X - tileWidth, towers[i].Position.Y + tileHeight,
                        (int)towers[i].OriginalSalary / salaryDivider);
                        towerRollover[i] = true;
                        return i;
                    }
                }
                //if the tower and menu are not being rolled over
                else
                {
                    //mark the tower as not being rolled over and return -1
                    towerRollover[i] = false;
                }
            }
            //reset towerRollover and return -1
            for(int i = 0; i < towerRollover.Count; i++)
            {
                towerRollover[i] = false;
            }
            return -1;
        }
    }
}
