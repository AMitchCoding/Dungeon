﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Dungeon
{
    class Player : Entity
    {
        PlayerSpriteDictionary _playerSpriteSheet = new PlayerSpriteDictionary();
        string _playerRace;
        
        public Player(Tile startPos)
        {

            this.location = startPos.tilePos;
            startPos.sightBlocker = false;
            this._playerRace = "mummy_m";
            this._name = "Player";

            Log.Write("I come from the player!");

            this._entityItems["head"] = new Item(_playerSpriteSheet.GetItem("fhelm_evil"));
            this._entityItems["chest"] = new Item(_playerSpriteSheet.GetItem("chainmail3"));
            this._entityItems["back"] = new Item(_playerSpriteSheet.GetItem("blue_cape"));
            this._entityItems["hands"] = new Item(_playerSpriteSheet.GetItem("glove_blue"));
            this._entityItems["legs"] = new Item(_playerSpriteSheet.GetItem("leg_arm_steel"));
            this._entityItems["feet"] = new Item(_playerSpriteSheet.GetItem("short_brown_shoes"));
            this._entityItems["main_hand"] = new Item(_playerSpriteSheet.GetItem("spiked_flail"));
            this._entityItems["off_hand"] = new Item(_playerSpriteSheet.GetItem("book_white"));

            this._health = 100;
            this._maxHealth = 100;
            this._baseAttack = 10;
            this._baseDefense = 10;
            this._strength = 10;
            this._dexterity = 10;
            this._intelligence = 10;
            this._luck = 10;
        }
        
        public void Kill()
        {
        }

        public bool MonsterCheck(Tile[,] grid)
        {
            Tile tile = null;
            int minX = -5;
            int minY = -5;
            int maxX = 5;
            int maxY = 5;

            if (this._location.X <= 4)
                minX = (int)this._location.X * -1;
            if (this._location.Y <= 4)
                minY = (int)this._location.Y * -1;
            if (this._location.X >= 20)
                maxX = 24 - (int)this._location.X;
            if (this._location.Y >= 20)
                maxY = 24 - (int)this._location.Y;

            for (int i = minX; i <= maxX; i++)
            {
                for (int j = minY; j <= maxY; j++)
                {
                    tile = grid[(int)this._location.X + i, (int)this._location.Y + j];
                    if (tile.npc != null && tile.visible)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        internal void DrawPlayer(SpriteBatch spriteBatch, Texture2D tileTexture, Vector2 destination)
        {
            spriteBatch.Draw(tileTexture, destination, _playerSpriteSheet.GetSprite("shadow"), Color.White);
            spriteBatch.Draw(tileTexture, new Vector2(destination.X + this._entityItems["back"].offset.X, destination.Y + this._entityItems["back"].offset.Y), _playerSpriteSheet.GetSprite(this._entityItems["back"].spriteLoc), Color.White);            
            spriteBatch.Draw(tileTexture, destination, _playerSpriteSheet.GetSprite(_playerRace), Color.White);

            spriteBatch.Draw(tileTexture, new Vector2(destination.X + this._entityItems["head"].offset.X, destination.Y + this._entityItems["head"].offset.Y), _playerSpriteSheet.GetSprite(this._entityItems["head"].spriteLoc), Color.White);
            spriteBatch.Draw(tileTexture, new Vector2(destination.X + this._entityItems["chest"].offset.X, destination.Y + this._entityItems["chest"].offset.Y), _playerSpriteSheet.GetSprite(this._entityItems["chest"].spriteLoc), Color.White);
            spriteBatch.Draw(tileTexture, new Vector2(destination.X + this._entityItems["hands"].offset.X, destination.Y + this._entityItems["hands"].offset.Y), _playerSpriteSheet.GetSprite(this._entityItems["hands"].spriteLoc), Color.White);
            spriteBatch.Draw(tileTexture, new Vector2(destination.X + this._entityItems["legs"].offset.X, destination.Y + this._entityItems["legs"].offset.Y), _playerSpriteSheet.GetSprite(this._entityItems["legs"].spriteLoc), Color.White);
            spriteBatch.Draw(tileTexture, new Vector2(destination.X + this._entityItems["feet"].offset.X, destination.Y + this._entityItems["feet"].offset.Y), _playerSpriteSheet.GetSprite(this._entityItems["feet"].spriteLoc), Color.White);
            spriteBatch.Draw(tileTexture, new Vector2(destination.X + this._entityItems["main_hand"].offset.X, destination.Y + this._entityItems["main_hand"].offset.Y), _playerSpriteSheet.GetSprite(this._entityItems["main_hand"].spriteLoc), Color.White);
            spriteBatch.Draw(tileTexture, new Vector2(destination.X + this._entityItems["off_hand"].offset.X, destination.Y + this._entityItems["off_hand"].offset.Y), _playerSpriteSheet.GetSprite(this._entityItems["off_hand"].spriteLoc), Color.White);
        }
    }
}
