using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;


namespace Sokoban
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        public static Vector2 WindowSize { get; private set; }
        Texture2D backGround;
        private SpriteFont font;
        //Map map;
        Player player;
        Painter painter;
        List<Level> levels;
        int currentLevel;

        KeyboardState currentKeyboardState;
        KeyboardState previousKeyboardState;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            graphics.IsFullScreen = false;
            WindowSize = new Vector2(graphics.PreferredBackBufferHeight, graphics.PreferredBackBufferWidth);

            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            var loader = new LevelsLoader("Levels");
            levels = loader.Load();
            if (levels == null || levels.Count == 0)
                throw new Exception("Levels not create!");
            currentLevel = 0;

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            backGround = Content.Load<Texture2D>("Graphics\\Stars");

            Texture2D playerTexture = Content.Load<Texture2D>("Graphics\\Player");
            Player.SetTexture(playerTexture);
            
            Texture2D wallTexture = Content.Load<Texture2D>("Graphics\\Wall");
            Wall.SetTexture(wallTexture);

            Texture2D boxTexture = Content.Load<Texture2D>("Graphics\\Box");
            Box.SetTexture(boxTexture);

            Texture2D boxParkingTexture = Content.Load<Texture2D>("Graphics\\Box Parking");
            BoxParking.SetTexture(boxParkingTexture);

            Texture2D floorTexture = Content.Load<Texture2D>("Graphics\\Floor");
            Floor.SetTexture(floorTexture);

            font = Content.Load<SpriteFont>("Fonts\\GameFont");
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            if (levels[currentLevel].CheckWin())
                if (currentLevel < levels.Count - 1)
                    currentLevel++;
            if (Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();
            levels[currentLevel].Update(gameTime);
            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {

            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            spriteBatch.Begin();
            spriteBatch.Draw(backGround, new Rectangle(0, 0, (int)WindowSize.Y, (int)WindowSize.X), Color.White);
            levels[currentLevel].Draw(gameTime, spriteBatch, font);
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
