using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace Dungeon
{
    /// <summary>
    /// This is the main type for your game
    /// This is a new comment to test a commit and push after Mikhail committed and pushed
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Vector2 tilePos = new Vector2(0, 0);
        Texture2D tileTexture;
        Texture2D playerSpriteSheet;
        Vector2 destination = new Vector2(0, 0);
        Dungeon level = null;
        List<Dungeon> dungeon = new List<Dungeon>();
        KeyboardState oldState = new KeyboardState();
        MouseState oldMouseState = new MouseState();
        TileDictionary tileDictionary = new TileDictionary();
        int currentdngn_floor = 0;
        string doorWait = "none";
        Tile doorTile;
        string moveType = "one";
        TimeSpan oldtime, time;
        bool held = false;
        bool repeat = false;
        bool menu = false;
        List<Vector2> moveToList = new List<Vector2>();

        Texture2D border;
        SpriteFont Font1;
        Vector2 FontPos;
        bool enemyDetected = false;
        Texture2D healthBar;

        bool playerActed = false;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            graphics.PreferredBackBufferHeight = 1000;
            graphics.PreferredBackBufferWidth = 1000;
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            level = new Dungeon();
            dungeon.Add(level);
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

            // TODO: use this.Content to load your game content here
            tileTexture = this.Content.Load<Texture2D>("tile");

        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
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
            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();

            // TODO: Add your update logic here
            time = gameTime.TotalGameTime;

            UpdateInput();

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);
            // TODO: Add your drawing code here
            spriteBatch.Begin();
            for (int x = 0; x < 25; x++)
            {
                for (int y = 0; y < 25; y++)
                {
                    destination = new Vector2(x * 32, y * 32);
                    level.grid[x, y].DrawTile(spriteBatch, tileTexture, destination, tileDictionary);
                }
            }


            
            spriteBatch.End();

            base.Draw(gameTime);
        }

        private void UpdateInput()
        {
            KeyboardState newState = Keyboard.GetState();
            MouseState newMouseState = Mouse.GetState();

            //Checks if the same key has been held for a period of time. 
            if (newState.Equals(oldState))
            {
                if (!held)
                {
                    oldtime = time;
                    held = true;
                }
                else
                {
                    if (!repeat && time.TotalMilliseconds - oldtime.TotalMilliseconds > 250)
                    {
                        repeat = true;
                    }
                }
            }
            else
            {
                held = false;
                repeat = false;
            }

            // Is the SPACE key down?
            if (newState.IsKeyDown(Keys.Space))
            {
                if (!oldState.IsKeyDown(Keys.Space))
                {
                    dungeon.Clear();
                    level = new Dungeon();
                    dungeon.Add(level);
                    currentdngn_floor = 0;
                }
            }
        }
    }
}
