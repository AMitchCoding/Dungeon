using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace Dungeon
{
    class Pathing
    {
        /// <summary>
        /// Generates path based on A* algorithm
        /// </summary>
        /// <param name="endPos">Ending position</param>
        /// <param name="grid">Dungeon floor</param>
        /// <returns>List of Vector 2</returns>
        public static List<Vector2> FindPath(Vector2 endPos, Vector2 startPos, Tile[,] grid)
        {
            Tile endTile = grid[(int)endPos.X, (int)endPos.Y];  //move to
            Tile startTile = grid[(int)startPos.X, (int)startPos.Y];  //move from

            List<Vector2> moveList = new List<Vector2>(); //List of positions for path

            if (endTile.isWall)
            {
                return moveList;
            }

            int[,] board = new int[grid.GetLength(0), grid.GetLength(1)];             //Matrix for distance scores (originating from endpoint)
            for (int i = 0; i < grid.GetLength(0); i++)
            {           //Initialize board (Probably a way to do it during array generation)
                for (int j = 0; j < grid.GetLength(1); j++)
                {
                    board[i, j] = 65535;
                }
            }
            board[(int)endPos.X, (int)endPos.Y] = 0;    //Initialize ending location score
            List<Vector3> moves = new List<Vector3>();  //X loc, Y loc, and distance score
            moves.Add(new Vector3(endPos.X, endPos.Y, 0));  // Add the end point first, build from there.

            while (moves.Count > 0)
            {
                int x = (int)moves[0].X;
                int y = (int)moves[0].Y;
                int score = (int)moves[0].Z;
                for (int i = -1; i < 2; i++)
                {
                    for (int j = -1; j < 2; j++)
                    {
                        if (((x + i > -1 && x + i < 50) && (y + j > -1 && y + j < 50)) && !grid[x + i, y + j].isWall)  //Don't test current tile, walls, or living npcs
                        {
                            if (score + 1 < board[x + i, y + j])
                            {
                                board[x + i, y + j] = score + 1;
                                moves.Add(new Vector3(x + i, y + j, score + 1));
                            }
                            if (x == (int)startPos.X && y == (int)startPos.Y)
                            {
                                moves.Clear();
                            }
                        }
                    }
                }
                if (moves.Count > 0)
                {
                    moves.RemoveAt(0);
                }
            }

            //Create position list, priority given to straight directional moves over diagonals
            int[] dir = new int[] { 0, -1, 1 };
            while (startTile.tilePos != endPos)
            {
                bool broke = false; //Sentinel for early exit
                int currPosScore = board[(int)startTile.tilePos.X, (int)startTile.tilePos.Y];
                Vector2 move = new Vector2();
                foreach (int m in dir)
                {
                    foreach (int n in dir)
                    {
                        if (currPosScore - 1 == board[(int)startTile.tilePos.X + m, (int)startTile.tilePos.Y + n])
                        {
                            move.X = m;
                            move.Y = n;
                            moveList.Add(move);
                            startTile = grid[(int)startTile.tilePos.X + m, (int)startTile.tilePos.Y + n];
                            broke = true;
                            break;
                        }
                    }
                    if (broke) { break; }   //Found move, look for next move
                }
            }

            return moveList;
        }
    }
}
