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
        Vector2 _vA, _vB, _vC;
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

        public bool SuperTriCheck(Vector2 point)
        {
            if (Vector2.Distance(point, this._vA) == 0 ||
                Vector2.Distance(point, this._vB) == 0 ||
                Vector2.Distance(point, this._vC) == 0)
                return true;
            else
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
        public Vector2 vC
        {
            get { return this._vC; }
        }
        public List<Edge> edges
        {
            get { return this._edges; }
        }
    }
}