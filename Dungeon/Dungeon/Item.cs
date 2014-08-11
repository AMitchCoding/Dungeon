using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace Dungeon
{
    class Item
    {
        public Vector4 _spriteLoc = new Vector4();
        public Vector2 _offset = new Vector2(0,0);
        public string _name;

        public Item()
        {

        }

        public Item(Vector4 spriteLoc, Vector2 offset)
        {
            this._spriteLoc = spriteLoc;
            this._offset = offset;
        }

        public Item(Item item)
        {
            this._spriteLoc = item.spriteLoc;
            this._offset = item.offset;
        }

        public Vector4 spriteLoc
        {
            set { this._spriteLoc = value; }
            get { return this._spriteLoc; }
        }

        public Vector2 offset
        {
            set { this._offset = value; }
            get { return this._offset; }
        }

        public string name
        {
            set { this._name = value; }
            get { return this._name; }
        }
    }
}
