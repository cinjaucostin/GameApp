using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestApp.fighter;
using TestApp.team;

namespace TestApp.notifier
{
    public class CustomEventArgs : EventArgs
    {
        public Team Team
        {
            get; set;
        }
        public Fighter Fighter
        {
            get; set;
        } 

        public int Damage
        {
            get; set;
        }

        public int Heal
        {
            get; set;
        }

        public CustomEventArgs()
        {

        }

        public CustomEventArgs(Team team)
        {
            this.Team = team;
        }

        public CustomEventArgs(Fighter fighter)
        {
            this.Fighter = fighter;
        }

        public CustomEventArgs(int damage)
        {
            this.Damage = damage;
        }


        public CustomEventArgs(Fighter fighter, int damage)
        {
            this.Fighter = fighter;
            this.Damage = damage;
        }

    }
}
