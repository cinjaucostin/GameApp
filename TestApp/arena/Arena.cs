using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestApp.factory;
using TestApp.fighter;
using TestApp.team;
using TestApp.enums;
using System.ComponentModel;
using TestApp.visitor;

namespace TestApp.arena
{
    public class Arena
    {
        public int whoHitsThisTime(Fighter fighter1, Fighter fighter2)
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
        public void checkTeams(Team firstTeam, Team secondTeam)
        {
            if (firstTeam.Fighters.Count == 0)
            {
                Console.WriteLine("Team " + secondTeam.Name + " has won the game.");
                Console.WriteLine("Fighters alive:");
                foreach (Fighter fighter in secondTeam.Fighters)
                {
                    Console.WriteLine("Fighter: " + fighter.GetType().Name + " with " + fighter.Health + " HP.");
                }
            }
            else if (secondTeam.Fighters.Count == 0)
            {
                Console.WriteLine("Team " + firstTeam.Name + " has won the game.");
                Console.WriteLine("Fighters alive:");
                foreach (Fighter fighter in firstTeam.Fighters)
                {
                    Console.WriteLine("Fighter: " + fighter.GetType().Name + " with " + fighter.Health + " HP.");
                }
            }
            else
            {
                Console.WriteLine("Something went wrong.");
            }

        }
        public void fight(Fighter fighter1, Fighter fighter2, IVisitor doctor)
        {
            Random random = new Random();
            int fighter1HitDamage, fighter2HitDamage;
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
                if(whoHitsThisTime(fighter1, fighter2) == 1 
                    && fighter1.Status == Status.ALIVE
                    && fighter2.Status == Status.ALIVE)
                {
                    fighter1HitDamage = fighter1.hitDamage();
                    fighter2.getHit(fighter1, fighter1HitDamage);
                    fighter2.accept(doctor);
                }
                else if(whoHitsThisTime(fighter1, fighter2) == 2
                    && fighter1.Status == Status.ALIVE
                    && fighter2.Status == Status.ALIVE)
                {
                    fighter2HitDamage = fighter2.hitDamage();
                    fighter1.getHit(fighter2, fighter2HitDamage);
                    fighter1.accept(doctor);
                }

            }

            Console.WriteLine("---------------------------------------------------");

        }
    }
}
