using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestApp.arena;
using TestApp.factory;
using TestApp.fighter;
using TestApp.team;
using TestApp.enums;

namespace TestApp.game
{
    public class FightGame : Game
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

        public FightGame(Arena arena, FighterFactory fighterFactory)
        {
            Arena = arena;
            FighterFactory = fighterFactory;
        }

        public Team configureTeam()
        {
            int i = 0, fighterType = 0;
            Console.WriteLine("Please type the team name:");

            string teamName = Console.ReadLine();

            Team team = new Team(teamName);

            Console.WriteLine("Team number of fighters:");
            int numberOfFighters = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("There are the fighters:\n" +
                "1 - Box Fighter\n" +
                "2 - MMA Fighter\n" +
                "3 - Complex Fighter");

            while (i < numberOfFighters)
            {
                Console.WriteLine("Please select your option for fighter no. " + i);
                fighterType = Convert.ToInt32(Console.ReadLine());
                switch (fighterType)
                {
                    case 1:
                        team.addFighter(FighterFactory.createFighter(team.Name, "BOX_FIGHTER"));
                        i++;
                        break;
                    case 2:
                        team.addFighter(FighterFactory.createFighter(team.Name, "MMA_FIGHTER"));
                        i++;
                        break;
                    case 3:
                        team.addFighter(FighterFactory.createFighter(team.Name, "COMPLEX_FIGHTER"));
                        i++;
                        break;
                    default:
                        continue;
                }
            }
            return team;
        }

        public void setup()
        {
            Console.WriteLine("----- GAME SETUP -----");

            Console.WriteLine("Configure the first team:");
            FirstTeam = configureTeam();

            Console.WriteLine("Configure the second team:");
            SecondTeam = configureTeam();

        }

        public void simulate()
        {
            int firstTeamFighterNo, secondTeamFighterNo;
            Random rand = new Random();
            Console.WriteLine("Urmeaza sa fie implementat.");
            while(FirstTeam.Fighters.Count > 0 && SecondTeam.Fighters.Count > 0)
            {
                firstTeamFighterNo = rand.Next(FirstTeam.Fighters.Count);
                secondTeamFighterNo = rand.Next(SecondTeam.Fighters.Count);

                Arena.fight(FirstTeam.Fighters[firstTeamFighterNo], SecondTeam.Fighters[secondTeamFighterNo]);

                FirstTeam.updateTeam();
                SecondTeam.updateTeam();

            }

            if (FirstTeam.Fighters.Count == 0)
                Console.WriteLine("Team " + SecondTeam.Name + " has won the game.");
            else if (SecondTeam.Fighters.Count == 0)
                Console.WriteLine("Team " + FirstTeam.Name + " has won the game.");
            else
                Console.WriteLine("Something went wrong.");

        }
    }
}
