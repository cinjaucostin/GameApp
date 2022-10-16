using System.Diagnostics;
using TestApp.arena;
using TestApp.common;
using TestApp.factory;
using TestApp.fighter;
using TestApp.game;
using TestApp.visitor;
using TestApp.common;

namespace TestApp
{
    internal class Program
    {
        static void Main(string[] args)
        {

            AppDomain.CurrentDomain.FirstChanceException += (sender, eventArgs) =>
            {
                Debug.WriteLine(eventArgs.Exception.ToString());
            };

            Arena arena = new Arena();
            Dictionary<string, Dictionary<string, double>> properties = 
                Helpers.loadCharactersProperties(Utils.FIGHTERS_PROPERTIES_FILE);
            FighterFactory fighterFactory = new FighterFactory(properties);
            Doctor doctor = new Doctor();

            //Game game = new FightGame(arena, fighterFactory, doctor);
            //game.setup();
            //game.simulate();


            Helpers helpers = new Helpers();
            helpers.Fight_ShouldBeBalanced();

        }
    }
} 