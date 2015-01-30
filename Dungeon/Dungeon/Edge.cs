using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace Dungeon
{
    /// <summary>
    /// Edge used in minimum spanning tree logic
    /// </summary>
    class Edge
    {
        Vector2 _vA, _vB;
        float _weight;
        bool hasAdj = false;

        /// <summary>
        /// Edge constructor
        /// </summary>
        /// <remarks>Edge points are determined in the following order
        /// Smallest x value of points
        /// Smallest y value of points</remarks>
        /// <param name="a">Edge point a</param>
        /// <param name="b">Edge point b</param>
        public Edge(Vector2 a, Vector2 b)
        {
            if (a.X < b.X)
            {
                this._vA = a;
                this._vB = b;
            }
            else if (a.X > b.X)
            {
                this._vA = b;
                this._vB = a;
            }
            else
            {
                if (a.Y < b.Y)
                {
                    this._vA = a;
                    this._vB = b;
                }
                else if (a.Y > b.Y)
                {
                    this._vA = b;
                    this._vB = a;
                }
                else
                {
                    throw new Exception("You dun goofed kid");
                }
            }
            this._weight = Vector2.Distance(this._vA, this._vB);
        }

        /// <summary>
        /// Compares this edge to another edge to see if they are the same
        /// </summary>
        /// <param name="testEdge">Edge to check for eqaulity</param>
        /// <returns>True if edges are the same</returns>
        public bool CompareEdge(Edge testEdge)
        {
            if (this._vA.Equals(testEdge.vA) && this._vB.Equals(testEdge.vB))
                return true;
            else
                return false;
        }

        /// <summary>
        /// Gets a list of the edge's points
        /// </summary>
        /// <returns>List of Vector 2s</returns>
        public List<Vector2> VertexList()
        {
            List<Vector2> vList = new List<Vector2>();
            vList.Add(this._vA);
            vList.Add(this._vB);
            return vList;
        }

        /// <summary>
        /// Checks this edge to see if it is in the list of bad edges
        /// </summary>
        /// <param name="edges">List of bad edges</param>
        /// <returns>True if it is in the list</returns>
        public bool CheckBadEdges(List<Edge> edges)
        {
            foreach (Edge edge in edges)
            {
                if (this.CompareEdge(edge))
                    return true;
            }
            return false;
        }

        /// <summary>
        /// A point property
        /// </summary>
        public Vector2 vA
        {
            get { return this._vA; }
        }
        /// <summary>
        /// B point property
        /// </summary>
        public Vector2 vB
        {
            get { return this._vB; }
        }

        /// <summary>
        /// Weight property
        /// </summary>
        public float weight
        {
            get { return this._weight; }
        }
    }
}