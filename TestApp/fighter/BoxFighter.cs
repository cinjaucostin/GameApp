using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestApp.enums;

namespace TestApp.fighter
{
    public class BoxFighter : Fighter
    {
        public BoxFighter(string team) : base(team)
        {
        }

        public override int hitDamage()
        {
            Random rand = new Random();
            int damage = rand.Next(25, 50);
            return damage;
        }

    }
}
