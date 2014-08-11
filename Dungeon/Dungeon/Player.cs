using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Dungeon
{
    class Player
    {
        Vector2 _location = new Vector2(0, 0);
        PlayerSpriteDictionary _playerSpriteSheet = new PlayerSpriteDictionary();
        string _playerRace;
        //List<Item> _playerItems = new List<Item>();
        public Dictionary<String, Item> _playerItems = new Dictionary<String, Item>()
            {
                {"head", null},
                {"chest", null},
                {"back", null},
                {"hands", null},
                {"legs", null},
                {"feet", null},
                {"main_hand", null},
                {"off_hand", null}
            };
        bool isAlive = true;
        bool nearMons = false;
        int health = 10;

        public Player(Tile startPos)
        {
            this.location = startPos.tilePos;
            startPos.sightBlocker = false;
            this._playerRace = "mummy_m";
            this._playerItems["head"] = new Item(_playerSpriteSheet.GetItem("fhelm_evil"));
            this._playerItems["chest"] = new Item(_playerSpriteSheet.GetItem("chainmail3"));
            this._playerItems["back"] = new Item(_playerSpriteSheet.GetItem("blue_cape"));
            this._playerItems["hands"] = new Item(_playerSpriteSheet.GetItem("glove_blue"));
            this._playerItems["legs"] = new Item(_playerSpriteSheet.GetItem("leg_arm_steel"));
            this._playerItems["feet"] = new Item(_playerSpriteSheet.GetItem("short_brown_shoes"));
            this._playerItems["main_hand"] = new Item(_playerSpriteSheet.GetItem("spiked_flail"));
            this._playerItems["off_hand"] = new Item(_playerSpriteSheet.GetItem("book_white"));
        }
        public Vector2 location
        {
            set { this._location = value; }
            get { return this._location; }
        }

        public void Movement(Vector2 move, Tile[,] grid, string type)
        {
            switch(type)
            {
                case("one"):
                    MovePlayer(move, grid);
                    break;
                case("end"):
                    while (MovePlayer(move, grid) && !nearMons) ;
                    break;
                case("five"):
                    for(int x = 0; x < 5; x++ )
                    {
                        if (!MovePlayer(move, grid) || nearMons)
                            break;
                    }
                    break;
            }
        }

        public bool MovePlayer(Vector2 move, Tile[,] grid)
        {
            Vector2 newLocation = this._location + move;
            Tile newTile = grid[(int)newLocation.X, (int)newLocation.Y];
            bool validMove = true;
            bool wall = newTile.isWall;
            if (newLocation.X > 0 && newLocation.X < 24 && newLocation.Y > 0 && newLocation.Y < 24 && !wall)
            {
                if (newTile.entities.Contains("dngn_closed_door"))
                {
                    newTile.OpenDoor();
                }

                if(newTile.npc != null)
                {
                    newTile.npc.health -= 1;
                    validMove = false;
                }
            }
            else
                validMove = false;

            if(validMove)
                this._location = newLocation;

            return validMove;
        }

        public bool MoveDown(Tile[,] grid)
        {
            Tile currentTile = grid[(int)this._location.X, (int)this._location.Y];
            if (currentTile.entities.Contains("dngn_stone_stairs_down"))
                return true;
            else
                return false;
        }

        public bool MoveUp(Tile[,] grid)
        {
            Tile currentTile = grid[(int)this._location.X, (int)this._location.Y];
            if (currentTile.entities.Contains("dngn_stone_stairs_up"))
                return true;
            else
                return false;
        }

        public List<Vector2> MoveTo(Vector2 moveTo, Tile[,] grid)
        {
            Tile newTile = grid[(int)moveTo.X, (int)moveTo.Y];  //move to
            Tile currentTile = grid[(int)this._location.X, (int)this._location.Y];  //move from

            List<Vector2> moveList = new List<Vector2>(); //List of moves for player

            if (newTile.isWall){
                Console.Write("Wall/NPC");
                return moveList;
            }

            int[,] board = new int[25, 25];             //Matrix for distance scores (originating from endpoint)
            for (int i = 0; i < 25; i++){       //Initialize board (Probably a way to do it during array generation)
                for (int j = 0; j < 25; j++){
                    board[i,j] = 65535;
                }
            }
            board[(int)moveTo.X, (int)moveTo.Y] = 0;    //Initialize ending location score
            List<Vector3> moves = new List<Vector3>();  //X loc, Y loc, and distance score
            moves.Add(new Vector3(moveTo.X, moveTo.Y, 0));  // Add the end point first, build from there.

            while (moves.Count > 0)
            {
                int x = (int)moves[0].X;
                int y = (int)moves[0].Y;
                int score = (int)moves[0].Z;
                for (int i = -1; i < 2; i++)
                {
                    for (int j = -1; j < 2; j++)
                    {
                        if (!grid[x + i, y + j].isWall)  //Don't test current tile, walls, or living npcs
                        {
                            if (score + 1 < board[x + i, y + j])
                            {
                                board[x + i, y + j] = score + 1;
                                moves.Add(new Vector3(x + i, y + j, score + 1));
                            }
                            if (x == (int)this._location.X && y == (int)this._location.Y)
                            {
                                moves.Clear();
                                while (currentTile.tilePos != moveTo)
                                {
                                    int currPosScore = board[(int)currentTile.tilePos.X, (int)currentTile.tilePos.Y];
                                    Vector2 move = new Vector2();
                                    for (int m = -1; m < 2; m++)
                                    {
                                        for (int n = -1; n < 2; n++)
                                        {
                                            if (currPosScore - 1 == board[(int)currentTile.tilePos.X + m, (int)currentTile.tilePos.Y + n])
                                            {
                                                move.X = m;
                                                move.Y = n;
                                                moveList.Add(move);
                                                currentTile = grid[(int)currentTile.tilePos.X + m, (int)currentTile.tilePos.Y + n];
                                                m = 3;
                                                n = 3;
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                if (moves.Count > 0)
                {
                    moves.RemoveAt(0);
                }
            }

            //Print score matrix (DEBUG)
            /*for (int i = 0; i < 25; i++)
            {
                for (int j = 0; j < 25; j++)
                {
                    if (board[i, j] == 65535)
                    {
                        Console.Write("X ");
                    }
                    else { 
                    Console.Write(board[i, j] + " ");
                        }
                }
                Console.WriteLine();
            }*/

            Console.WriteLine((int)this._location.X + " " + (int)this._location.Y);
            Console.WriteLine((int)moveTo.X + " " + (int)moveTo.Y);
            Console.WriteLine(board[(int)this._location.X, (int)this._location.Y]);
            Console.WriteLine(moves.Count);

            /*int xLoc = (int)this._location.X;
            int yLoc = (int)this._location.Y;
            int distance = board[(int)this._location.X, (int)this._location.Y];
            while (distance > 0)
            {
                for (int i = -1; i < 2; i++)
                {
                    for (int j = -1; j < 2; j++)
                    {
                        if (board[xLoc + i, yLoc + j] == distance - 1)
                        {
                            Console.WriteLine(xLoc + " " + yLoc);
                            xLoc += i;
                            yLoc += j;
                            Console.WriteLine(xLoc + " " + yLoc);
                            distance = board[xLoc + i, yLoc + j];
                            Vector2 nextMove = new Vector2(i, j);
                            Movement(nextMove, grid, "one");
                            i = 2;
                            j = 2;
                        }
                    }
                }
            }

            /*int best = 65535;   //Need randomly large value greater than worst case distance.
            Vector2 nextMove = new Vector2(0,0);   //Perhaps return array of moves (doesn't currently draw moves)
            while(moves.Count > 0){
                foreach (Vector3 move in moves){
                    if ((2 > move.X - this._location.X && -2 < move.X - this._location.X) && (2 > move.Y - this._location.Y && -2 < move.Y - this._location.Y))
                    {
                        if (move.Z < best)
                        {
                            nextMove = new Vector2(move.X, move.Y);
                            best = (int)move.Z;
                        }
                    }
                }
                MovePlayer(nextMove, grid);
            }*/

            return moveList;
        }

        public void Kill()
        {
        }

        internal void DrawPlayer(SpriteBatch spriteBatch, Texture2D tileTexture, Vector2 destination)
        {
            spriteBatch.Draw(tileTexture, destination, _playerSpriteSheet.GetSprite("shadow"), Color.White);
            spriteBatch.Draw(tileTexture, new Vector2(destination.X + this._playerItems["back"].offset.X, destination.Y + this._playerItems["back"].offset.Y), _playerSpriteSheet.GetSprite(this._playerItems["back"].spriteLoc), Color.White);            
            spriteBatch.Draw(tileTexture, destination, _playerSpriteSheet.GetSprite(_playerRace), Color.White);

            spriteBatch.Draw(tileTexture, new Vector2(destination.X + this._playerItems["head"].offset.X, destination.Y + this._playerItems["head"].offset.Y), _playerSpriteSheet.GetSprite(this._playerItems["head"].spriteLoc), Color.White);
            spriteBatch.Draw(tileTexture, new Vector2(destination.X + this._playerItems["chest"].offset.X, destination.Y + this._playerItems["chest"].offset.Y), _playerSpriteSheet.GetSprite(this._playerItems["chest"].spriteLoc), Color.White);
            spriteBatch.Draw(tileTexture, new Vector2(destination.X + this._playerItems["hands"].offset.X, destination.Y + this._playerItems["hands"].offset.Y), _playerSpriteSheet.GetSprite(this._playerItems["hands"].spriteLoc), Color.White);
            spriteBatch.Draw(tileTexture, new Vector2(destination.X + this._playerItems["legs"].offset.X, destination.Y + this._playerItems["legs"].offset.Y), _playerSpriteSheet.GetSprite(this._playerItems["legs"].spriteLoc), Color.White);
            spriteBatch.Draw(tileTexture, new Vector2(destination.X + this._playerItems["feet"].offset.X, destination.Y + this._playerItems["feet"].offset.Y), _playerSpriteSheet.GetSprite(this._playerItems["feet"].spriteLoc), Color.White);
            spriteBatch.Draw(tileTexture, new Vector2(destination.X + this._playerItems["main_hand"].offset.X, destination.Y + this._playerItems["main_hand"].offset.Y), _playerSpriteSheet.GetSprite(this._playerItems["main_hand"].spriteLoc), Color.White);
            spriteBatch.Draw(tileTexture, new Vector2(destination.X + this._playerItems["off_hand"].offset.X, destination.Y + this._playerItems["off_hand"].offset.Y), _playerSpriteSheet.GetSprite(this._playerItems["off_hand"].spriteLoc), Color.White);
        }
    }
}
