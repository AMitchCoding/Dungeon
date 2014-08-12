using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Dungeon
{
    class Combat
    {
        public void Fight(Entity combatant1, Entity combatant2)
        {
            combatant1._health -= combatant2.GetDamage();
            combatant2._health -= combatant1.GetDamage();
        }
    }
}
