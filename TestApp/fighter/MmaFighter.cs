using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestApp.fighter
{
    public class MmaFighter : Fighter
    {
        public MmaFighter(string team) : base(team)
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
