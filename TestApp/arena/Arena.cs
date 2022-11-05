using TestApp.fighter;
using TestApp.team;
using TestApp.enums;
using TestApp.visitor;
using TestApp.notifier;

//Numele Aplicatiei: TestApp e trist :)
namespace TestApp.arena
{
    public class Arena
    {
        public event EventHandler<CustomEventArgs> TeamWon;

        //pentru o decuplare si mai buna puteai sa faci o interfata pentru notifier
        public Arena(Notifier notifier)
        {
            if (notifier is null)
            {
                throw new ArgumentNullException(nameof(notifier));
            }
            TeamWon += notifier.OnTeamWon;
        }

        //n-ai nici un motiv sa ai aceasta metoda publica
        private int WhoHitsThisTime(Fighter fighter1, Fighter fighter2)
        {
            Random random = new Random();
            bool result1, result2;
            result1 = random.NextDouble() < fighter1.Agility;
            result2 = random.NextDouble() < fighter2.Agility;
            
            if(result1 && result2)
            {
                return random.Next(1, 2);
            }
            else if(result1)
            {
                return 1;
            }
            return 2;
        }
        
        public void CheckTeams(Team firstTeam, Team secondTeam)
        {
            //firstTeam sau secondTeam ar putea fi null
            if (firstTeam is null)
            {
                throw new ArgumentNullException(nameof(firstTeam));
            }
            if (secondTeam is null)
            {
                throw new ArgumentNullException(nameof(secondTeam));
            }
            if (firstTeam.Fighters.Count == 0)
            {
                OnTeamWon(secondTeam);
            }
            else if (secondTeam.Fighters.Count == 0)
            {
                OnTeamWon(firstTeam);
            }
            else
            {
                Console.WriteLine("Something went wrong.");
            }
        }
        
        public void Fight(Fighter fighter1, Fighter fighter2, IDoctorVisitor doctor)
        {
            if (fighter1 is null)
            {
                throw new ArgumentNullException(nameof(fighter1));
            }
            if (fighter2 is null)
            {
                throw new ArgumentNullException(nameof(fighter2));
            }
            //clean dead code
            Console.WriteLine("---------------------------------------------------");
            Console.WriteLine("\t\t\t" + fighter1.GetType().Name + " from team " + fighter1.Team +
                " VS " + fighter2.GetType().Name + " from team " + fighter2.Team);

            Console.WriteLine("The fight will start in...");
            Console.WriteLine("3...");
            Thread.Sleep(1000);
            Console.WriteLine("2...");
            Thread.Sleep(1000);
            Console.WriteLine("1...");
            Thread.Sleep(1000);
            Console.WriteLine("GO!");

            while(fighter1.Status == Status.ALIVE && fighter2.Status == Status.ALIVE)
            {
                // logica aici e cam incalcita. nu imi e clar daca sunt sanse ca
                // la un tur nici unul sa nu poata sa loveasca
                if(WhoHitsThisTime(fighter1, fighter2) == 1 
                    && fighter1.Status == Status.ALIVE
                    && fighter2.Status == Status.ALIVE)
                {
                    var fighter1HitDamage = fighter1.HitDamage();
                    fighter2.getHit(fighter1, fighter1HitDamage);
                    fighter2.Accept(doctor);
                }
                else if(WhoHitsThisTime(fighter1, fighter2) == 2
                    && fighter1.Status == Status.ALIVE
                    && fighter2.Status == Status.ALIVE)
                {
                    var fighter2HitDamage = fighter2.HitDamage();
                    fighter1.getHit(fighter2, fighter2HitDamage);
                    fighter1.Accept(doctor);
                }
            }
            Console.WriteLine("---------------------------------------------------");
        }

        protected virtual void OnTeamWon(Team team)
        {
            if(TeamWon != null)
            {
                TeamWon(this, new CustomEventArgs(team));
            }
        }
    }
}
