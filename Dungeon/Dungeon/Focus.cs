using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Dungeon
{
    class Focus : Item
    {
        int _attack;
        string _school;

        public Focus(Vector4 spriteLoc, Vector2 offset, int attack)
        {
            this._spriteLoc = spriteLoc;
            this._offset = offset;
            this._attack = attack;
        }

        //Testing item names
        public Focus(Vector4 spriteLoc, Vector2 offset, int attack, string name)
        {
            this._spriteLoc = spriteLoc;
            this._offset = offset;
            this._name = name;
            this._attack = attack;
        }

        public Focus(Focus focus, string school)
        {
            this._name = focus.name;
            this._spriteLoc = focus.spriteLoc;
            this._offset = focus.offset;
            this._attack = focus.attack;
            this._school = school;
        }

        public int attack
        {
            set { this._attack = value; }
            get { return this._attack; }
        }
        public string school
        {
            set { this._school = value; }
            get { return this._school; }
        }
    }
}
