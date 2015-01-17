using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace Dungeon
{
    class Triangle
    {
        List<Edge> _edges = new List<Edge>();
        Edge _eA, _eB, _eC;
        Vertex _vA, _vB, _vC;
        public Triangle(Edge a, Edge b, Edge c)
        {
            this._eA = a;
            this._eB = b;
            this._eC = c;
            this._vA = a.vA;
            this._vB = a.vB;
            this._vC = b.vB;
            this._edges.Add(a);
            this._edges.Add(b);
            this._edges.Add(c);
        }

        public bool SuperTriCheck(Vertex point)
        {
            if (Vector2.Distance(point.pos, this._vA.pos) == 0 ||
                Vector2.Distance(point.pos, this._vB.pos) == 0 ||
                Vector2.Distance(point.pos, this._vC.pos) == 0)
                return true;
            else
                return false;
        }
        public Vertex vA
        {
            get { return this._vA; }
        }
        public Vertex vB
        {
            get { return this._vB; }
        }
        public Vertex vC
        {
            get { return this._vC; }
        }
        public List<Edge> edges
        {
            get { return this._edges; }
        }
    }
}
