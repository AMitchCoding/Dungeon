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
        List<Vector2> roomNodes = new List<Vector2>();
        List<Triangle> triangulation = new List<Triangle>();
        List<Triangle> deadTriangles = new List<Triangle>();
        List<Edge> edgesMST = new List<Edge>();
        CircleTest tester = new CircleTest();
        Vector2 tl = new Vector2(0, 0);
        Vector2 tr = new Vector2(50, 0);
        Vector2 bl = new Vector2(0, 50);
        private Tile[,] _grid = new Tile[25,25];
        int attempts = 1;
        double dungeonArea = 625.0;
        double walls = 625.0;


        public Dungeon()
        {
            for (int x = 0; x < 25; x++)
            {
                for (int y = 0; y < 25; y++)
                {
                    _grid[x, y] = new Tile(new Vector2(x, y));
                    if (x == 0 || y == 0 || x == 24 || y == 24)
                        _grid[x, y].isEdge = true;
                }
            }

            MakeRoom(MakeRectangle());

            while (((walls / dungeonArea) > .50) && attempts != 5000)
            {
                TestRoom();
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

            DTGeneration();
            MSTGeneration();

        }

        private void MSTGeneration()
        {
            HashSet<Edge> edges = new HashSet<Edge>();
            Stack<Edge> sortEdges = new Stack<Edge>();
            int addedEdges = 0;
            foreach (Triangle triangle in triangulation)
            {
                foreach (Edge edge in triangle.edges)
                {
                    edges.Add(edge);
                }
            }

            while (edges.Count > 0)
            {
                Edge nextEdge = null;
                foreach (Edge edge in edges)
                {
                    if ((nextEdge == null) || (nextEdge.weight < edge.weight))
                    {
                        nextEdge = edge;
                    }
                }
                sortEdges.Push(nextEdge);
                edges.Remove(nextEdge);
            }

            List<Edge> transEdges = new List<Edge>();

            while(addedEdges < roomNodes.Count - 1)
            {
                Edge testEdge = null;
                bool trans = false;

                testEdge = sortEdges.Pop();
                testEdge.FindAdjacentEdges(edgesMST);

                foreach(Edge edge in transEdges)
                {
                    if (testEdge.CheckTransEdge(edge))
                    {
                        trans = true;
                        break;
                    }
                }

                if(!trans)
                {
                    edgesMST.Add(testEdge);
                    transEdges.Add(testEdge);
                    addedEdges++;
                    //Breaks because transEdges is diff due to having been added to.
                    foreach (Edge edgeA in transEdges)
                    {
                        foreach (Edge edgeB in transEdges)
                        {
                            if(!edgeA.CheckTransEdge(edgeB))
                            {
                                if(edgeA.vA.Equals(edgeB.vA))
                                {
                                    transEdges.Add(new Edge(edgeA.vB, edgeB.vB));
                                    break;
                                }
                                else if(edgeA.vA.Equals(edgeB.vB))
                                {
                                    transEdges.Add(new Edge(edgeA.vB, edgeB.vA)); 
                                    break;
                                }
                                else if(edgeA.vB.Equals(edgeB.vA))
                                {
                                    transEdges.Add(new Edge(edgeA.vA, edgeB.vB));
                                    break;
                                }
                                else if(edgeA.vB.Equals(edgeB.vB))
                                {
                                    transEdges.Add(new Edge(edgeA.vA, edgeB.vA));
                                    break;
                                }
                            }
                        }
                    }
                }                
            }
        }

            

        private void DTGeneration()
        {
            triangulation.Add(new Triangle(new Edge(tl, tr), new Edge(tl, bl), new Edge(tr, bl)));

            foreach (Vector2 point in roomNodes)
            {
                List<Triangle> badTriangles = new List<Triangle>();
                List<Edge> polygon = new List<Edge>();
                List<Edge> badEdges = new List<Edge>();
                bool sharedEdge = false;

                foreach (Triangle testTri in triangulation)
                {
                    if (tester.CircleTester(testTri.vA, testTri.vB, testTri.vC, point))
                    {
                        badTriangles.Add(testTri);
                    }
                    
                }
                foreach (Triangle badTri in badTriangles)
                {
                    foreach (Edge badTriEdge in badTri.edges)
                    {
                        foreach (Triangle testBadTri in badTriangles)
                        {
                            if (!(badTri.Equals(testBadTri)))
                            {
                                if (testBadTri.edges.Contains(badTriEdge))
                                {
                                    sharedEdge = true;
                                    break;
                                }
                            }
                        }
                        if (!sharedEdge)
                            polygon.Add(badTriEdge);
                        sharedEdge = false;
                    }
                }
                foreach (Triangle badTri in badTriangles)
                {
                    triangulation.Remove(badTri);
                }
                foreach (Edge polyEdge in polygon)
                {
                    Edge newEdge1 = new Edge(polyEdge.vA, point);
                    Edge newEdge2 = new Edge(polyEdge.vB, point);

                    foreach(Triangle testTri in triangulation)
                    {
                        foreach(Edge testEdge in testTri.edges)
                        {
                            if (testEdge.CompareEdge(newEdge1))
                            {
                                newEdge1 = testEdge;
                            }
                            if (testEdge.CompareEdge(newEdge2))
                            {
                                newEdge2 = testEdge;
                            }
                        }
                    }

                    triangulation.Add(new Triangle(polyEdge, newEdge1, newEdge2));
                }
            }
            foreach(Triangle superTri in triangulation)
            {
                if(superTri.SuperTriCheck(tl) || superTri.SuperTriCheck(tr) || superTri.SuperTriCheck(bl))
                    deadTriangles.Add(superTri);
            }
            foreach (Triangle deadTriangle in deadTriangles)
                triangulation.Remove(deadTriangle);
        }

        private void TestRoom()
        {
            Rectangle testRoom = new Rectangle();
            Rectangle testRoomInner = new Rectangle();
            bool validRoom = true;

            testRoom = MakeRectangle();
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
                            _grid[x, y].sightBlocker = false;
                            _grid[x, y].isWall = false;
                        }
                    }
                }


            rooms.Add(roomRect);
            roomNodes.Add(new Vector2(roomRect.Center.X, roomRect.Center.Y));
            walls -= (double)(roomRect.Width - 2) * (double)(roomRect.Height - 2);
        }

        public Rectangle MakeRectangle()
        {
            Rectangle newRect = new Rectangle(rand.Next(0, _grid.GetLength(0) - 5), rand.Next(1, _grid.GetLength(1) - 5), rand.Next(5, 11), rand.Next(5, 11));
            if (newRect.X + newRect.Width - 1 > 24)
            {
                newRect.Width -= newRect.X + newRect.Width - 1 - 24; 
            }
            if (newRect.Y + newRect.Height - 1 > 24)
            {
                newRect.Height -= newRect.Y + newRect.Height - 1 - 24;
            }
            return newRect;
        }



        public Tile[,] grid
        {
            get { return this._grid; }
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
