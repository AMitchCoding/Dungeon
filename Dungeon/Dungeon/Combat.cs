using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Dungeon
{
    static class Combat
    {
        /// <summary>
        /// Method to determin damage done
        /// </summary>
        /// <param name="combatant1">First combatant</param>
        /// <param name="combatant2">Second combatant</param>
        public static void Fight(Entity combatant1, Entity combatant2)
        {
            combatant1.health -= combatant2.GetDamage();
            Log.Write("Combatant1 HP: " + combatant1.health);
            combatant2.health -= combatant1.GetDamage();
            Log.Write("Combatant2 HP: " + combatant2.health);
        }
    }
}
