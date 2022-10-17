using System.Diagnostics;
using TestApp.arena;
using TestApp.common;
using TestApp.factory;
using TestApp.fighter;
using TestApp.game;
using TestApp.visitor;
using TestApp.common;
using TestApp.notifier;

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

            Notifier notifier = new Notifier();
            Arena arena = new Arena(notifier);
            Dictionary<string, Dictionary<string, double>> properties = 
                Helpers.loadCharactersProperties(Utils.FIGHTERS_PROPERTIES_FILE);
            FighterFactory fighterFactory = new FighterFactory(properties, notifier);
            Doctor doctor = new Doctor(notifier);

           


            Game game = new FightGame(arena, fighterFactory, doctor);
            game.setup();
            game.simulate();

        }
    }
} 