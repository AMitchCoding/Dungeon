using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Dungeon
{
    class Player : Entity
    {
        Vector2 _location = new Vector2(0, 0);
        PlayerSpriteDictionary _playerSpriteSheet = new PlayerSpriteDictionary();
        string _playerRace;
        Log _playerLog;

        public Player(Tile startPos, Log playerLog)
        {

            this.location = startPos.tilePos;
            startPos.sightBlocker = false;
            this._playerRace = "mummy_m";

            this._playerLog = playerLog;
            this._playerLog.Write("I come from the player!");

            this._entityItems["head"] = new Item(_playerSpriteSheet.GetItem("fhelm_evil"));
            this._entityItems["chest"] = new Item(_playerSpriteSheet.GetItem("chainmail3"));
            this._entityItems["back"] = new Item(_playerSpriteSheet.GetItem("blue_cape"));
            this._entityItems["hands"] = new Item(_playerSpriteSheet.GetItem("glove_blue"));
            this._entityItems["legs"] = new Item(_playerSpriteSheet.GetItem("leg_arm_steel"));
            this._entityItems["feet"] = new Item(_playerSpriteSheet.GetItem("short_brown_shoes"));
            this._entityItems["main_hand"] = new Item(_playerSpriteSheet.GetItem("spiked_flail"));
            this._entityItems["off_hand"] = new Item(_playerSpriteSheet.GetItem("book_white"));

            this._health = 100;
            this._baseAttack = 10;
            this._baseDefense = 10;
            this._strength = 10;
            this._dexterity = 10;
            this._intelligence = 10;
            this._luck = 10;
        }
        public Vector2 location
        {
            set { this._location = value; }
            get { return this._location; }
        }

        public List<Vector2> Movement(Vector2 move, Tile[,] grid, string type, List<Vector2> moveToList)
        {
            Tile destTile = grid[(int)(this._location.X + move.X), (int)(this._location.Y + move.Y)];
            int moveCount = 4;

            switch(type)
            {
                case("one"):
                    MovePlayer(move, grid);
                    break;
                case("end"):
                    while (!destTile.isWall)
                    { 
                        moveToList.Add(move);
                        destTile = grid[(int)(destTile.tilePos.X + move.X), (int)(destTile.tilePos.Y + move.Y)];
                    }
                    break;
                case("five"):
                    while(!destTile.isWall && moveCount > 0)
                    {
                        moveToList.Add(move);
                        destTile = grid[(int)(destTile.tilePos.X + move.X), (int)(destTile.tilePos.Y + move.Y)];
                        moveCount--;
                    }
                    break;
            }
            return moveToList;
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
                    //newTile.npc.health -= 1;
                    Combat.Fight(this, newTile.npc);
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
                return moveList;
            }

            int[,] board = new int[25, 25];             //Matrix for distance scores (originating from endpoint)
            for (int i = 0; i < 25; i++){           //Initialize board (Probably a way to do it during array generation)
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
                            }
                        }
                    }
                }
                if (moves.Count > 0)
                {
                    moves.RemoveAt(0);
                }
            }

            //Create move list, priority given to straight directional moves over diagonals
            int[] dir = new int[] { 0, -1, 1 };
            while (currentTile.tilePos != moveTo)
            {
                bool broke = false; //Sentinel for early exit
                int currPosScore = board[(int)currentTile.tilePos.X, (int)currentTile.tilePos.Y];
                Vector2 move = new Vector2();
                foreach (int m in dir)
                {
                    foreach (int n in dir)
                    {
                        if (currPosScore - 1 == board[(int)currentTile.tilePos.X + m, (int)currentTile.tilePos.Y + n])
                        {
                            move.X = m;
                            move.Y = n;
                            moveList.Add(move);
                            currentTile = grid[(int)currentTile.tilePos.X + m, (int)currentTile.tilePos.Y + n];
                            broke = true;
                            break;
                        }
                    }
                    if (broke) { break; }   //Found move, look for next move
                }
            }

            return moveList;
        }

        public void Kill()
        {
        }

        public bool MonsterCheck(Tile[,] grid)
        {
            Tile tile = null;
            int minX = -5;
            int minY = -5;
            int maxX = 5;
            int maxY = 5;

            if (this._location.X <= 4)
                minX = (int)this._location.X * -1;
            if (this._location.Y <= 4)
                minY = (int)this._location.Y * -1;
            if (this._location.X >= 20)
                maxX = 24 - (int)this._location.X;
            if (this._location.Y >= 20)
                maxY = 24 - (int)this._location.Y;

            for (int i = minX; i <= maxX; i++)
            {
                for (int j = minY; j <= maxY; j++)
                {
                    tile = grid[(int)this._location.X + i, (int)this._location.Y + j];
                    if (tile.npc != null && tile.visible)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        internal void DrawPlayer(SpriteBatch spriteBatch, Texture2D tileTexture, Vector2 destination)
        {
            spriteBatch.Draw(tileTexture, destination, _playerSpriteSheet.GetSprite("shadow"), Color.White);
            spriteBatch.Draw(tileTexture, new Vector2(destination.X + this._entityItems["back"].offset.X, destination.Y + this._entityItems["back"].offset.Y), _playerSpriteSheet.GetSprite(this._entityItems["back"].spriteLoc), Color.White);            
            spriteBatch.Draw(tileTexture, destination, _playerSpriteSheet.GetSprite(_playerRace), Color.White);

            spriteBatch.Draw(tileTexture, new Vector2(destination.X + this._entityItems["head"].offset.X, destination.Y + this._entityItems["head"].offset.Y), _playerSpriteSheet.GetSprite(this._entityItems["head"].spriteLoc), Color.White);
            spriteBatch.Draw(tileTexture, new Vector2(destination.X + this._entityItems["chest"].offset.X, destination.Y + this._entityItems["chest"].offset.Y), _playerSpriteSheet.GetSprite(this._entityItems["chest"].spriteLoc), Color.White);
            spriteBatch.Draw(tileTexture, new Vector2(destination.X + this._entityItems["hands"].offset.X, destination.Y + this._entityItems["hands"].offset.Y), _playerSpriteSheet.GetSprite(this._entityItems["hands"].spriteLoc), Color.White);
            spriteBatch.Draw(tileTexture, new Vector2(destination.X + this._entityItems["legs"].offset.X, destination.Y + this._entityItems["legs"].offset.Y), _playerSpriteSheet.GetSprite(this._entityItems["legs"].spriteLoc), Color.White);
            spriteBatch.Draw(tileTexture, new Vector2(destination.X + this._entityItems["feet"].offset.X, destination.Y + this._entityItems["feet"].offset.Y), _playerSpriteSheet.GetSprite(this._entityItems["feet"].spriteLoc), Color.White);
            spriteBatch.Draw(tileTexture, new Vector2(destination.X + this._entityItems["main_hand"].offset.X, destination.Y + this._entityItems["main_hand"].offset.Y), _playerSpriteSheet.GetSprite(this._entityItems["main_hand"].spriteLoc), Color.White);
            spriteBatch.Draw(tileTexture, new Vector2(destination.X + this._entityItems["off_hand"].offset.X, destination.Y + this._entityItems["off_hand"].offset.Y), _playerSpriteSheet.GetSprite(this._entityItems["off_hand"].spriteLoc), Color.White);
        }
    }
}
