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
        List<string> _playerSprite = new List<string>();
        bool isAlive = true;
        bool nearMons = false;
        int health = 10;

        public Player(Tile startPos)
        {
            this.location = startPos.tilePos;
            this._playerSprite.Add("blue_cape");
            this._playerSprite.Add("mummy_m");
            this._playerSprite.Add("demon_trident");
            this._playerSprite.Add("plate_black");
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
                    newTile.RemoveEntity("dngn_closed_door");
                    newTile.AddEntity("dngn_open_door");
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

        public void Kill()
        {
        }

        internal void DrawPlayer(SpriteBatch spriteBatch, Texture2D tileTexture, Vector2 destination)
        {
            foreach (string sprite in _playerSprite)
            {
                spriteBatch.Draw(tileTexture, destination, _playerSpriteSheet.GetSprite(sprite), Color.White);
            }
        }
    }
}
