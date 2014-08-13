using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Dungeon
{
    static class Log
    {

        private static List<String> log = new List<String>();
        private static Vector2 fontPos;

        public static void Write(String message)
        {
            log.Add(message);
        }

        public static void WriteLines(String[] messages)
        {
            foreach(String message in messages){
                log.Add(message);
            }
        }

        public static void WriteLines(List<String> messages)
        {
            foreach (String message in messages)
            {
                log.Add(message);
            }
        }

        public static int Size()
        {
            return log.Count;
        }

        public static void Clear()
        {
            log.Clear();
        }

        public static List<String> GetLines(int numLines)
        {

            if (numLines < log.Count)
            {
                return log.GetRange(log.Count - numLines, numLines);
            }
            else
            {
                return log;
            }
        }

        public static void DrawLog(SpriteBatch spriteBatch, SpriteFont font)
        {
            fontPos = new Vector2(10, 815);
            foreach (String line in GetLines(8))
            {
                spriteBatch.DrawString(font, line, fontPos, Color.White);
                fontPos.Y += 20;
            }
        }
    }
}
