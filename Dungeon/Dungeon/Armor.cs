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

        /// <summary>
        /// Armor constructor for armor list
        /// </summary>
        /// <param name="spriteLoc">Location of sprite on spritesheet</param>
        /// <param name="offset">Offset of sprite on spritesheet</param>
        /// <param name="defense">Defense value for armor</param>
        /// <param name="durability">Durability value for armor</param>
        public Armor(Vector4 spriteLoc, Vector2 offset, int defense, int durability)
        {
            this._spriteLoc = spriteLoc;
            this._offset = offset;
            this._defense = defense;
            this._durability = durability;
        }

        /// <summary>
        /// Armor constructor for armor list with name
        /// </summary>
        /// <param name="spriteLoc">Location of sprite on spritesheet</param>
        /// <param name="offset">Offset of sprite on spritesheet</param>
        /// <param name="defense">Defense value for armor</param>
        /// <param name="durability">Durability value for armor</param>
        /// <param name="name">Name of armor</param>
        public Armor(Vector4 spriteLoc, Vector2 offset, int defense, int durability, string name)
        {
            this._name = name;
            this._spriteLoc = spriteLoc;
            this._offset = offset;
            this._defense = defense;
            this._durability = durability;
        }

        /// <summary>
        /// Armor constructor for armor item
        /// </summary>
        /// <param name="armor">Armor from armor list</param>
        public Armor(Armor armor)
        {
            this._name = armor.name;
            this._spriteLoc = armor.spriteLoc;
            this._offset = armor.offset;
            this._defense = armor.defense;
            this._durability = armor.durability;
        }

        /// <summary>
        /// Defense property
        /// </summary>
        public int defense
        {
            set { this._defense = value; }
            get { return this._defense; }
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
