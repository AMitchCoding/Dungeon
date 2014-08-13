using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dungeon
{
    static class Log
    {

        private static List<String> log = new List<String>();

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

    }
}
