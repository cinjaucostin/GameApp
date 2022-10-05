using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestApp.enums;
using TestApp.fighter;

namespace TestApp.team
{
    public class Team
    {
        public List<Fighter> Fighters { get; set; }
        public string Name { get; set; }

        public Team()
        {

        }

        public Team(string name)
        {
            this.Name = name;
        }

        public void addFighter(Fighter fighter)
        {
            if(this.Fighters == null)
            {
                this.Fighters = new List<Fighter>();
            }
            this.Fighters.Add(fighter);
        }

        public void updateTeam()
        {
            Fighters.RemoveAll(fighter => fighter.Status == Status.DEAD);
        }

    }
}
