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

        /// <summary>
        /// Item constructor for item list
        /// </summary>
        /// <param name="spriteLoc">Location of sprite on spritesheet</param>
        /// <param name="offset">Offset on spritesheet</param>
        public Item(Vector4 spriteLoc, Vector2 offset)
        {
            this._spriteLoc = spriteLoc;
            this._offset = offset;
        }

        /// <summary>
        /// Item constructor for item
        /// </summary>
        /// <param name="item">Item from item list</param>
        public Item(Item item)
        {
            this._spriteLoc = item.spriteLoc;
            this._offset = item.offset;
            this._name = item.name;
        }

        /// <summary>
        /// Sprite location property
        /// </summary>
        public Vector4 spriteLoc
        {
            set { this._spriteLoc = value; }
            get { return this._spriteLoc; }
        }

        /// <summary>
        /// Spritesheet offset property
        /// </summary>
        public Vector2 offset
        {
            set { this._offset = value; }
            get { return this._offset; }
        }

        /// <summary>
        /// Name property
        /// </summary>
        public string name
        {
            set { this._name = value; }
            get { return this._name; }
        }

    }
}
