using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace Dungeon
{
    class CircleTest
    {

        public bool CircleTester(Vector2 a, Vector2 b, Vector2 c, Vector2 p)
        {
            // Get the perpendicular bisector of (x1, y1) and (x2, y2).
            float x1 = (b.X + a.X) / 2;
            float y1 = (b.Y + a.Y) / 2;
            float dy1 = b.X - a.X;
            float dx1 = -(b.Y - a.Y);

            // Get the perpendicular bisector of (x2, y2) and (x3, y3).
            float x2 = (c.X + b.X) / 2;
            float y2 = (c.Y + b.Y) / 2;
            float dy2 = c.X - b.X;
            float dx2 = -(c.Y - b.Y);

            // See where the lines intersect.
            Vector2 intersection = FindIntersection(new Vector2(x1, y1), new Vector2(x1 + dx1, y1 + dy1), new Vector2(x2, y2), new Vector2(x2 + dx2, y2 + dy2));

            return (Vector2.Distance(a, intersection) > Vector2.Distance(p, intersection));
        }
        private Vector2 FindIntersection(Vector2 p1, Vector2 p2, Vector2 p3, Vector2 p4)
        {
            // Get the segments' parameters.
            float dx12 = p2.X - p1.X;
            float dy12 = p2.Y - p1.Y;
            float dx34 = p4.X - p3.X;
            float dy34 = p4.Y - p3.Y;

            // Solve for t1 and t2
            float denominator = (dy12 * dx34 - dx12 * dy34);

            float t1 =
                ((p1.X - p3.X) * dy34 + (p3.Y - p1.Y) * dx34)
                    / denominator;

            // Find the point of intersection.
            Vector2 intersection = new Vector2(p1.X + dx12 * t1, p1.Y + dy12 * t1);

            return intersection;
        }
    }
}