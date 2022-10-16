using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Resources;
using TestApp.fighter;
using TestApp.arena;
using TestApp.enums;
using TestApp.factory;
using TestApp.visitor;

namespace TestApp.common
{
    public class Helpers
    {
        public static Dictionary<string, Dictionary<string, double>> loadCharactersProperties(string path)
        {
            Dictionary<string, Dictionary<string, double>> properties = 
                new Dictionary<string, Dictionary<string, double>>();
            string[] splittedRow;
            string fighterAndProperty, fighter, property;
            double valueForProperty;

            foreach (var row in File.ReadAllLines(path)) {
                splittedRow = row.Split('=');
                fighterAndProperty = splittedRow[0];
                fighter = fighterAndProperty.Split('.')[0];
                property = fighterAndProperty.Split('.')[1];
                valueForProperty = Convert.ToDouble(splittedRow[1]);
               
                if(!properties.ContainsKey(fighter))
                {
                    properties.Add(fighter, new Dictionary<string, double>());
                }
                properties[fighter].Add(property, valueForProperty);

            }

            return properties;
        }

            //public void Fight_ShouldBeBalanced()
            //{
            //    Arena arena = new Arena();
            //    Dictionary<string, Dictionary<string, double>> properties =
            //        Helpers.loadCharactersProperties(Utils.FIGHTERS_PROPERTIES_FILE);
            //    FighterFactory fighterFactory = new FighterFactory(properties);
            //    Doctor doctor = new Doctor();

            //    Fighter testedFighter = fighterFactory.createFighter("Tested Team", Utils.BOX_FIGHTER);
            //    Fighter testFighter = fighterFactory.createFighter("Test Team", Utils.TEST_FIGHTER);

            //    int testedFighterWins = 0, testFighterWins = 0;

            //    for (int i = 0; i < 10; i++)
            //    {
            //        arena.fight(testFighter, testedFighter, doctor);

            //        if (testedFighter.Status == Status.ALIVE)
            //        {
            //            testedFighterWins++;
            //        }
            //        else
            //        {
            //            testFighterWins++;
            //        }

            //        testFighter.Status = Status.ALIVE;
            //        testedFighter.Status = Status.ALIVE;

            //        testedFighter.Health = 100;
            //        testFighter.Health = 100;
            //    }

            //    Console.WriteLine("Tested :" + testedFighterWins);
            //    Console.WriteLine("Tester :" + testFighterWins);

            //}

        }

}
