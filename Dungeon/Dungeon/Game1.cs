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
        Player player = null;
        KeyboardState oldState = new KeyboardState();
        MouseState oldMouseState = new MouseState();
        TileDictionary tileDictionary = new TileDictionary();
        NPCDictionary npcDicationary = new NPCDictionary();
        int currentdngn_floor = 0;
        string doorWait = "none";
        Tile doorTile;
        string moveType = "one";
        TimeSpan oldtime, time;
        bool held = false;
        bool repeat = false;
        FOV fov;
        bool menu = false;
        List<Vector2> moveToList = new List<Vector2>();

        Texture2D border;
        Log log = new Log();
        SpriteFont Font1;
        Vector2 FontPos;
        bool enemyDetected = false;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            graphics.PreferredBackBufferHeight = 1000;
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
            player = new Player(level.upStairs, ref log);
            fov = new FOV(level.grid, player.location);
            fov.GetVisibility();
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
            border = this.Content.Load<Texture2D>("border");

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

            if (!menu)
            {
                UpdateInput();
            }
            else
            {
                MenuInput();
            }

            if(moveToList.Count > 0)        //Update postion here so it can be drawn
            {
                player.MovePlayer(moveToList[0], level.grid);
                moveToList.RemoveAt(0);
                fov = new FOV(level.grid, player.location);
                fov.GetVisibility();
                if (player.MonsterCheck(level.grid) && moveToList.Count > 0)
                {
                    if (!enemyDetected)
                    {
                        log.Write("Enemy detected! Auto-travel has stopped.");
                    }
                    moveToList.Clear();
                    enemyDetected = true;
                }
            }
            if (!player.MonsterCheck(level.grid))
            {
                enemyDetected = false;
            }
            else
            {
                enemyDetected = true;
            }

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

            if (!menu)
            {
                // TODO: Add your drawing code here
                spriteBatch.Begin();
                for (int x = 0; x < 25; x++)
                {
                    for (int y = 0; y < 25; y++)
                    {
                        destination = new Vector2(x * 32, y * 32);
                        level.grid[x, y].DrawTile(spriteBatch, tileTexture, destination, tileDictionary);
                        if (level.grid[x, y].npc != null)
                            level.grid[x, y].npc.DrawNPC(spriteBatch, tileTexture);
                        level.grid[x, y].DrawTileVisibility(spriteBatch, tileTexture, destination, tileDictionary);
                    }
                }

                player.DrawPlayer(spriteBatch, playerSpriteSheet, player.location * 32);

                //Log setup and print
                spriteBatch.Draw(border, new Vector2(0, 800), Color.White);
                Font1 = Content.Load<SpriteFont>("Courier New");
                Vector2 fontPos = new Vector2(10, 815);
                List<String> output = log.GetLines(7);
                foreach (String line in output)
                {
                    spriteBatch.DrawString(Font1, line, fontPos, Color.White);
                    fontPos.Y += 20;
                }

                spriteBatch.End();
            }
            else    //Menu stuff
            {

                Font1 = Content.Load<SpriteFont>("Courier New");

                //GraphicsDevice.Clear(Color.Black);
                spriteBatch.Begin();
                string output = "Inventory";
                FontPos = new Vector2(graphics.GraphicsDevice.Viewport.Width / 64, graphics.GraphicsDevice.Viewport.Height / 64);
                Vector2 FontOrigin = new Vector2(0, 0); // Find the center of the string
                spriteBatch.DrawString(Font1, output, FontPos, Color.SandyBrown, 0, FontOrigin, 1.0f, SpriteEffects.None, 0.5f);    // Draw the string
                FontOrigin.X = FontOrigin.X - (graphics.GraphicsDevice.Viewport.Width / 32);
                foreach (KeyValuePair<String, Item> item in player._playerItems)
                {
                    output = item.Key;
                    output += ": " + player._playerItems[output].name; //Testing adding item names
                    FontOrigin.Y = FontOrigin.Y - (graphics.GraphicsDevice.Viewport.Height / 32);
                    spriteBatch.DrawString(Font1, output, FontPos, Color.SandyBrown, 0, FontOrigin, 1.0f, SpriteEffects.None, 0.5f);    // Draw the string
                }
                spriteBatch.End();
            }

            base.Draw(gameTime);
        }

        private void UpdateInput()
        {
            KeyboardState newState = Keyboard.GetState();
            MouseState newMouseState = Mouse.GetState();

            //Checks if the same key has been held for a period of time. 
            if(newState.Equals(oldState)){
                if(!held){
                    oldtime = time;
                    held = true;
                }else{
                    if (!repeat && time.TotalMilliseconds - oldtime.TotalMilliseconds > 250)
                    {
                        repeat = true;
                    }
                }
            }else{
                held = false;
                repeat = false;
            }

            // Is the SPACE key down?
            if (newState.IsKeyDown(Keys.Space))
            {
                if (!oldState.IsKeyDown(Keys.Space))
                {
                    dungeon.Clear();
                    level = new Dungeon(npcDicationary);
                    dungeon.Add(level);
                    currentdngn_floor = 0;
                    player = new Player(level.upStairs, ref log);
                    fov = new FOV(level.grid, player.location);
                    fov.GetVisibility();
                    log.Write("New floor generated.");
                }
            } 
            if (newState.IsKeyDown(Keys.Left) || newState.IsKeyDown(Keys.NumPad4))
            {
                if (!oldState.IsKeyDown(Keys.Left) && !oldState.IsKeyDown(Keys.NumPad4) || repeat)
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
                        moveToList = player.Movement(new Vector2(-1, 0), level.grid, moveType, moveToList);
                        moveType = "one";
                    }
                    fov = new FOV(level.grid, player.location);
                    fov.GetVisibility();
                }
            }
            if (newState.IsKeyDown(Keys.NumPad7))
            {
                if (!oldState.IsKeyDown(Keys.NumPad7) || repeat)
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
                        moveToList = player.Movement(new Vector2(-1, -1), level.grid, moveType, moveToList);
                        moveType = "one";
                    }
                    fov = new FOV(level.grid, player.location);
                    fov.GetVisibility();
                }
            }
            if (newState.IsKeyDown(Keys.Up) || newState.IsKeyDown(Keys.NumPad8))
            {
                if (!oldState.IsKeyDown(Keys.Up) && !oldState.IsKeyDown(Keys.NumPad8) || repeat)
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
                        moveToList = player.Movement(new Vector2(0, -1), level.grid, moveType, moveToList);
                        moveType = "one";
                    }
                    fov = new FOV(level.grid, player.location);
                    fov.GetVisibility();
                }
            }
            if (newState.IsKeyDown(Keys.NumPad9))
            {
                if (!oldState.IsKeyDown(Keys.NumPad9) || repeat)
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
                        moveToList = player.Movement(new Vector2(1, -1), level.grid, moveType, moveToList);
                        moveType = "one";
                    }
                    fov = new FOV(level.grid, player.location);
                    fov.GetVisibility();
                }
            }
            if (newState.IsKeyDown(Keys.Right) || newState.IsKeyDown(Keys.NumPad6))
            {
                if (!oldState.IsKeyDown(Keys.Right) && !oldState.IsKeyDown(Keys.NumPad6) || repeat)
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
                        moveToList = player.Movement(new Vector2(1, 0), level.grid, moveType, moveToList);
                        moveType = "one";
                    }
                    fov = new FOV(level.grid, player.location);
                    fov.GetVisibility();
                }
            }
            if (newState.IsKeyDown(Keys.NumPad3))
            {
                if (!oldState.IsKeyDown(Keys.NumPad3) || repeat)
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
                        moveToList = player.Movement(new Vector2(1, 1), level.grid, moveType, moveToList);
                        moveType = "one";
                    }
                    fov = new FOV(level.grid, player.location);
                    fov.GetVisibility();
                }
            }
            if (newState.IsKeyDown(Keys.Down) || newState.IsKeyDown(Keys.NumPad2))
            {
                if (!oldState.IsKeyDown(Keys.Down) && !oldState.IsKeyDown(Keys.NumPad2) || repeat)
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
                        moveToList = player.Movement(new Vector2(0, 1), level.grid, moveType, moveToList);
                        moveType = "one";
                    }
                    fov = new FOV(level.grid, player.location);
                    fov.GetVisibility();
                }
            }
            if (newState.IsKeyDown(Keys.NumPad1))
            {
                if (!oldState.IsKeyDown(Keys.NumPad1) || repeat)
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
                        moveToList = player.Movement(new Vector2(-1, 1), level.grid, moveType, moveToList);
                        moveType = "one";
                    }
                    fov = new FOV(level.grid, player.location);
                    fov.GetVisibility();
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
                        fov = new FOV(level.grid, player.location);
                        fov.GetVisibility();
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
                            fov = new FOV(level.grid, player.location);
                            fov.GetVisibility();
                        }
                    }
                }
            }
            if (newState.IsKeyDown(Keys.C))
            {
                if (!oldState.IsKeyDown(Keys.C))
                {
                    doorWait = "close";
                    log.Write("Close which door?");
                }
            }
            if (newState.IsKeyDown(Keys.O))
            {
                if (!oldState.IsKeyDown(Keys.O))
                {
                    doorWait = "open";
                    log.Write("Open which door?");
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

            if (newState.IsKeyDown(Keys.I))
            {
                if (!oldState.IsKeyDown(Keys.I))
                {
                    menu = !menu;
                }
            }

            if (newState.IsKeyDown(Keys.X))
            {
                if (!oldState.IsKeyDown(Keys.X))
                {
                    moveToList = player.MoveTo(new Vector2(12,12),level.grid);
                }
            }

            if (newState.IsKeyDown(Keys.Escape))
            {
                if (!oldState.IsKeyDown(Keys.Escape))
                {
                    Exit();
                }
            }

            if (newState.IsKeyDown(Keys.Enter))
            {
                if (!oldState.IsKeyDown(Keys.Enter))
                {
                    log.Write("Test message!");
                }
            }

            if (newMouseState.LeftButton == ButtonState.Pressed)
            {
                if (oldMouseState.LeftButton != ButtonState.Pressed)
                {
                    Vector2 clickedTile = new Vector2();
                    clickedTile.X = newMouseState.X / 32;
                    clickedTile.Y = newMouseState.Y / 32;
                    if (clickedTile.X >= 0 && clickedTile.X <= 24 &&
                        clickedTile.Y >= 0 && clickedTile.Y <= 24 &&
                        (level.grid[(int)clickedTile.X, (int)clickedTile.Y].seen ||
                        level.grid[(int)clickedTile.X, (int)clickedTile.Y].visible))
                    {
                        moveToList = player.MoveTo(clickedTile, level.grid);
                    }
                }
            }

            // Update saved state.
            oldState = newState;
            oldMouseState = newMouseState;
        }

        private void MenuInput()
        {

            KeyboardState newState = Keyboard.GetState();
            MouseState newMouseState = Mouse.GetState();

            if (newState.IsKeyDown(Keys.I))
            {
                if (!oldState.IsKeyDown(Keys.I))
                {
                    menu = !menu;
                }
            }

            if (newState.IsKeyDown(Keys.Escape))
            {
                if (!oldState.IsKeyDown(Keys.Escape))
                {
                    Exit();
                }
            }

            oldState = newState;
            oldMouseState = newMouseState;
        }
    }
}
