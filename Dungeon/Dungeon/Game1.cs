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
        SpriteFont Font1;
        Vector2 FontPos;
        bool enemyDetected = false;
        Texture2D healthBar;

        bool playerActed = false;
        List<NPC> npcs;
        Random random = new Random();

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
            Log.Write("Welcome to the dungeon!");
            level = new Dungeon(npcDicationary);
            dungeon.Add(level);
            npcs = level.npcs;
            player = new Player(level.upStairs);
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
            Font1 = Content.Load<SpriteFont>("Courier New");
            border = this.Content.Load<Texture2D>("border");
            healthBar = this.Content.Load<Texture2D>("hpbar");

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

            
            foreach (NPC npc in npcs)
            {
                /*if (playerActed)
                {
                    npc.MovePlayer(new Vector2(random.Next(3) - 1, random.Next(3) - 1), level.grid);
                }*/
                npc.npcStillAlive(level.grid);
            }
            /*playerActed = false;

            if (!playerActed)
            {*/
                if (!menu)
                {
                    UpdateInput();
                }
                else
                {
                    MenuInput();
                }

                if (moveToList.Count > 0)        //Update postion here so it can be drawn
                {
                    playerActed = player.MovePlayer(moveToList[0], level.grid);
                    moveToList.RemoveAt(0);
                    fov = new FOV(level.grid, player.location);
                    fov.GetVisibility();
                    if (player.MonsterCheck(level.grid) && moveToList.Count > 0)
                    {
                        if (!enemyDetected)
                        {
                            Log.Write("Enemy detected! Auto-travel has stopped.");
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

            //}

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

                //Draw log and border
                spriteBatch.Draw(border, new Vector2(0, 800), Color.White);
                Log.DrawLog(spriteBatch, Font1);

                //Simple healthbar and health printout
                string text = (player.health).ToString() + "/" + (player.maxHealth).ToString();
                spriteBatch.DrawString(Font1, text, new Vector2(805, 50), Color.White);
                spriteBatch.Draw(healthBar, new Rectangle(890,50,100,20), new Rectangle((int)(100.0*(player.maxHealth - player.health)/player.maxHealth),0,100,20), Color.White);

                spriteBatch.End();
            }
            else    //Menu stuff
            {

                //GraphicsDevice.Clear(Color.Black);
                spriteBatch.Begin();
                string output = "Inventory";
                FontPos = new Vector2(graphics.GraphicsDevice.Viewport.Width / 64, graphics.GraphicsDevice.Viewport.Height / 64);
                Vector2 FontOrigin = new Vector2(0, 0); // Find the center of the string
                spriteBatch.DrawString(Font1, output, FontPos, Color.SandyBrown, 0, FontOrigin, 1.0f, SpriteEffects.None, 0.5f);    // Draw the string
                FontOrigin.X = FontOrigin.X - (graphics.GraphicsDevice.Viewport.Width / 32);
                foreach (KeyValuePair<String, Item> item in player._entityItems)
                {              
                    output = item.Key;
                    output += ": " + item.Value.name; //Testing adding item names
                    //output += " item type " + item.Value.GetType().FullName;
                    if (item.Value.GetType() == typeof(Focus))
                    {
                        Focus focus = (Focus)item.Value;
                        output += " - " + focus.school;
                    }
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
                    npcs = level.npcs;
                    currentdngn_floor = 0;
                    player = new Player(level.upStairs);
                    fov = new FOV(level.grid, player.location);
                    fov.GetVisibility();
                    Log.Write("New floor generated.");
                    playerActed = false;
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
                                playerActed = doorTile.CloseDoor();
                                break;
                            case("open"):
                                playerActed = doorTile.OpenDoor();
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
                                playerActed = doorTile.CloseDoor();
                                break;
                            case ("open"):
                                playerActed = doorTile.OpenDoor();
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
                                playerActed = doorTile.CloseDoor();
                                break;
                            case ("open"):
                                playerActed = doorTile.OpenDoor();
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
                                playerActed = doorTile.CloseDoor();
                                break;
                            case ("open"):
                                playerActed = doorTile.OpenDoor();
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
                                playerActed = doorTile.CloseDoor();
                                break;
                            case ("open"):
                                playerActed = doorTile.OpenDoor();
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
                                playerActed = doorTile.CloseDoor();
                                break;
                            case ("open"):
                                playerActed = doorTile.OpenDoor();
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
                                playerActed = doorTile.CloseDoor();
                                break;
                            case ("open"):
                                playerActed = doorTile.OpenDoor();
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
                                playerActed = doorTile.CloseDoor();
                                break;
                            case ("open"):
                                playerActed = doorTile.OpenDoor();
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
                            npcs = level.npcs;
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
                            npcs = level.npcs;
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
                    Log.Write("Close which door?");
                }
            }
            if (newState.IsKeyDown(Keys.O))
            {
                if (!oldState.IsKeyDown(Keys.O))
                {
                    doorWait = "open";
                    Log.Write("Open which door?");
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
                    Log.Write("Test message!");
                }
            }

            if (newState.IsKeyDown(Keys.F10))
            {
                if (!oldState.IsKeyDown(Keys.F10))
                {
                    for (int x = 0; x < 25; x++)
                    {
                        for (int y = 0; y < 25; y++)
                        {
                            level.grid[x, y].visible = true;
                        }
                    }
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
