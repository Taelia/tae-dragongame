#region Using Statements
using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.GamerServices;
using TomeLib.Db;
using TomeLib.Irc;
using Meebey.SmartIrc4net;
using DragonGame.GameClasses;
using DragonGame.Content;
#endregion

namespace DragonGame
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public partial class GameLoop : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        public static Texture2D blueBackground; //quick background test
        public static Texture2D WhitePixel;
        public static Dictionary<string, Texture2D> Sprites = new Dictionary<string, Texture2D>();
        public static SpriteFont JupiterFont;

        private Main _main;

        private TimeSpan _time = TimeSpan.FromMinutes(30);

        public GameLoop(Main main)
            : base()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            graphics.PreferredBackBufferWidth = 1280;
            graphics.PreferredBackBufferHeight = 720;

            _main = main;
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            blueBackground = Content.Load<Texture2D>("Backgrounds/Blue");
            JupiterFont = Content.Load<SpriteFont>("Fonts/Jupiter");
            Sprites = Content.LoadContent<Texture2D>("Sprites");
            WhitePixel = Content.Load<Texture2D>("pixel");
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }



        bool TEMPb;
        int TEMPi;

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            /*
            var state = Keyboard.GetState();
            if (state.IsKeyDown(Keys.A) && !TEMPb)
            {
                string from = "";

                if (TEMPi == 0) from = "taelia_";
                else if (TEMPi == 1) from = "worstcokefreak";
                else if (TEMPi == 2) from = "misakamikoto_";
                else if (TEMPi == 3) from = "rauguen";
                else if (TEMPi == 4) from = "thehappiepandaa";

                TEMPi = (TEMPi + 1) % 5;

                OnMessage(from, "3");
                TEMPb = true;
            }
            if (state.IsKeyUp(Keys.A))
                TEMPb = false;
            */

            //Tick once every 30 for karma bonusses.
            _time -= gameTime.ElapsedGameTime; if (_time < TimeSpan.Zero) { _time = TimeSpan.FromMinutes(30); TickPer30Minutes(); }

            _battle.Update(gameTime);

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin();

            spriteBatch.Draw(blueBackground, new Vector2(0, 0), Color.White);

            _battle.Draw(spriteBatch);

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
