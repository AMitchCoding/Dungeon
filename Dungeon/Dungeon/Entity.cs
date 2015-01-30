using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Dungeon
{
    /// <summary>
    /// Things that are alive
    /// </summary>
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

        /// <summary>
        /// Current health property
        /// </summary>
        public int health
        {
            set { this._health = value; }
            get { return this._health; }
        }

        /// <summary>
        /// Maximum health property
        /// </summary>
        public int maxHealth
        {
            set { this._maxHealth = value; }
            get { return this._maxHealth; }
        }

        /// <summary>
        /// Name property
        /// </summary>
        public string name
        {
            set { this._name = value; }
            get { return this._name; }
        }

        /// <summary>
        /// Gets the amount of damage done during Fight()
        /// </summary>
        /// <remarks>Based on formula used by Ragnarok Online</remarks>
        /// <returns>Integer of damage</returns>
        public int GetDamage()
        {
            int damage = (int)(this._strength + (this._strength/10)^2 + (_dexterity/5) + (_luck/5) + rand.Next(Math.Min(_dexterity,_baseAttack), _baseAttack));
            Log.Write(this._name + " did " + damage + " damage.");
            return damage;
        }

        /// <summary>
        /// Creates an inventory
        /// </summary>
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

        /// <summary>
        /// Current location Property
        /// </summary>
        public Vector2 location
        {
            set { this._location = value; }
            get { return this._location; }
        }

        /// <summary>
        /// Determines movement
        /// </summary>
        /// <param name="move">Direction of move</param>
        /// <param name="grid">Dungeon floor</param>
        /// <param name="type">Type of move (one space, five spaces, or as far as possible)</param>
        /// <param name="moveToList">List of moves to be made</param>
        /// <returns>List of moves</returns>
        public List<Vector2> Movement(Vector2 move, Tile[,] grid, string type, List<Vector2> moveToList)
        {
            Tile destTile = grid[(int)(this._location.X + move.X), (int)(this._location.Y + move.Y)];
            int moveCount = 4;

            switch (type)
            {
                case ("one"):
                    MovePlayer(move, grid);
                    break;
                case ("end"):
                    while (!destTile.isWall)
                    {
                        moveToList.Add(move);
                        destTile = grid[(int)(destTile.tilePos.X + move.X), (int)(destTile.tilePos.Y + move.Y)];
                    }
                    break;
                case ("five"):
                    while (!destTile.isWall && moveCount > 0)
                    {
                        moveToList.Add(move);
                        destTile = grid[(int)(destTile.tilePos.X + move.X), (int)(destTile.tilePos.Y + move.Y)];
                        moveCount--;
                    }
                    break;
            }
            return moveToList;
        }

        /// <summary>
        /// Moves the player in the chosen direction
        /// </summary>
        /// <param name="move">Chosen direction</param>
        /// <param name="grid">Dungeon floor</param>
        /// <returns>True if successful</returns>
        public bool MovePlayer(Vector2 move, Tile[,] grid)
        {
            Vector2 newLocation = this._location + move;
            Tile newTile = grid[(int)newLocation.X, (int)newLocation.Y];
            bool validMove = true;
            bool wall = newTile.isWall;
            if (newLocation.X > 0 && newLocation.X < 24 && newLocation.Y > 0 && newLocation.Y < 24 && !wall)
            {
                if (newTile.entities.Contains("dngn_closed_door"))
                {
                    newTile.OpenDoor();
                }

                if (newTile.npc != null)
                {
                    //newTile.npc.health -= 1;
                    Combat.Fight(this, newTile.npc);
                    validMove = false;
                }
            }
            else
                validMove = false;

            if (validMove)
                this._location = newLocation;

            return validMove;
        }

        /// <summary>
        /// Goes down stairs
        /// </summary>
        /// <param name="grid">Dungeon floor</param>
        /// <returns>True if standing on stairs down</returns>
        public bool MoveDown(Tile[,] grid)
        {
            Tile currentTile = grid[(int)this._location.X, (int)this._location.Y];
            if (currentTile.entities.Contains("dngn_stone_stairs_down"))
                return true;
            else
                return false;
        }

        /// <summary>
        /// Goes up stairs
        /// </summary>
        /// <param name="grid">Dungeon floor</param>
        /// <returns>True if standing on stairs up</returns>
        public bool MoveUp(Tile[,] grid)
        {
            Tile currentTile = grid[(int)this._location.X, (int)this._location.Y];
            if (currentTile.entities.Contains("dngn_stone_stairs_up"))
                return true;
            else
                return false;
        }

        /// <summary>
        /// Mouse movement based on A* algorithm
        /// </summary>
        /// <param name="moveTo">Tile to move to</param>
        /// <param name="grid">Dungeon floor</param>
        /// <returns>List of moves</returns>
        public List<Vector2> MoveTo(Vector2 moveTo, Tile[,] grid)
        {
            Tile newTile = grid[(int)moveTo.X, (int)moveTo.Y];  //move to
            Tile currentTile = grid[(int)this._location.X, (int)this._location.Y];  //move from

            List<Vector2> moveList = new List<Vector2>(); //List of moves for player

            if (newTile.isWall)
            {
                return moveList;
            }

            int[,] board = new int[25, 25];             //Matrix for distance scores (originating from endpoint)
            for (int i = 0; i < 25; i++)
            {           //Initialize board (Probably a way to do it during array generation)
                for (int j = 0; j < 25; j++)
                {
                    board[i, j] = 65535;
                }
            }
            board[(int)moveTo.X, (int)moveTo.Y] = 0;    //Initialize ending location score
            List<Vector3> moves = new List<Vector3>();  //X loc, Y loc, and distance score
            moves.Add(new Vector3(moveTo.X, moveTo.Y, 0));  // Add the end point first, build from there.

            while (moves.Count > 0)
            {
                int x = (int)moves[0].X;
                int y = (int)moves[0].Y;
                int score = (int)moves[0].Z;
                for (int i = -1; i < 2; i++)
                {
                    for (int j = -1; j < 2; j++)
                    {
                        if (!grid[x + i, y + j].isWall)  //Don't test current tile, walls, or living npcs
                        {
                            if (score + 1 < board[x + i, y + j])
                            {
                                board[x + i, y + j] = score + 1;
                                moves.Add(new Vector3(x + i, y + j, score + 1));
                            }
                            if (x == (int)this._location.X && y == (int)this._location.Y)
                            {
                                moves.Clear();
                            }
                        }
                    }
                }
                if (moves.Count > 0)
                {
                    moves.RemoveAt(0);
                }
            }

            //Create move list, priority given to straight directional moves over diagonals
            int[] dir = new int[] { 0, -1, 1 };
            while (currentTile.tilePos != moveTo)
            {
                bool broke = false; //Sentinel for early exit
                int currPosScore = board[(int)currentTile.tilePos.X, (int)currentTile.tilePos.Y];
                Vector2 move = new Vector2();
                foreach (int m in dir)
                {
                    foreach (int n in dir)
                    {
                        if (currPosScore - 1 == board[(int)currentTile.tilePos.X + m, (int)currentTile.tilePos.Y + n])
                        {
                            move.X = m;
                            move.Y = n;
                            moveList.Add(move);
                            currentTile = grid[(int)currentTile.tilePos.X + m, (int)currentTile.tilePos.Y + n];
                            broke = true;
                            break;
                        }
                    }
                    if (broke) { break; }   //Found move, look for next move
                }
            }

            return moveList;
        }
    }
}
