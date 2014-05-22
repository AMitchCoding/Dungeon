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
        private Vector2 _tilePos = new Vector2(0, 0);
        private string _tileName = "dngn_rock_wall_dark_gray";
        List<string> _items = new List<string>();
        List<string> _entities = new List<string>();
        NPC _npc = null;

        public Tile(Vector2 tilePos)
        {
            this._tilePos = tilePos;
        }

        public Vector2 tilePos
        {
            get { return this._tilePos; }
        }

        public NPC npc
        {
            set { this._npc = value; }
            get { return this._npc; }
        }

        public string tileName
        {
            set { this._tileName = value; }
            get { return this._tileName; }
        }

        public bool isEdge
        {
            set { this._isEdge = value; }
            get { return this._isEdge; }
        }

        public bool isWall
        {
            set { this._isWall = value; }
            get { return this._isWall; }
        }

        public void AddItem(string item)
        {
            this._items.Add(item);
        }

        public List<string> entities
        {
            get { return this._entities; }
        }

        public void AddEntity(string entity)
        {
            this._entities.Add(entity);
        }

        public void RemoveEntity(string entity)
        {
            this._entities.Remove(entity);
        }

        public void OpenDoor()
        {
            if(this._entities.Contains("dngn_closed_door"))
            {
                this._entities.Remove("dngn_closed_door");
                this._entities.Add("dngn_open_door");
            }
        }

        public void CloseDoor()
        {
            if(this._entities.Contains("dngn_open_door"))
            {
                this._entities.Remove("dngn_open_door");
                this._entities.Add("dngn_closed_door");
            }
        }


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
    }
}
