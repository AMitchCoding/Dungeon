using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace Dungeon
{
    class Dungeon
    {
        Random rand = new Random((int)DateTime.Now.Ticks);
        List<Rectangle> rooms = new List<Rectangle>();
        Tile _upStairs;
        Tile _downStairs;
        Tile _monsTile;
        List<NPC> _npcs = new List<NPC>();
        private Tile[,] _grid = new Tile[25,25];
        bool validWall = false;
        int newDirection = 0; //NESW
        List<int> possibleDoors = new List<int>();
        int dngn_floorCheckX = 1;
        int dngn_floorCheckY = 1;
        int attempts = 1;
        double dungeonArea = 625.0;
        double walls = 625.0;

        public Dungeon(NPCDictionary npcDictionary)
        {
            this._npcs.Add(new NPC(npcDictionary.GetNPC("mons_asmodeus")));
            this._npcs.Add(new NPC(npcDictionary.GetNPC("mons_cerebov")));
            this._npcs.Add(new NPC(npcDictionary.GetNPC("mons_glowing_shapeshifter")));
            for (int x = 0; x < 25; x++)
            {
                for (int y = 0; y < 25; y++)
                {
                    _grid[x, y] = new Tile(new Vector2(x,y));
                    if (x == 0 || y == 0 || x == 24 || y == 24)
                        _grid[x, y].isEdge = true;
                }
            }
            Rectangle roomRect = new Rectangle(rand.Next(0, _grid.GetLength(0) - 5), rand.Next(1, _grid.GetLength(1) - 5), rand.Next(5, 11), rand.Next(5, 11));
            MakeRoom(roomRect);

            while (((walls / dungeonArea) > .25) && attempts != 5000)
            {
                while (!validWall)
                {
                    dngn_floorCheckX = rand.Next(_grid.GetLength(0));
                    dngn_floorCheckY = rand.Next(_grid.GetLength(1));
                    if (_grid[dngn_floorCheckX, dngn_floorCheckY].tileName == "dngn_floor")
                    {
                        if (_grid[dngn_floorCheckX, dngn_floorCheckY - 1].tileName == "dngn_rock_wall_dark_gray")
                            possibleDoors.Add(1);
                        if (_grid[dngn_floorCheckX + 1, dngn_floorCheckY].tileName == "dngn_rock_wall_dark_gray")
                            possibleDoors.Add(2);
                        if (_grid[dngn_floorCheckX, dngn_floorCheckY + 1].tileName == "dngn_rock_wall_dark_gray")
                            possibleDoors.Add(3);
                        if (_grid[dngn_floorCheckX - 1, dngn_floorCheckY].tileName == "dngn_rock_wall_dark_gray")
                            possibleDoors.Add(4);

                        if (possibleDoors.Count > 0)
                            validWall = true;
                    }
                }

                newDirection = possibleDoors[rand.Next(possibleDoors.Count)];
                possibleDoors.Clear();
                validWall = false;

                if(rand.Next(11) > 1)
                {
                        TestRoom(newDirection, false);
                }
                else
                {
                        TestRoom(newDirection, true);
                }

                attempts++;
            }

            while (true)
            {
                _upStairs = _grid[rand.Next(25), rand.Next(25)];
                if (_upStairs.tileName == "dngn_floor" && _upStairs.entities.Count() == 0)
                {
                    _upStairs.AddEntity("dngn_stone_stairs_up");
                    break;
                }
            }
            while (true)
            {
                _downStairs = _grid[rand.Next(25), rand.Next(25)];
                if (_downStairs.tileName == "dngn_floor" && _downStairs.entities.Count() == 0)
                {
                    _downStairs.AddEntity("dngn_stone_stairs_down");
                    break;
                }
            }

            foreach(NPC monster in _npcs)
            {
                while (true)
                {
                    _monsTile = _grid[rand.Next(25), rand.Next(25)];
                    if (_monsTile.tileName == "dngn_floor" && _monsTile.entities.Count() == 0 && _monsTile.npc == null)
                    {
                        monster.location = _monsTile.tilePos;
                        _monsTile.npc = monster;
                        break;
                    }
                }
            }


        }

        private void TestRoom(int newDirection, bool isCorridor)
        {
            Rectangle testRoom = new Rectangle();
            Rectangle testRoomInner = new Rectangle();
            bool validRoom = true;
            int yRandMax = 0;
            int yRandMin = 0;
            int xRandMax = 0;
            int xRandMin = 0;

            if (dngn_floorCheckY - 5 < 0)
                yRandMax = 0;
            else
                yRandMax = dngn_floorCheckY - 5;

            if (dngn_floorCheckY - 10 < 0)
                yRandMin = 0;
            else
                yRandMin = dngn_floorCheckY - 10;

            if (dngn_floorCheckX - 5 < 0)
                xRandMax = 0;
            else
                xRandMax = dngn_floorCheckX - 5;

            if (dngn_floorCheckX - 10 < 0)
                xRandMin = 0;
            else
                xRandMin = dngn_floorCheckX - 10;

            switch(newDirection)
            {


                case 1:
                    if (isCorridor)
                    {
                        testRoom = new Rectangle(dngn_floorCheckX - 1, rand.Next(yRandMax), 3, 0);
                        testRoom.Height = dngn_floorCheckY - testRoom.Y;
                    }
                    else
                    {
                        testRoom = new Rectangle(rand.Next(dngn_floorCheckX), rand.Next(yRandMin, yRandMax), 0, 0);
                        testRoom.Width = rand.Next(dngn_floorCheckX - testRoom.X + 2, dngn_floorCheckX + 5);
                        testRoom.Height = dngn_floorCheckY - testRoom.Y;
                    }
                    break;
                case 2:
                    if (isCorridor)
                    {
                        testRoom = new Rectangle(dngn_floorCheckX + 1, dngn_floorCheckY - 1, rand.Next(5,11), 3);
                    }
                    else
                    {
                        testRoom = new Rectangle(dngn_floorCheckX + 1, rand.Next(yRandMax), rand.Next(5, 11), 0);
                        testRoom.Height = rand.Next(dngn_floorCheckY - testRoom.Y + 2, dngn_floorCheckY + 5);
                    }
                    break;
                case 3:
                    if (isCorridor)
                    {
                        testRoom = new Rectangle(dngn_floorCheckX - 1, dngn_floorCheckY + 1, 3, rand.Next(5, 11));
                    }
                    else
                    {
                        testRoom = new Rectangle(rand.Next(xRandMax), dngn_floorCheckY + 1, 0, rand.Next(5, 11));
                        testRoom.Width = rand.Next(dngn_floorCheckX - testRoom.X + 2, dngn_floorCheckX + 5);
                    }
                    break;
                case 4:
                    if (isCorridor)
                    {
                        testRoom = new Rectangle(rand.Next(xRandMax), dngn_floorCheckY - 1, 0, 3);
                        testRoom.Width = dngn_floorCheckX - testRoom.X;
                    }
                    else
                    {
                        testRoom = new Rectangle(rand.Next(xRandMin, xRandMax), rand.Next(dngn_floorCheckY), 0, 0);
                        testRoom.Width = dngn_floorCheckX - testRoom.X;
                        testRoom.Height = rand.Next(dngn_floorCheckY - testRoom.Y + 2, dngn_floorCheckY + 5);
                    }
                    break;
            }

            testRoomInner = new Rectangle((int)testRoom.X + 1, (int)testRoom.Y + 1, (int)testRoom.Width - 2, (int)testRoom.Height - 2);

            foreach (Rectangle room in rooms)
            {
                if (testRoomInner.Intersects(room) || testRoom.Width < 3 || testRoom.Height < 3)
                {
                    validRoom = false;
                }
            }

            if (validRoom) 
            { 
                MakeRoom(testRoom);
                switch (newDirection)
                {
                    case 1:
                        if (!_grid[dngn_floorCheckX, dngn_floorCheckY - 1].isEdge && !_grid[dngn_floorCheckX, dngn_floorCheckY - 2].isEdge)
                        {
                            Tile doorTile = _grid[dngn_floorCheckX, dngn_floorCheckY - 1];
                            doorTile.tileName = "dngn_floor";
                            doorTile.AddEntity("dngn_closed_door");
                            doorTile.isWall = false;
                        }
                        break;
                    case 2:
                        if (!_grid[dngn_floorCheckX + 1, dngn_floorCheckY].isEdge && !_grid[dngn_floorCheckX + 2, dngn_floorCheckY].isEdge)
                        {
                            Tile doorTile = _grid[dngn_floorCheckX + 1, dngn_floorCheckY];
                            doorTile.tileName = "dngn_floor";
                            doorTile.AddEntity("dngn_closed_door");
                            doorTile.isWall = false;
                        }
                        break;
                    case 3:
                        if(!_grid[dngn_floorCheckX, dngn_floorCheckY + 1].isEdge && !_grid[dngn_floorCheckX, dngn_floorCheckY + 2].isEdge)
                        {
                            Tile doorTile = _grid[dngn_floorCheckX, dngn_floorCheckY + 1];
                            doorTile.tileName = "dngn_floor";
                            doorTile.AddEntity("dngn_closed_door");
                            doorTile.isWall = false;
                        }
                        break;
                    case 4:
                        if(!_grid[dngn_floorCheckX - 1, dngn_floorCheckY].isEdge && !_grid[dngn_floorCheckX - 2, dngn_floorCheckY].isEdge)
                        {
                            Tile doorTile = _grid[dngn_floorCheckX - 1, dngn_floorCheckY];
                            doorTile.tileName = "dngn_floor";
                            doorTile.AddEntity("dngn_closed_door");
                            doorTile.isWall = false;
                        }
                        break;
                }
            }

        }

        public void MakeRoom(Rectangle roomRect)
        {            
            for (int x = 0; x < 25; x++)
                {
                    for (int y = 0; y < 25; y++)
                    {
                        if ((x >= roomRect.Left + 1 && x < roomRect.Width - 1 + roomRect.Left) &&
                            (y >= roomRect.Top + 1 && y < roomRect.Height - 1 + roomRect.Top) &&
                            !_grid[x, y].isEdge)
                        {
                            _grid[x, y].tileName = "dngn_floor";
                            _grid[x, y].isWall = false;
                        }
                    }
                }


            rooms.Add(roomRect);
            walls -= (double)(roomRect.Width - 2) * (double)(roomRect.Height - 2);
        }

        public Tile[,] grid
        {
            get { return this._grid; }
        }
        public List<NPC> npcs
        {
            get { return this._npcs; }
        }

        public Tile upStairs
        {
            get { return this._upStairs; }
        }

        public Tile downStairs
        {
            get { return this._downStairs; }
        }


    }
}
