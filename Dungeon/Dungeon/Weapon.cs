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

        /// <summary>
        /// Weapon constructor for armor list
        /// </summary>
        /// <param name="spriteLoc">Location of sprite on spritesheet</param>
        /// <param name="offset">Offset of sprite on spritesheet</param>
        /// <param name="attack">Attack value for weapon</param>
        /// <param name="durability">Durability value for weapon</param>
        public Weapon(Vector4 spriteLoc, Vector2 offset, int attack, int durability)
        {
            this._spriteLoc = spriteLoc;
            this._offset = offset;
            this._attack = attack;
            this._durability = durability;
        }

        /// <summary>
        /// Weapon constructor for armor list with name
        /// </summary>
        /// <param name="spriteLoc">Location of sprite on spritesheet</param>
        /// <param name="offset">Offset of sprite on spritesheet</param>
        /// <param name="attack">Attack value for weapon</param>
        /// <param name="durability">Durability value for weapon</param>
        /// <param name="name">Name of weapon</param>
        public Weapon(Vector4 spriteLoc, Vector2 offset, int attack, int durability, string name)
        {
            this._spriteLoc = spriteLoc;
            this._offset = offset;
            this._name = name;
            this._attack = attack;
            this._durability = durability;
        }

        /// <summary>
        /// Weapon constructor for weapon item
        /// </summary>
        /// <param name="weapon">Weapon from weapon list</param>
        public Weapon(Weapon weapon)
        {
            this._name = weapon.name;
            this._spriteLoc = weapon.spriteLoc;
            this._offset = weapon.offset;
            this._attack = weapon.attack;
            this._durability = weapon.durability;
        }

        /// <summary>
        /// Attack property
        /// </summary>
        public int attack
        {
            set { this._attack = value; }
            get { return this._attack; }
        }

        /// <summary>
        /// Durability property
        /// </summary>
        public int durability
        {
            set { this._durability = value; }
            get { return this._durability; }
        }
    }
}
