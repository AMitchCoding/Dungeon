using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Dungeon
{
    class NPC
    {
        Vector2 _tile = new Vector2();
        Vector2 _location = new Vector2();
        int _health;
        int _attack;
        int _defense;
        int _difficulty;
        string _corpse;
        public NPC(Vector2 tile, int health, int attack, int defense, int difficulty, string corpse)
        {
            this._tile = tile;
            this._health = health;
            this._attack = attack;
            this._defense = defense;
            this._difficulty = difficulty;
            this._corpse = corpse;
        }

        public NPC(NPC npc)
        {
            this._tile = npc.tile;
            this._health = npc.health;
            this._attack = npc.attack;
            this._defense = npc.defense;
            this._difficulty = npc.difficulty;
            this._corpse = npc.corpse;
        }

        public Vector2 tile
        {
            get { return this._tile; }
        }

        public Vector2 location
        {
            set { this._location = value; }
            get { return this._location; }
        }

        public int health
        {
            set { this._health = value; }
            get { return this._health; }
        }

        public int attack
        {
            get { return this._attack; }
        }

        public int defense
        {
            get { return this._defense; }
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
