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

        /// <summary>
        /// NPC constructor for NPC list
        /// </summary>
        /// <param name="tile">Location on sprite sheet</param>
        /// <param name="health">Amount of hp NPC has</param>
        /// <param name="baseAttack">Attack power of NPC</param>
        /// <param name="baseDefense">Base Defense of NPC</param>
        /// <param name="difficulty">Difficulty level of NPC</param>
        /// <param name="corpse">Corpse NPC turns into when dead</param>
        public NPC(Vector2 tile, int health, int baseAttack, int baseDefense, int difficulty, string corpse)
        {
            this._tile = tile;
            this._health = health;
            this._baseAttack = baseAttack;
            this._baseDefense = baseDefense;
            this._difficulty = difficulty;
            this._corpse = corpse;
        }

        /// <summary>
        /// NPC constructor for NPC list with name
        /// </summary>
        /// <param name="tile">Location on sprite sheet</param>
        /// <param name="health">Amount of hp NPC has</param>
        /// <param name="attack">Attack power of NPC</param>
        /// <param name="baseDefense">Base Defense of NPC</param>
        /// <param name="difficulty">Difficulty level of NPC</param>
        /// <param name="corpse">Corpse NPC turns into when dead</param>
        /// <param name="name">Name of NPC</param>
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

        /// <summary>
        /// NPC constructor of actual NPC
        /// </summary>
        /// <param name="npc">NPC from the NPC list</param>
        public NPC(NPC npc)
        {
            this._tile = npc.tile;
            this._name = npc.name;
            this._health = npc.health;
            this._baseAttack = npc.baseAttack;
            this._baseDefense = npc.baseDefense;
            this._difficulty = npc.difficulty;
            this._corpse = npc.corpse;
        }

        /// <summary>
        /// Dungeon floor location property
        /// </summary>
        public Vector2 tile
        {
            get { return this._tile; }
        }

        /// <summary>
        /// Base attack property
        /// </summary>
        public int baseAttack
        {
            get { return this._baseAttack; }
        }

        /// <summary>
        /// Base defense property
        /// </summary>
        public int baseDefense
        {
            get { return this._baseDefense; }
        }

        /// <summary>
        /// Difficulty level property
        /// </summary>
        public int difficulty
        {
            get { return this._difficulty; }
        }

        /// <summary>
        /// Corpse property
        /// </summary>
        public string corpse
        {
            get { return this._corpse; }
        }

        /// <summary>
        /// Checks if NPC is still alive
        /// </summary>
        /// <param name="grid">Dungeon floor</param>
        public void npcStillAlive(Tile[,] grid)
        {
            Tile npcTile = grid[(int)this._location.X, (int)this._location.Y];
            if (this.health <= 0)
            {
                npcTile.entities.Add(this.corpse);
                npcTile.npc = null;
            }
        }

        /// <summary>
        /// Draw method for NPC
        /// </summary>
        /// <param name="spriteBatch">Sprite batch being drawn</param>
        /// <param name="tileTexture">Sprite sheet</param>
        public void DrawNPC(SpriteBatch spriteBatch, Texture2D tileTexture)
        {
            Rectangle tileRect = new Rectangle((int)_tile.X * 32, (int)_tile.Y * 32,
                tileTexture.Width / 30, tileTexture.Height / 32);
            spriteBatch.Draw(tileTexture, this._location * 32, tileRect, Color.White);
        }
    }
}
