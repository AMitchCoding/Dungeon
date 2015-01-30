using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dungeon
{
    /// <summary>
    /// List of spells
    /// </summary>
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

        /// <summary>
        /// Returns the school of magic the spell is in
        /// </summary>
        /// <returns>String of the school</returns>
        public string GetSchool()
        {
            return schools[rand.Next(schools.Length)];
        }
    }
}