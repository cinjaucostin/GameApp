using TestApp.arena;
using TestApp.factory;
using TestApp.fighter;
using TestApp.game;
using TestApp.visitor;

namespace TestApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Arena arena = new Arena();
            FighterFactory fighterFactory = new FighterFactory();
            Doctor doctor = new Doctor();

            Game game = new FightGame(arena, fighterFactory, doctor);
            game.setup();
            game.simulate();

            
            // Fighter floyd_mayweather = new BoxFighter("BOX_TEAM");
            // Fighter connor_mcgregor = new MmaFighter("MMA_TEAM");
            // rena.fight(floyd_mayweather, connor_mcgregor, doctor);

            // Console.WriteLine("HP: " + floyd_mayweather.Health);
           //  Console.WriteLine("HP: " + connor_mcgregor.Health);

        }
    }
} 