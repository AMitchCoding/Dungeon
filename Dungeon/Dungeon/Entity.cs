using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Dungeon
{
    class Entity
    {
        Random rand = new Random();
        public Vector2 _location = new Vector2();
        public bool _isAlive = true;
        public string _name;
        public int _health;
        public int _maxHealth;
        public int _baseAttack;
        public int _baseDefense;
        public int _strength;
        public int _dexterity;
        public int _intelligence;
        public int _luck;
        public Dictionary<string, Item> _entityItems = new Dictionary<string, Item>();

        public Entity()
        {

        }

        public int health
        {
            set { this._health = value; }
            get { return this._health; }
        }
        public int maxHealth
        {
            set { this._maxHealth = value; }
            get { return this._maxHealth; }
        }
        public string name
        {
            set { this._name = value; }
            get { return this._name; }
        }

        public int GetDamage()
        {
            int damage = (int)(this._strength + (this._strength/10)^2 + (_dexterity/5) + (_luck/5) + rand.Next(Math.Min(_dexterity,_baseAttack), _baseAttack));
            Log.Write(this._name + " did " + damage + " damage.");
            return damage;
        }

        private void InitInventory()
        {
            this._entityItems.Add("head", null);
            this._entityItems.Add("chest", null);
            this._entityItems.Add("back", null);
            this._entityItems.Add("hands", null);
            this._entityItems.Add("legs", null);
            this._entityItems.Add("feet", null);
            this._entityItems.Add("main_hand", null);
            this._entityItems.Add("off_hand", null);
            for(int i = 1; i <= 1000; i++)
            {
                this._entityItems.Add(i.ToString(), null);
            }
        }
    }
}
