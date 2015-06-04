using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
namespace Dungeon
{
    class Tile
    {
        private bool _isEdge = false;
        private bool _isWall = true;
        private bool _sightBlocker = true;
        private bool _visible = false;
        private bool _seen = false;
        private bool _scanned = false;
        private Vector2 _tilePos = new Vector2(0, 0);
        private string _tileName = "dngn_rock_wall_dark_gray";
        List<string> _items = new List<string>();
        List<string> _entities = new List<string>();
        NPC _npc = null;

        /// <summary>
        /// Tile constructor
        /// </summary>
        /// <param name="tilePos">Location in the grid</param>
        public Tile(Vector2 tilePos)
        {
            this._tilePos = tilePos;
        }

        /// <summary>
        /// Tile position property
        /// </summary>
        public Vector2 tilePos
        {
            get { return this._tilePos; }
        }

        /// <summary>
        /// NPC occupying this tile
        /// </summary>
        public NPC npc
        {
            set { this._npc = value; }
            get { return this._npc; }
        }

        /// <summary>
        /// Type of tile
        /// </summary>
        public string tileName
        {
            set { this._tileName = value; }
            get { return this._tileName; }
        }

        /// <summary>
        /// Edge of dungeon floor bool
        /// </summary>
        public bool isEdge
        {
            set { this._isEdge = value; }
            get { return this._isEdge; }
        }

        /// <summary>
        /// Tile is a wall property
        /// </summary>
        public bool isWall
        {
            set { this._isWall = value; }
            get { return this._isWall; }
        }

        /// <summary>
        /// Tile current visible by player
        /// </summary>
        public bool visible
        {
            set { this._visible = value; }
            get { return this._visible; }
        }

        /// <summary>
        /// Tile seen by player
        /// </summary>
        public bool seen
        {
            set { this._seen = value; }
            get { return this._seen; }
        }

        /// <summary>
        /// Tile that blocks player sight
        /// </summary>
        public bool sightBlocker
        {
            set { this._sightBlocker = value; }
            get { return this._sightBlocker; }
        }

        /// <summary>
        /// Bool for if scanned for FOV class
        /// </summary>
        public bool scanned
        {
            set { this._scanned = value; }
            get { return this._scanned; }
        }

        /// <summary>
        /// Adds item to tile
        /// </summary>
        /// <param name="item">Item to add to tile</param>
        public void AddItem(string item)
        {
            this._items.Add(item);
        }

        /// <summary>
        /// List of entities on the tile
        /// </summary>
        public List<string> entities
        {
            get { return this._entities; }
        }

        /// <summary>
        /// Adds entity to tile
        /// </summary>
        /// <param name="entity"></param>
        public void AddEntity(string entity)
        {
            this._entities.Add(entity);
        }

        /// <summary>
        /// Removes entity from tile
        /// </summary>
        /// <param name="entity"></param>
        public void RemoveEntity(string entity)
        {
            this._entities.Remove(entity);
        }

        /// <summary>
        /// Creates door on tile
        /// </summary>
        public void CreateDoor()
        {
            this._entities.Add("dngn_closed_door");
            this._isWall = false;
            this._tileName = "dngn_floor";
        }


        /// <summary>
        /// Opens door on tile
        /// </summary>
        /// <returns>True if door is closed</returns>
        public bool OpenDoor()
        {
            if(this._entities.Contains("dngn_closed_door"))
            {
                this._entities.Remove("dngn_closed_door");
                this._entities.Add("dngn_open_door");
                this._sightBlocker = false;
                return true;
            }
            return false;
        }

        /// <summary>
        /// Closes door on tile
        /// </summary>
        /// <returns>True if door is open</returns>
        public bool CloseDoor()
        {
            if(this._entities.Contains("dngn_open_door"))
            {
                this._entities.Remove("dngn_open_door");
                this._entities.Add("dngn_closed_door");
                this._sightBlocker = true;
                return true;
            }
            return false;
        }

        /// <summary>
        /// Draws tile
        /// </summary>
        /// <param name="spriteBatch">Sprite batch being used to draw</param>
        /// <param name="tileTexture">Sprite sheet for tiles</param>
        /// <param name="destination">Where to draw it on screen</param>
        /// <param name="tiles">What tile to draw</param>
        public void DrawTile(SpriteBatch spriteBatch, Texture2D tileTexture, Vector2 destination, TileDictionary tiles)
        {
            
            Rectangle tileRect = new Rectangle((int)tiles.GetTile(_tileName).X * 32, (int)tiles.GetTile(_tileName).Y * 32, 
                tileTexture.Width / 30, tileTexture.Height / 32);
            spriteBatch.Draw(tileTexture, destination, tileRect, Color.White);

            foreach(String entity in _entities)
            {
                Rectangle entityRect = new Rectangle((int)tiles.GetTile(entity).X * 32, (int)tiles.GetTile(entity).Y * 32,
                tileTexture.Width / 30, tileTexture.Height / 32);
                spriteBatch.Draw(tileTexture, destination, entityRect, Color.White);
            }
        }

        /// <summary>
        /// Draws the visibility of a tile
        /// </summary>
        /// <param name="spriteBatch">Sprite batch being used to draw</param>
        /// <param name="tileTexture">Sprite sheet for tiles</param>
        /// <param name="destination">Where to draw tile</param>
        /// <param name="tiles">What tile to draw</param>
        public void DrawTileVisibility(SpriteBatch spriteBatch, Texture2D tileTexture, Vector2 destination, TileDictionary tiles)
        {
            if (!this._visible && this._seen)
            {
                Rectangle visRect = new Rectangle((int)tiles.GetTile("mesh").X * 32, (int)tiles.GetTile("mesh").Y * 32,
                    tileTexture.Width / 30, tileTexture.Height / 32);
                spriteBatch.Draw(tileTexture, destination, visRect, Color.White);
            }
            else if(!this._visible)
            {
                Rectangle visRect = new Rectangle((int)tiles.GetTile("dngn_unseen").X * 32, (int)tiles.GetTile("dngn_unseen").Y * 32,
                    tileTexture.Width / 30, tileTexture.Height / 32);
                spriteBatch.Draw(tileTexture, destination, visRect, Color.White);
            }
        }
    }
}
