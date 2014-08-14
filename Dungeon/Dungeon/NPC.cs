using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Dungeon
{
    class NPC : Entity
    {
        Vector2 _tile = new Vector2();
        int _difficulty;
        string _corpse;
        public NPC(Vector2 tile, int health, int attack, int baseDefense, int difficulty, string corpse)
        {
            this._tile = tile;
            this._health = health;
            this._baseAttack = attack;
            this._baseDefense = baseDefense;
            this._difficulty = difficulty;
            this._corpse = corpse;
        }

        public NPC(Vector2 tile, int health, int attack, int baseDefense, int difficulty, string corpse, string name)
        {
            this._tile = tile;
            this._health = health;
            this._baseAttack = attack;
            this._baseDefense = baseDefense;
            this._difficulty = difficulty;
            this._corpse = corpse;
            this._name = name;
        }

        public NPC(NPC npc)
        {
            this._tile = npc.tile;
            this._name = npc.name;
            this._health = npc.health;
            this._baseAttack = npc.attack;
            this._baseDefense = npc.baseDefense;
            this._difficulty = npc.difficulty;
            this._corpse = npc.corpse;
        }

        public Vector2 tile
        {
            get { return this._tile; }
        }

        public int attack
        {
            get { return this._baseAttack; }
        }

        public int baseDefense
        {
            get { return this._baseDefense; }
        }

        public int difficulty
        {
            get { return this._difficulty; }
        }

        public string corpse
        {
            get { return this._corpse; }
        }

        public void npcStillAlive(Tile[,] grid)
        {
            Tile npcTile = grid[(int)this._location.X, (int)this._location.Y];
            if (this.health <= 0)
            {
                npcTile.entities.Add(this.corpse);
                npcTile.npc = null;
            }
        }

        public void DrawNPC(SpriteBatch spriteBatch, Texture2D tileTexture)
        {
            Rectangle tileRect = new Rectangle((int)_tile.X * 32, (int)_tile.Y * 32,
                tileTexture.Width / 30, tileTexture.Height / 32);
            spriteBatch.Draw(tileTexture, this._location * 32, tileRect, Color.White);
        }
    }
}
