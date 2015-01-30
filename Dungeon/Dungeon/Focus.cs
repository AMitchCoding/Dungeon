using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Dungeon
{
    /// <summary>
    /// Item having spells to cast
    /// </summary>
    class Focus : Item
    {
        int _attack;
        string _school;

        /// <summary>
        /// Focus constructor for focus list
        /// </summary>
        /// <param name="spriteLoc">Location of sprite on spritesheet</param>
        /// <param name="offset">Offset on spritesheet</param>
        /// <param name="attack">Damage focus can deal</param>
        public Focus(Vector4 spriteLoc, Vector2 offset, int attack)
        {
            this._spriteLoc = spriteLoc;
            this._offset = offset;
            this._attack = attack;
        }

        /// <summary>
        /// Focus constructor for focus list with name
        /// </summary>
        /// <param name="spriteLoc">Location of sprite on spritesheet</param>
        /// <param name="offset">Offset on spritesheet</param>
        /// <param name="attack">Damage focus can deal</param>
        /// <param name="name">Name of focus</param>
        public Focus(Vector4 spriteLoc, Vector2 offset, int attack, string name)
        {
            this._spriteLoc = spriteLoc;
            this._offset = offset;
            this._name = name;
            this._attack = attack;
        }
        
        /// <summary>
        /// Focus constructor for focus item
        /// </summary>
        /// <param name="focus">Focus from focus list</param>
        /// <param name="school">School focus is associated with</param>
        public Focus(Focus focus, string school)
        {
            this._name = focus.name;
            this._spriteLoc = focus.spriteLoc;
            this._offset = focus.offset;
            this._attack = focus.attack;
            this._school = school;
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
        /// Schoolk property
        /// </summary>
        public string school
        {
            set { this._school = value; }
            get { return this._school; }
        }
    }
}