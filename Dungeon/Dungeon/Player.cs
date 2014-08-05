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
        Dictionary<String, Item> _playerItems = new Dictionary<String, Item>()
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

        public bool MoveTo(Vector2 moveTo, Tile[,] grid)
        {
            Tile newTile = grid[(int)moveTo.X, (int)moveTo.Y];  //move to
            Tile currentTile = grid[(int)this._location.X, (int)this._location.Y];  //move from

            if (newTile.isWall){
                return false;
            }

            List<Vector3> moves = new List<Vector3>();
            moves.Add(new Vector3(moveTo.X, moveTo.Y, 0));  // Add the end point first, build from there.

            //Generate list of valid squares up to minimal distance
            int ele = 0;
            while (moves.Count > ele)
            {
                int x = (int)moves[ele].X;
                int y = (int)moves[ele].Y;
                int z = (int)moves[ele].Z;
                for (int i = -1; i < 2; i++)
                {
                    for (int j = -1; j < 2; j++)
                    {
                        if (i != 0 && j != 0 && !grid[x + i, y + j].isWall)  //Don't test current tile, walls, or living npcs
                        {
                            int k = 0;
                            while (k < moves.Count)
                            {
                                if (moves[k].X == x && moves[k].Y == y && moves[k].Z >= z)  //Remove duplicate squares with higher costs
                                {
                                    moves.RemoveAt(k);
                                }else{
                                    k++;    //Only increment LCV if no removal occurred
                                }
                            }
                            if (this._location.X == x + i && this._location.Y == y + i) //We've reached the start location, terminate loops
                            {
                                i = 2; 
                                j = 2;
                                break;
                            }
                            moves.Add(new Vector3(x + i, y + j, z + 1)); //Add to end of list
                            
                        }
                    }
                }
                ele++;
            }

            int best = 65535;   //Need randomly large value greater than worst case distance.
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
            }

            return true;
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
