using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestApp.enums;

namespace TestApp.fighter
{
    public abstract class Fighter
    {
        public int Health
        {
            get; set;
        }

        public string Team
        {
            get; set;
        }
        public Status Status
        {
            get; set;
        }

        public Fighter(string team)
        {
            Health = 100;
            Team = team;
            Status = Status.ALIVE;
        }

        public abstract int hitDamage();

        public override string ToString()
        {
            return "Player " + GetType().Name;
        }
    }
}
