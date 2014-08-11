using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Dungeon
{
    class Armor : Item
    {
        int _defense;
        int _durability;

        public Armor(Vector4 spriteLoc, Vector2 offset, int defense, int durability)
        {
            this._spriteLoc = spriteLoc;
            this._offset = offset;
            this._defense = defense;
            this._durability = durability;
        }

        //Testing item names
        public Armor(Vector4 spriteLoc, Vector2 offset, int defense, int durability, string name)
        {
            this._spriteLoc = spriteLoc;
            this._offset = offset;
            this._name = name;
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
