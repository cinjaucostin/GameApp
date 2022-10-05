using TestApp.arena;
using TestApp.factory;
using TestApp.fighter;
using TestApp.game;

namespace TestApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Arena arena = new Arena();
            FighterFactory fighterFactory = new FighterFactory();

            Game game = new FightGame(arena, fighterFactory);
            game.setup();
            game.simulate();

            // arena.setup();

            // Fighter floyd_mayweather = new BoxFighter("BOX_TEAM");
            // Fighter connor_mcgregor = new MmaFighter("MMA_TEAM");
            // arena.fight(floyd_mayweather, connor_mcgregor);

            // Console.WriteLine("HP: " + floyd_mayweather.Health);
           //  Console.WriteLine("HP: " + connor_mcgregor.Health);

        }
    }
} 