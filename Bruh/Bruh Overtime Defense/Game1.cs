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

        private Level level;
        private Level level2;
        private List<string> codes;

        private int tileHeight;
        private int tileWidth;

        //Textures
        private List<Texture2D> textures;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;


        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            textures = new List<Texture2D>();

            level = new Level("simpleMap.level_Appended");
            level2 = new Level("testMap.level_Appended");
            codes = level.GenerateMap();

            _graphics.PreferredBackBufferWidth = 750;
            _graphics.PreferredBackBufferHeight = 750;

            tileWidth = _graphics.PreferredBackBufferWidth / level.Width;
            tileHeight = _graphics.PreferredBackBufferHeight / level.Width;

            _graphics.ApplyChanges();

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            foreach(string code in codes)
            {
                Texture2D texture = Content.Load<Texture2D>("Textures/" + code);

                textures.Add(texture);
            }

            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            _spriteBatch.Begin();

            for(int i = 0; i < level.Width; i++)
            {
                for(int j = 0; j < level.Height; j++)
                {
                    level.Draw(_spriteBatch, textures[(i * 10) + j],
                    new Rectangle(
                        new Point(tileWidth * j, tileHeight * i),
                        new Point(tileWidth, tileHeight)));
                }
            }
            
                       

            _spriteBatch.End();
            

            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}
