using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Dungeon
{
    class Armor
    {
        Vector4 _spriteLoc = new Vector4();
        Vector2 _offset = new Vector2();
        int _defense;
        int _durability;

        public Armor(Vector4 spriteLoc, Vector2 offset, int defense, int durability)
        {
            this._spriteLoc = spriteLoc;
            this._offset = offset;
            this._defense = defense;
            this._durability = durability;
        }

        public Armor(Armor armor)
        {
            this._spriteLoc = armor.spriteLoc;
            this._offset = armor.offset;
            this._defense = armor.defense;
            this._durability = armor.durability;
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

        public int defense
        {
            set { this._defense = value; }
            get { return this._defense; }
        }

        public int durability
        {
            set { this._durability = value; }
            get { return this._durability; }
        }
    }
}
