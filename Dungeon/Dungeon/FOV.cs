using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace Dungeon
{
    /// <summary>
    /// Used to determin what the player can see
    /// </summary>
    class FOV
    {
        Tile[,] _grid;
        Vector2 _location;
        List<int> _octants = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8 };
        int VIEW_DISTANCE = 9;

        public FOV(Tile[,] grid, Vector2 location)
        {
            this._grid = grid;
            this._location = location;
        }
        /// <summary>
        /// Goes through all the octants which surround the player to
        /// determine which open cells are visible
        /// </summary>
        public void GetVisibility()
        {
            int visrange2 = VIEW_DISTANCE * VIEW_DISTANCE;

            foreach (int o in this._octants)
                ScanOctant(1, o, 1.0, 0.0, visrange2);
            foreach (Tile tile in this._grid)
            {
                if(!tile.scanned && tile.visible)
                {
                    tile.visible = false;
                    tile.seen = true;
                }
                tile.scanned = false;
            }
            _grid[(int)_location.X, (int)_location.Y].visible = true; 

        }
        /// <summary>
        /// Examine the provided octant and calculate the visible cells within it.
        /// </summary>
        /// <param name="pDepth">Depth of the scan</param>
        /// <param name="pOctant">Octant being examined</param>
        /// <param name="pStartSlope">Start slope of the octant</param>
        /// <param name="pEndSlope">End slope of the octance</param>
        protected void ScanOctant(int pDepth, int pOctant, double pStartSlope, double pEndSlope, int visrange2)
        {
            int x = 0;
            int y = 0;

            switch (pOctant)
            {

                case 1: //nnw
                    y = (int)this._location.Y - pDepth;
                    if (y < 0) return;

                    x = (int)this._location.X - Convert.ToInt32((pStartSlope * Convert.ToDouble(pDepth)));
                    if (x < 0) x = 0;

                    while (GetSlope(x, y, (int)this._location.X, (int)this._location.Y, false) >= pEndSlope)
                    {
                        this._grid[x, y].scanned = true;

                        if (GetVisDistance(x, y, (int)this._location.X, (int)this._location.Y) <= visrange2)
                        {
                            if (this._grid[x, y].sightBlocker) //current cell blocked
                            {
                                this._grid[x, y].visible = true;
                                if (x - 1 >= 0 && !this._grid[x - 1, y].sightBlocker) //prior cell within range AND open...
                                    //...incremenet the depth, adjust the endslope and recurse
                                    ScanOctant(pDepth + 1, pOctant, pStartSlope, GetSlope(x - 0.5, y + 0.5, (int)this._location.X, (int)this._location.Y, false), visrange2);
                            }
                            else
                            {

                                if (x - 1 >= 0 && this._grid[x - 1, y].sightBlocker) //prior cell within range AND closed...
                                    //..adjust the startslope
                                    pStartSlope = GetSlope(x - 0.5, y - 0.5, (int)this._location.X, (int)this._location.Y, false);

                                this._grid[x, y].visible = true;
                            }
                        }
                        else
                        {
                            if (this._grid[x, y].visible)
                            {
                                this._grid[x, y].visible = false;
                                this._grid[x, y].seen = true;
                            }
                        }
                        x++;
                    }
                    x--;
                    break;

                case 2: //nne

                    y = (int)this._location.Y - pDepth;
                    if (y < 0) return;

                    x = (int)this._location.X + Convert.ToInt32((pStartSlope * Convert.ToDouble(pDepth)));
                    if (x >= this._grid.GetLength(0)) x = this._grid.GetLength(0) - 1;

                    while (GetSlope(x, y, (int)this._location.X, (int)this._location.Y, false) <= pEndSlope)
                    {
                        this._grid[x, y].scanned = true;

                        if (GetVisDistance(x, y, (int)this._location.X, (int)this._location.Y) <= visrange2)
                        {
                            if (this._grid[x, y].sightBlocker)
                            {
                                this._grid[x, y].visible = true;
                                if (x + 1 < this._grid.GetLength(0) && !this._grid[x + 1, y].sightBlocker)
                                    ScanOctant(pDepth + 1, pOctant, pStartSlope, GetSlope(x + 0.5, y + 0.5, (int)this._location.X, (int)this._location.Y, false), visrange2);
                            }
                            else
                            {
                                if (x + 1 < this._grid.GetLength(0) && this._grid[x + 1, y].sightBlocker)
                                    pStartSlope = -GetSlope(x + 0.5, y - 0.5, (int)this._location.X, (int)this._location.Y, false);

                                this._grid[x,y].visible = true;
                            }
                        }
                        else
                        {
                            if (this._grid[x, y].visible)
                            {
                                this._grid[x, y].visible = false;
                                this._grid[x, y].seen = true;
                            }
                        }
                        x--;
                    }
                    x++;
                    break;

                case 3:

                    x = (int)this._location.X + pDepth;
                    if (x >= this._grid.GetLength(0)) return;

                    y = (int)this._location.Y - Convert.ToInt32((pStartSlope * Convert.ToDouble(pDepth)));
                    if (y < 0) y = 0;

                    while (GetSlope(x, y, (int)this._location.X, (int)this._location.Y, true) <= pEndSlope)
                    {
                        this._grid[x, y].scanned = true;

                        if (GetVisDistance(x, y, (int)this._location.X, (int)this._location.Y) <= visrange2)
                        {

                            if (this._grid[x, y].sightBlocker)
                            {
                                this._grid[x, y].visible = true;
                                if (y - 1 >= 0 && !this._grid[x, y - 1].sightBlocker)
                                    ScanOctant(pDepth + 1, pOctant, pStartSlope, GetSlope(x - 0.5, y - 0.5, (int)this._location.X, (int)this._location.Y, true), visrange2);
                            }
                            else
                            {
                                if (y - 1 >= 0 && this._grid[x, y - 1].sightBlocker)
                                    pStartSlope = -GetSlope(x + 0.5, y - 0.5, (int)this._location.X, (int)this._location.Y, true);

                                this._grid[x,y].visible = true;
                            }
                        }
                        else
                        {
                            if (this._grid[x, y].visible)
                            {
                                this._grid[x, y].visible = false;
                                this._grid[x, y].seen = true;
                            }
                        }
                        y++;
                    }
                    y--;
                    break;

                case 4:

                    x = (int)this._location.X + pDepth;
                    if (x >= this._grid.GetLength(0)) return;

                    y = (int)this._location.Y + Convert.ToInt32((pStartSlope * Convert.ToDouble(pDepth)));
                    if (y >= this._grid.GetLength(1)) y = this._grid.GetLength(1) - 1;

                    while (GetSlope(x, y, (int)this._location.X, (int)this._location.Y, true) >= pEndSlope)
                    {
                        this._grid[x, y].scanned = true;

                        if (GetVisDistance(x, y, (int)this._location.X, (int)this._location.Y) <= visrange2)
                        {

                            if (this._grid[x, y].sightBlocker)
                            {
                                this._grid[x, y].visible = true;
                                if (y + 1 < this._grid.GetLength(1) && !this._grid[x, y + 1].sightBlocker)
                                    ScanOctant(pDepth + 1, pOctant, pStartSlope, GetSlope(x - 0.5, y + 0.5, (int)this._location.X, (int)this._location.Y, true), visrange2);
                            }
                            else
                            {
                                if (y + 1 < this._grid.GetLength(1) && this._grid[x, y + 1].sightBlocker)
                                    pStartSlope = GetSlope(x + 0.5, y + 0.5, (int)this._location.X, (int)this._location.Y, true);

                                this._grid[x,y].visible = true;
                            }
                        }
                        else
                        {
                            if (this._grid[x, y].visible)
                            {
                                this._grid[x, y].visible = false;
                                this._grid[x, y].seen = true;
                            }
                        }
                        y--;
                    }
                    y++;
                    break;

                case 5:

                    y = (int)this._location.Y + pDepth;
                    if (y >= this._grid.GetLength(1)) return;

                    x = (int)this._location.X + Convert.ToInt32((pStartSlope * Convert.ToDouble(pDepth)));
                    if (x >= this._grid.GetLength(0)) x = this._grid.GetLength(0) - 1;

                    while (GetSlope(x, y, (int)this._location.X, (int)this._location.Y, false) >= pEndSlope)
                    {
                        this._grid[x, y].scanned = true;

                        if (GetVisDistance(x, y, (int)this._location.X, (int)this._location.Y) <= visrange2)
                        {

                            if (this._grid[x, y].sightBlocker)
                            {
                                this._grid[x, y].visible = true;
                                if (x + 1 < this._grid.GetLength(1) && !this._grid[x + 1, y].sightBlocker)
                                    ScanOctant(pDepth + 1, pOctant, pStartSlope, GetSlope(x + 0.5, y - 0.5, (int)this._location.X, (int)this._location.Y, false), visrange2);
                            }
                            else
                            {
                                if (x + 1 < this._grid.GetLength(1)
                                        && this._grid[x + 1, y].sightBlocker)
                                    pStartSlope = GetSlope(x + 0.5, y + 0.5, (int)this._location.X, (int)this._location.Y, false);

                                this._grid[x,y].visible = true;
                            }
                        }
                        else
                        {
                            if (this._grid[x, y].visible)
                            {
                                this._grid[x, y].visible = false;
                                this._grid[x, y].seen = true;
                            }
                        }
                        x--;
                    }
                    x++;
                    break;

                case 6:

                    y = (int)this._location.Y + pDepth;
                    if (y >= this._grid.GetLength(1)) return;

                    x = (int)this._location.X - Convert.ToInt32((pStartSlope * Convert.ToDouble(pDepth)));
                    if (x < 0) x = 0;

                    while (GetSlope(x, y, (int)this._location.X, (int)this._location.Y, false) <= pEndSlope)
                    {
                        this._grid[x, y].scanned = true;

                        if (GetVisDistance(x, y, (int)this._location.X, (int)this._location.Y) <= visrange2)
                        {

                            if (this._grid[x, y].sightBlocker)
                            {
                                this._grid[x, y].visible = true;
                                if (x - 1 >= 0 && !this._grid[x - 1, y].sightBlocker)
                                    ScanOctant(pDepth + 1, pOctant, pStartSlope, GetSlope(x - 0.5, y - 0.5, (int)this._location.X, (int)this._location.Y, false), visrange2);
                            }
                            else
                            {
                                if (x - 1 >= 0
                                        && this._grid[x - 1, y].sightBlocker)
                                    pStartSlope = -GetSlope(x - 0.5, y + 0.5, (int)this._location.X, (int)this._location.Y, false);

                                this._grid[x,y].visible = true;
                            }
                        }
                        else
                        {
                            if (this._grid[x, y].visible)
                            {
                                this._grid[x, y].visible = false;
                                this._grid[x, y].seen = true;
                            }
                        }
                        x++;
                    }
                    x--;
                    break;

                case 7:

                    x = (int)this._location.X - pDepth;
                    if (x < 0) return;

                    y = (int)this._location.Y + Convert.ToInt32((pStartSlope * Convert.ToDouble(pDepth)));
                    if (y >= this._grid.GetLength(1)) y = this._grid.GetLength(1) - 1;

                    while (GetSlope(x, y, (int)this._location.X, (int)this._location.Y, true) <= pEndSlope)
                    {
                        this._grid[x, y].scanned = true;

                        if (GetVisDistance(x, y, (int)this._location.X, (int)this._location.Y) <= visrange2)
                        {

                            if (this._grid[x, y].sightBlocker)
                            {
                                this._grid[x, y].visible = true;
                                if (y + 1 < this._grid.GetLength(1) && !this._grid[x, y + 1].sightBlocker)
                                    ScanOctant(pDepth + 1, pOctant, pStartSlope, GetSlope(x + 0.5, y + 0.5, (int)this._location.X, (int)this._location.Y, true), visrange2);
                            }
                            else
                            {
                                if (y + 1 < this._grid.GetLength(1) && this._grid[x, y + 1].sightBlocker)
                                    pStartSlope = -GetSlope(x - 0.5, y + 0.5, (int)this._location.X, (int)this._location.Y, true);

                                this._grid[x,y].visible = true;
                            }
                        }
                        else
                        {
                            if (this._grid[x, y].visible)
                            {
                                this._grid[x, y].visible = false;
                                this._grid[x, y].seen = true;
                            }
                        }
                        y--;
                    }
                    y++;
                    break;

                case 8: //wnw

                    x = (int)this._location.X - pDepth;
                    if (x < 0) return;

                    y = (int)this._location.Y - Convert.ToInt32((pStartSlope * Convert.ToDouble(pDepth)));
                    if (y < 0) y = 0;

                    while (GetSlope(x, y, (int)this._location.X, (int)this._location.Y, true) >= pEndSlope)
                    {
                        this._grid[x, y].scanned = true;

                        if (GetVisDistance(x, y, (int)this._location.X, (int)this._location.Y) <= visrange2)
                        {

                            if (this._grid[x, y].sightBlocker)
                            {
                                this._grid[x, y].visible = true;
                                if (y - 1 >= 0 && !this._grid[x, y - 1].sightBlocker)
                                    ScanOctant(pDepth + 1, pOctant, pStartSlope, GetSlope(x + 0.5, y - 0.5, (int)this._location.X, (int)this._location.Y, true), visrange2);

                            }
                            else
                            {
                                if (y - 1 >= 0 && this._grid[x, y - 1].sightBlocker)
                                    pStartSlope = GetSlope(x - 0.5, y - 0.5, (int)this._location.X, (int)this._location.Y, true);

                                this._grid[x,y].visible = true;
                            }
                        }
                        else
                        {
                            if (this._grid[x, y].visible)
                            {
                                this._grid[x, y].visible = false;
                                this._grid[x, y].seen = true;
                            }
                        }
                        y++;
                    }
                    y--;
                    break;
            }


            if (x < 0)
                x = 0;
            else if (x >= this._grid.GetLength(0))
                x = this._grid.GetLength(0) - 1;

            if (y < 0)
                y = 0;
            else if (y >= this._grid.GetLength(1))
                y = this._grid.GetLength(1) - 1;

            if (pDepth < VIEW_DISTANCE + 1 & !this._grid[x, y].sightBlocker)
                ScanOctant(pDepth + 1, pOctant, pStartSlope, pEndSlope, visrange2);

        }
        /// <summary>
        /// Get the gradient of the slope formed by the two points
        /// </summary>
        /// <param name="pX1"></param>
        /// <param name="pY1"></param>
        /// <param name="pX2"></param>
        /// <param name="pY2"></param>
        /// <param name="pInvert">Invert slope</param>
        /// <returns></returns>
        private double GetSlope(double pX1, double pY1, double pX2, double pY2, bool pInvert)
        {
            if (pInvert)
                return (pY1 - pY2) / (pX1 - pX2);
            else
                return (pX1 - pX2) / (pY1 - pY2);
        }


        /// <summary>
        /// Calculate the distance between the two points
        /// </summary>
        /// <param name="pX1"></param>
        /// <param name="pY1"></param>
        /// <param name="pX2"></param>
        /// <param name="pY2"></param>
        /// <returns>Distance</returns>
        private int GetVisDistance(int pX1, int pY1, int pX2, int pY2)
        {
            return ((pX1 - pX2) * (pX1 - pX2)) + ((pY1 - pY2) * (pY1 - pY2));
        }
    }
}
