using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace Dungeon
{
    class Edge
    {
        Vector2 _vA, _vB;
        float _weight;
        List<Edge> _adjMSTEdges = new List<Edge>();
        bool hasAdj = false;
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

        public bool CompareEdge(Edge testEdge)
        {
            if (this._vA.Equals(testEdge.vA) && this._vB.Equals(testEdge.vB))
                return true;
            else
                return false;
        }

        public List<Vector2> VertexList()
        {
            List<Vector2> vList = new List<Vector2>();
            vList.Add(this._vA);
            vList.Add(this._vB);
            return vList;
        }

        public void FindAdjacentEdges(List<Edge> edges)
        {
            foreach (Edge nextEdge in edges)
            {
                if (nextEdge.VertexList().Contains(this._vA) ||
                    nextEdge.VertexList().Contains(this._vB))
                {
                    this._adjMSTEdges.Add(nextEdge);
                }
            }
        }

        public bool CheckTransEdge(List<Edge> edges)
        {
            foreach (Edge edge in edges)
            {
                if (this.CompareEdge(edge))
                    return true;
            }
            return false;
        }
        public Vector2 vA
        {
            get { return this._vA; }
        }
        public Vector2 vB
        {
            get { return this._vB; }
        }
        public float weight
        {
            get { return this._weight; }
        }
        public List<Edge> adjMSTEdges
        {
            get { return this._adjMSTEdges; }
        }
    }
}