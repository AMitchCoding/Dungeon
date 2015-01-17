using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Dungeon
{
    class Weapon : Item
    {
        int _attack;
        int _durability;

        public Weapon(Vector4 spriteLoc, Vector2 offset, int attack, int durability)
        {
            this._spriteLoc = spriteLoc;
            this._offset = offset;
            this._attack = attack;
            this._durability = durability;
        }

        //Testing item names
        public Weapon(Vector4 spriteLoc, Vector2 offset, int attack, int durability, string name)
        {
            this._spriteLoc = spriteLoc;
            this._offset = offset;
            this._name = name;
            this._attack = attack;
            this._durability = durability;
        }

        public Weapon(Weapon weapon)
        {
            this._name = weapon.name;
            this._spriteLoc = weapon.spriteLoc;
            this._offset = weapon.offset;
            this._attack = weapon.attack;
            this._durability = weapon.durability;
        }

        public int attack
        {
            set { this._attack = value; }
            get { return this._attack; }
        }

        public int durability
        {
            set { this._durability = value; }
            get { return this._durability; }
        }
    }
}
