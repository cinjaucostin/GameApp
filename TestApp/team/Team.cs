using TestApp.enums;
using TestApp.fighter;

namespace TestApp.team
{
    public class Team
    {
        public List<Fighter> Fighters { get; set; }
        public string Name { get; set; }

        // constructor inutil
        public Team()
        {

        }

        public Team(string name)
        {
            Name = name;
        }

        public void AddFighter(Fighter fighter)
        {
            if(Fighters == null)
            {
                Fighters = new List<Fighter>();
            }
            Fighters.Add(fighter);
        }

        public void UpdateTeam()
        {
            Fighters.RemoveAll(fighter => fighter.Status == Status.DEAD);
        }

    }
}
