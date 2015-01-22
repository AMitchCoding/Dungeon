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

        public Vertex(Vector2 pos)
        {
            this._pos = pos;
        }

        public Vector2 pos
        {
            get { return this._pos;}
        }

    }
}
