using TestApp.arena;
using TestApp.factory;
using TestApp.team;
using TestApp.visitor;
using TestApp.common;

namespace TestApp.game
{
    public class FightGame : IGame
    {
        public Team FirstTeam
        {
            get; set;
        }

        public Team SecondTeam
        {
            get; set;
        }

        public FighterFactory FighterFactory
        {
            get; set;
        }

        public Arena Arena
        {
            get; set;
        }

        // daca tot avem interfata o folosim pe ea
        // reducem cuplajul dintre clase
        public IDoctorVisitor Doctor
        {
            get; set;
        }

        public FightGame(Arena arena, FighterFactory fighterFactory, IDoctorVisitor doctor)
        {
            //null checks pentru parametri
            Arena = arena ?? throw new ArgumentNullException(nameof(arena));
            FighterFactory = fighterFactory ?? throw new ArgumentNullException(nameof(fighterFactory));
            Doctor = doctor ?? throw new ArgumentNullException(nameof(doctor));
        }

        private Team ConfigureTeam()
        {
            int i = 0;
            Console.WriteLine("Please type the team name:");

            string teamName = Console.ReadLine();

            Team team = new Team(teamName);

            Console.WriteLine("Team number of fighters:");
            //aici ar putea arunca o exceptie daca nu introduci un numar
            int numberOfFighters = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("There are the fighters:\n" +
                "1 - Box Fighter\n" +
                "2 - MMA Fighter\n" +
                "3 - Complex Fighter");

            while (i < numberOfFighters)
            {
                Console.WriteLine("Please select your option for fighter no. " + (i + 1));
                //aici ar putea arunca o exceptie daca nu introduci un numar
                int fighterType = Convert.ToInt32(Console.ReadLine());
                try
                {
                    switch (fighterType)
                    {
                        case 1:
                            team.AddFighter(FighterFactory.createFighter(team.Name, Utils.BOX_FIGHTER));
                            Console.WriteLine("Box Fighter has been added to team " + team.Name);
                            i++;
                            break;
                        case 2:
                            team.AddFighter(FighterFactory.createFighter(team.Name, Utils.MMA_FIGHTER));
                            Console.WriteLine("MMA Fighter has been added to team " + team.Name);
                            i++;
                            break;
                        case 3:
                            team.AddFighter(FighterFactory.createFighter(team.Name, Utils.COMPLEX_FIGHTER));
                            Console.WriteLine("Complex Fighter has been added to team " + team.Name);
                            i++;
                            break;
                        default:
                            continue;
                    }
                }
                catch (ArgumentException)
                {
                    Console.WriteLine("Invalid option, please choose one more time...");
                    continue;
                }
            }
            return team;
        }

        public void Setup()
        {
            Console.WriteLine("------------------------------------------ GAME SETUP ------------------------------------------");

            Console.WriteLine("--------------- Configure the first team: ---------------");
            FirstTeam = ConfigureTeam();
            Console.WriteLine("-------------------------------------------------");

            Console.WriteLine("--------------- Configure the second team: ---------------");
            SecondTeam = ConfigureTeam();
            Console.WriteLine("-------------------------------------------------");

        }

        public void Simulate()
        {
            int firstTeamFighterNo, secondTeamFighterNo;
            Random rand = new Random();
            while(FirstTeam.Fighters.Count > 0 && SecondTeam.Fighters.Count > 0)
            {
                firstTeamFighterNo = rand.Next(FirstTeam.Fighters.Count);
                secondTeamFighterNo = rand.Next(SecondTeam.Fighters.Count);

                Arena.Fight(FirstTeam.Fighters[firstTeamFighterNo], SecondTeam.Fighters[secondTeamFighterNo], Doctor);

                FirstTeam.UpdateTeam();
                SecondTeam.UpdateTeam();

            }

            Arena.CheckTeams(FirstTeam, SecondTeam);

        }
    }
}
