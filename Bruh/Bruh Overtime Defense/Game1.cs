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
//the logic present in the game.

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
        private SpriteFont arial10;
        private SpriteFont arial16;
        private SpriteFont arial36;
        private SpriteFont arial64;

        private SoundEffect bruhEffect;

        //Collision Manager
        private CollisionManager collisions;

        //Enemies
        private Texture2D enemyTex;
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

        //misc
        private Random random;
        private int totalMoney;
        private bool gainMoney;
        private bool newWave;
        private int currWave;
        private int waveAmont;
        private int enemyCount;
        int health;
        TimeSpan timeSpanSincePause;

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
            collisions = new CollisionManager("redoLevel.level_Appended");

            level = collisions.CurrentLevel;
            
            codes = collisions.Codes;

            random = new Random();

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
            totalMoney = 100;
            gainMoney = false;
            health = 10;
            newWave = false;
            currWave = 0;
            waveAmont = 0;

            //Enemies, and enemy manager
            enemies = new List<Enemy>();
            enMan = new EnemyManager(enemies, collisions.StartPosition);
            enemyCount = 0;
            
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
            bruhEffect = Content.Load<SoundEffect>("bruhEffect");

            towerMenuSprite = Content.Load<Texture2D>("towerSelector");

            //SpriteFonts
            arial10 = Content.Load<SpriteFont>("arial10");
            arial16 = Content.Load<SpriteFont>("arial16");
            arial36 = Content.Load<SpriteFont>("arial36");
            arial64 = Content.Load<SpriteFont>("arial64");

            //Bruh enemy texture
            enemyTex = Content.Load<Texture2D>("bruh");

            
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
                case GameState.TitleScreen:
                    _spriteBatch.DrawString(arial64, "Bruh Overtime \n    Defense", new Vector2(125, 250), Color.White);
                    _spriteBatch.DrawString(arial36, "Press Enter to start", new Vector2(175, 450), Color.White);
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

                    if (towers.Count > 0 && gameTime.TotalGameTime.Milliseconds % random.Next(1, 2001) < 1)
                    {
                        for(int i = 0; i < towers.Count; i++)
                        {
                            gainMoney = towerManager.Shoot(towers[i], enemies);
                           
                            if (gainMoney == true)
                            {
                                bruhEffect.Play(0.005f, -0.05f, 0);
                                totalMoney++;
                                enemyCount--;
                                gainMoney = false;
                            }
                        }                        
                    }

                    

                    //draws buttons
                    towerMenuButton.Draw(_spriteBatch, mState);
                    pauseButton.Draw(_spriteBatch, mState);
                    nextWaveButton.Draw(_spriteBatch, mState);
                    _spriteBatch.DrawString(arial16, "Money: $" + totalMoney, 
                        new Vector2(_graphics.PreferredBackBufferWidth - (tileWidth * 8), 0), 
                        Color.White);
                    _spriteBatch.DrawString(arial16, "Health: " + health,
                        new Vector2(_graphics.PreferredBackBufferWidth - (tileWidth * 11), 0),
                        Color.White);
                    _spriteBatch.DrawString(arial16, "Wave: " + currWave,
                        new Vector2(_graphics.PreferredBackBufferWidth - (tileWidth * 14), 0),
                        Color.White);
                    _spriteBatch.DrawString(arial16, "Number of Enemies: " + enemyCount,
                        new Vector2(_graphics.PreferredBackBufferWidth - (tileWidth * 14), 40),
                        Color.White);


                    //draw the towers
                    for (int i = 0; i < towers.Count; i++)
                    {
                        towers[i].Draw(_spriteBatch);
                    }

                    //draw the towerMenu if it is open
                    if(openTowerMenu == true)
                    {
                        _spriteBatch.Draw(towerMenuSprite, towerMenuPos, Color.White);
                        _spriteBatch.DrawString(arial10, "Tower  Cost",
                        new Vector2(_graphics.PreferredBackBufferWidth - (tileWidth * 2), tileHeight),
                        Color.White);
                        _spriteBatch.DrawString(arial16, "20",
                        new Vector2(_graphics.PreferredBackBufferWidth - (tileWidth), tileHeight * 2),
                        Color.White);
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
                                    baseTowerButton.DefaultSprite, 100, 20, 20));
                                totalMoney -= 20;
                                break;
                        }

                        //turns off place tower and empties the selectedTower
                        placeTower = false;
                        selectedTower = Towers.None;
                    }

                    //Only spawns new enemies if a new wave is active
                    if(newWave == true)
                    {
                        enMan.Update(gameTime);
                        enMan.Draw(_spriteBatch);
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
                    Reset();

                    gState = GameState.Gameplay;                  
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
                        collisions.ChangeEnemyDirection(enemies[i]);
                        enemies[i].X += (int)enemies[i].Movement.X;
                        enemies[i].Y += (int)enemies[i].Movement.Y;
                    }
                }

                //Checks if the user needs to take damage
                TakeDamage();

                //No more health left! Game over!
                if(health <= 0)
                {
                    gState = GameState.GameOver;
                }


                //if the mouse button is clicked and none of the buttons are
                if (mState.LeftButton == ButtonState.Pressed && !pauseButton.RollOver(mState) &&
                    !nextWaveButton.RollOver(mState) && !towerMenuButton.RollOver(mState) && !baseTowerButton.RollOver(mState))
                {
                    placeTower = true;
                }

                //if the player hits left or right control
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
                    //if the baseTower button is clicked and the player can afford it
                    if(baseTowerButton.Clicked(mState, prevMState) &&
                    totalMoney >= 20)
                    {
                        //select the baseTower and close the towerMenu
                        selectedTower = Towers.BaseTower;
                        openTowerMenu = false;
                    }
                }

                //Next wave button clicked
                if (nextWaveButton.Clicked(mState,prevMState))
                {
                    //Checks for the current wave, and how that
                    //affects the enemies

                    //easy enemies, only require one hit
                    //to kill. normal speed
                    if(currWave < 10 && currWave != 10)
                    {
                        enemySpeed = 3;
                        enemyHealth = 1;
                    }

                    //normal enemies, require 3 hits to kill
                    //and have a slightly elevated speed
                    else if(currWave <= 20)
                    {
                        enemySpeed = 4;
                        enemyHealth = 3;                        
                    }

                    //hard enemies, require 4 hits to kill,
                    //have a very fast speed
                    else
                    {
                        enemySpeed = 5;
                        enemyHealth = 4;
                    }

                    //checks if all the enemies in the enemies
                    //list are dead
                    if(enMan.AllEnemiesDead() == true)
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
                          
                        //adds new enemies to the list
                        for (int i = 0; i < waveAmont; i++)
                        {
                            enemies.Add(new Enemy(
                            enemyTex,
                            enemyHealth,
                            enemySpeed,
                            collisions.StartPosition));
                        }

                        //changes the display to the current
                        //amount of enemies in the list
                        enemyCount = enemies.Count;
                        //increments the # of enemies
                        //for next time
                        waveAmont += 5;                    
                    }                    
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
                if(enemies[i].IsDead == false && enemies[i].X > _graphics.PreferredBackBufferWidth)
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
            gainMoney = false;
            health = 9999;
            waveAmont = 5;
            newWave = false;
            currWave = 0;

            //enemies and towers
            towers.Clear();
            enMan.ResetEnemies();
        }
    }
}
