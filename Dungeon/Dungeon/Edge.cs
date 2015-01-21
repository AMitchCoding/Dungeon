using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace Dungeon
{
    class Edge
    {
        Vertex _vA, _vB;
        float _weight;
        List<Edge> _adjMSTEdges = new List<Edge>();
        bool hasAdj = false;
        public Edge(Vertex a, Vertex b)
        {
            if(a.pos.X < b.pos.X)
            {
                this._vA = a;
                this._vB = b;
            }
            else if(a.pos.X > b.pos.X)
            {
                this._vA = b;
                this._vB = a;
            }
            else
            {
                if (a.pos.Y < b.pos.Y)
                {
                    this._vA = a;
                    this._vB = b;
                }
                else if (a.pos.Y > b.pos.Y)
                {
                    this._vA = b;
                    this._vB = a;
                }
                else
                {
                    throw new Exception("You dun goofed kid");
                }
            }
            this._weight = Vector2.Distance(this._vA.pos, this._vB.pos);
        }
         
        public bool CompareEdge(Edge testEdge)
        {
            if ((this._vA.Equals(testEdge.vA) && this._vB.Equals(testEdge.vB)) ||
               (this._vA.Equals(testEdge.vB) && this._vB.Equals(testEdge.vA)))
                return true;
            else
                return false;
        }

        public List<Vertex> VertexList()
        {
            List<Vertex> vList = new List<Vertex>();
            vList.Add(this._vA);
            vList.Add(this._vB);
            return vList;
        }

        public void FindAdjacentEdges(List<Edge> edges)
        {
            foreach(Edge nextEdge in edges)
            {
                if(nextEdge.VertexList().Contains(this._vA) ||
                    nextEdge.VertexList().Contains(this._vB))
                {
                    this._adjMSTEdges.Add(nextEdge);
                }
            }
        }
        public Vertex vA
        {
            get { return this._vA; }
        }
        public Vertex vB
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
