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
        Player player = null;
        KeyboardState oldState = new KeyboardState();
        TileDictionary tileDictionary = new TileDictionary();
        NPCDictionary npcDicationary = new NPCDictionary();
        int currentdngn_floor = 0;
        string doorWait = "none";
        Tile doorTile;
        string moveType = "one";


        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            graphics.PreferredBackBufferHeight = 800;
            graphics.PreferredBackBufferWidth = 800;
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
            level = new Dungeon(npcDicationary);
            dungeon.Add(level);
            player = new Player(level.upStairs);
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
            playerSpriteSheet = this.Content.Load<Texture2D>("player");
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
            UpdateInput();
            foreach (NPC npc in level.npcs)
                npc.npcStillAlive(level.grid);

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
                    if(level.grid[x, y].npc != null)
                        level.grid[x, y].npc.DrawNPC(spriteBatch, tileTexture);
                }
            }
            player.DrawPlayer(spriteBatch, playerSpriteSheet, player.location * 32);
            spriteBatch.End();

            base.Draw(gameTime);
        }

        private void UpdateInput()
        {
            KeyboardState newState = Keyboard.GetState();

            // Is the SPACE key down?
            if (newState.IsKeyDown(Keys.Space))
            {
                if (!oldState.IsKeyDown(Keys.Space))
                {
                    dungeon.Clear();
                    level = new Dungeon(npcDicationary);
                    dungeon.Add(level);
                    currentdngn_floor = 0;
                    player = new Player(level.upStairs);
                }
            } 
            if (newState.IsKeyDown(Keys.Left) || newState.IsKeyDown(Keys.NumPad4))
            {
                if (!oldState.IsKeyDown(Keys.Left) && !oldState.IsKeyDown(Keys.NumPad4))
                {
                    if (doorWait != "none")
                    {
                        doorTile = level.grid[(int)player.location.X - 1, (int)player.location.Y];
                        switch(doorWait)
                        {
                            case("close"):
                                doorTile.CloseDoor();
                                break;
                            case("open"):
                                doorTile.OpenDoor();
                                break;
                        }
                        doorWait = "none";
                    }
                    else
                    {
                        player.Movement(new Vector2(-1, 0), level.grid, moveType);
                        moveType = "one";
                    }
                }
            }
            if (newState.IsKeyDown(Keys.NumPad7))
            {
                if (!oldState.IsKeyDown(Keys.NumPad7))
                {
                    if (doorWait != "none")
                    {
                        doorTile = level.grid[(int)player.location.X - 1, (int)player.location.Y - 1];
                        switch (doorWait)
                        {
                            case ("close"):
                                doorTile.CloseDoor();
                                break;
                            case ("open"):
                                doorTile.OpenDoor();
                                break;
                        }
                        doorWait = "none";
                    }
                    else
                    {
                        player.Movement(new Vector2(-1, -1), level.grid, moveType);
                        moveType = "one";
                    }
                }
            }
            if (newState.IsKeyDown(Keys.Up) || newState.IsKeyDown(Keys.NumPad8))
            {
                if (!oldState.IsKeyDown(Keys.Up) && !oldState.IsKeyDown(Keys.NumPad8))
                {
                    if (doorWait != "none")
                    {
                        doorTile = level.grid[(int)player.location.X, (int)player.location.Y - 1];
                        switch (doorWait)
                        {
                            case ("close"):
                                doorTile.CloseDoor();
                                break;
                            case ("open"):
                                doorTile.OpenDoor();
                                break;
                        }
                        doorWait = "none";
                    }
                    else
                    {
                        player.Movement(new Vector2(0, -1), level.grid, moveType);
                        moveType = "one";
                    }
                }
            }
            if (newState.IsKeyDown(Keys.NumPad9))
            {
                if (!oldState.IsKeyDown(Keys.NumPad9))
                {
                    if (doorWait != "none")
                    {
                        doorTile = level.grid[(int)player.location.X + 1, (int)player.location.Y - 1];
                        switch (doorWait)
                        {
                            case ("close"):
                                doorTile.CloseDoor();
                                break;
                            case ("open"):
                                doorTile.OpenDoor();
                                break;
                        }
                        doorWait = "none";
                    }
                    else
                    {
                        player.Movement(new Vector2(1, -1), level.grid, moveType);
                        moveType = "one";
                    }
                }
            }
            if (newState.IsKeyDown(Keys.Right) || newState.IsKeyDown(Keys.NumPad6))
            {
                if (!oldState.IsKeyDown(Keys.Right) && !oldState.IsKeyDown(Keys.NumPad6))
                {
                    if (doorWait != "none")
                    {
                        doorTile = level.grid[(int)player.location.X + 1, (int)player.location.Y];
                        switch (doorWait)
                        {
                            case ("close"):
                                doorTile.CloseDoor();
                                break;
                            case ("open"):
                                doorTile.OpenDoor();
                                break;
                        }
                        doorWait = "none";
                    }
                    else
                    {
                        player.Movement(new Vector2(1, 0), level.grid, moveType);
                        moveType = "one";
                    }
                }
            }
            if (newState.IsKeyDown(Keys.NumPad3))
            {
                if (!oldState.IsKeyDown(Keys.NumPad3))
                {
                    if (doorWait != "none")
                    {
                        doorTile = level.grid[(int)player.location.X + 1, (int)player.location.Y + 1];
                        switch (doorWait)
                        {
                            case ("close"):
                                doorTile.CloseDoor();
                                break;
                            case ("open"):
                                doorTile.OpenDoor();
                                break;
                        }
                        doorWait = "none";
                    }
                    else
                    {
                        player.Movement(new Vector2(1, 1), level.grid, moveType);
                        moveType = "one";
                    }
                }
            }
            if (newState.IsKeyDown(Keys.Down) || newState.IsKeyDown(Keys.NumPad2))
            {
                if (!oldState.IsKeyDown(Keys.Down) && !oldState.IsKeyDown(Keys.NumPad2))
                {
                    if (doorWait != "none")
                    {
                        doorTile = level.grid[(int)player.location.X, (int)player.location.Y + 1];
                        switch (doorWait)
                        {
                            case ("close"):
                                doorTile.CloseDoor();
                                break;
                            case ("open"):
                                doorTile.OpenDoor();
                                break;
                        }
                        doorWait = "none";
                    }
                    else
                    {
                        player.Movement(new Vector2(0, 1), level.grid, moveType);
                        moveType = "one";
                    }
                }
            }
            if (newState.IsKeyDown(Keys.NumPad1))
            {
                if (!oldState.IsKeyDown(Keys.NumPad1))
                {
                    if (doorWait != "none")
                    {
                        doorTile = level.grid[(int)player.location.X - 1, (int)player.location.Y + 1];
                        switch (doorWait)
                        {
                            case ("close"):
                                doorTile.CloseDoor();
                                break;
                            case ("open"):
                                doorTile.OpenDoor();
                                break;
                        }
                        doorWait = "none";
                    }
                    else
                    {
                        player.Movement(new Vector2(-1, 1), level.grid, moveType);
                        moveType = "one";
                    }
                }
            }
            if (newState.IsKeyDown(Keys.OemPeriod))
            {
                if (!oldState.IsKeyDown(Keys.OemPeriod))
                {
                    if (player.MoveDown(level.grid))
                    {
                        if (currentdngn_floor == dungeon.Count - 1)
                        {
                            level = new Dungeon(npcDicationary);
                            dungeon.Add(level);
                            currentdngn_floor++;
                        }
                        else
                        {
                            currentdngn_floor++;
                            level = dungeon[currentdngn_floor];
                        }
                        player.location = level.upStairs.tilePos;
                    }
                }
            }
            if (newState.IsKeyDown(Keys.OemComma))
            {
                if (!oldState.IsKeyDown(Keys.OemComma))
                {
                    if (currentdngn_floor > 0)
                    {
                        if (player.MoveUp(level.grid))
                        {
                            currentdngn_floor--;
                            level = dungeon[currentdngn_floor];
                            player.location = level.downStairs.tilePos;
                        }
                    }
                }
            }
            if (newState.IsKeyDown(Keys.C))
            {
                if (!oldState.IsKeyDown(Keys.C))
                {
                    doorWait = "close";
                }
            }
            if (newState.IsKeyDown(Keys.O))
            {
                if (!oldState.IsKeyDown(Keys.O))
                {
                    doorWait = "open";
                }
            }
            if (newState.IsKeyDown(Keys.Divide))
            {
                if (!oldState.IsKeyDown(Keys.Divide))
                {
                    moveType = "five";
                }
            }
            if (newState.IsKeyDown(Keys.Multiply))
            {
                if (!oldState.IsKeyDown(Keys.Multiply))
                {
                    moveType = "end";
                }
            }

            // Update saved state.
            oldState = newState;
        }
    }
}