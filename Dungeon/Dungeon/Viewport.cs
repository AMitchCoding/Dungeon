using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Dungeon
{
    class Viewport
    {
        int minXPos;
        int minYPos;
        int maxXPos;
        int maxYPos;
        int gridCounterX = 0;
        int gridCounterY = 0; 

        public void DrawViewport(SpriteBatch spriteBatch, Dungeon dungeon, Player player, Texture2D tileTexture, TileDictionary tileDictionary)
        {
            if (player.location.X < 13)
            {
                minXPos = 0;
                maxXPos = 24;
            }
            else if (player.location.X > 37)
            {
                //viewport draws map.x of 25 to map.x length - 1
                minXPos = 25;
                maxXPos = dungeon.grid.GetLength(0) - 1;
            }
            else
            {
                //viewport draws map.x of p - 12 to map.x of p + 12
                minXPos = (int)player.location.X - 12;
                maxXPos = (int)player.location.X + 12;
            }

            if (player.location.Y < 13)
            {
                minYPos = 0;
                maxYPos = 24;
            }
            else if (player.location.Y > 37)
            {
                //viewport draws map.y of 25 to map.y length - 1
                minYPos = 25;
                maxYPos = dungeon.grid.GetLength(1) - 1;
            }
            else
            {
                //viewport draws map.y of p - 12 to map.y of p + 12
                minYPos = (int)player.location.Y - 12;
                maxYPos = (int)player.location.Y + 12;
            }

            for (int x = minXPos; x <= maxXPos; x++)
            {
                for (int y = minYPos; y <= maxYPos; y++)
                {
                    dungeon.grid[x, y].DrawTile(spriteBatch, tileTexture, new Vector2(gridCounterX * 32, gridCounterY * 32), tileDictionary);
                    if (dungeon.grid[x, y].npc != null)
                        dungeon.grid[x, y].npc.DrawNPC(spriteBatch, tileTexture);
                    dungeon.grid[x, y].DrawTileVisibility(spriteBatch, tileTexture, new Vector2(gridCounterX * 32, gridCounterY * 32), tileDictionary);
                    gridCounterY++;
                }
                gridCounterX++;
                gridCounterY = 0;
            }
            gridCounterX = 0;
            minXPos = 0;
            minYPos = 0;
            maxXPos = 24;
            maxYPos = 24;
        }

    }
}
