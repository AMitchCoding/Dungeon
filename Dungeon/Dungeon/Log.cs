using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dungeon
{
    class Log
    {

        private List<String> log;

        public Log()
        {
            log = new List<String>();
            log.Add("Welcome to the dungeon! Nice shirt!");
        }

        public void Write(String message)
        {
            log.Add(message);
        }

        public void WriteLines(String[] messages)
        {
            foreach(String message in messages){
                log.Add(message);
            }
        }

        public void WriteLines(List<String> messages)
        {
            foreach (String message in messages)
            {
                log.Add(message);
            }
        }

        public int Size()
        {
            return log.Count;
        }

        public void Clear()
        {
            log.Clear();
        }

        public List<String> GetLines(int numLines)
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
