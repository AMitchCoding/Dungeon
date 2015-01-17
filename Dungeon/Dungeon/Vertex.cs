using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace Dungeon
{
    class Vertex
    {
        Vector2 _pos;
        List<Vertex> _adjNodes = new List<Vertex>();
        List<Edge> _adjEdges = new List<Edge>();
        bool _visited = false;

        public Vertex(Vector2 pos)
        {
            this._pos = pos;
        }

        public Vector2 pos
        {
            get { return this._pos;}
        }

        public bool visited
        {
            get { return this._visited; }
            set { this._visited = value; }
        }

        public List<Vertex> adjNodes
        {
            get { return this._adjNodes; }
        }
        public List<Edge> adjEdges
        {
            get { return this._adjEdges; }
        }

        public void FindAdjacent(HashSet<Edge> edges)
        {
            foreach(Edge edge in edges)
            {
                List<Vertex> eNodes = edge.VertexList();
                if (eNodes.Contains(this))
                {
                    this._adjEdges.Add(edge);
                    foreach (Vertex node in eNodes)
                    {
                        if (node != this)
                            this._adjNodes.Add(node);
                    }
                }
            }
        }

    }
}
