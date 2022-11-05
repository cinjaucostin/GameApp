using TestApp.fighter;
using TestApp.team;

namespace TestApp.notifier
{
    // impresia mea e ca aceasta clasa e multi purpose si nu respecta S din Solid
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

        //chiar e util acest constructor?
        public CustomEventArgs()
        {

        }

        public CustomEventArgs(Team team)
        {
            this.Team = team ?? throw new ArgumentNullException(nameof(team));
        }

        public CustomEventArgs(Fighter fighter)
        {
            this.Fighter = fighter ?? throw new ArgumentNullException(nameof(fighter));
        }

        public CustomEventArgs(int damage)
        {
            this.Damage = damage;
        }


        public CustomEventArgs(Fighter fighter, int damage)
        {
            this.Fighter = fighter ?? throw new ArgumentNullException(nameof(fighter));
            this.Damage = damage;
        }

    }
}
