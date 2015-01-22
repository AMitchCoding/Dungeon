using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dungeon
{
    class SpellDictionary
    {
        Random rand = new Random(System.DateTime.Now.Millisecond);
        string[] schools ={
         "Air"
        ,"Charms"
        ,"Conjuration"
        ,"Earth"
        ,"Fire"
        ,"Hexes"
        ,"Ice"
        ,"Necromancy"
        ,"Poison"
        ,"Summoning"
        ,"Translocation"
        ,"Transmutation"};

        public SpellDictionary()
        {

        }
        public string GetSchool()
        {
            return schools[rand.Next(schools.Length)];
        }
    }
}