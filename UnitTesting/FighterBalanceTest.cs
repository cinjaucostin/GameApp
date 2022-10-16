﻿using TestApp.arena;
using TestApp.common;
using TestApp.enums;
using TestApp.factory;
using TestApp.fighter;
using TestApp.visitor;
using Xunit;

namespace UnitTesting
{
    public class FighterBalanceTest
    {
        [Fact]
        public void Fight_MmaFighterShouldBeBalanced()
        {
            Arena arena = new Arena();
            Dictionary<string, Dictionary<string, double>> properties =
                Helpers.loadCharactersProperties(Utils.FIGHTERS_PROPERTIES_FILE);
            FighterFactory fighterFactory = new FighterFactory(properties);
            Doctor doctor = new Doctor();

            Fighter testedFighter = fighterFactory.createFighter("Tested Team", Utils.MMA_FIGHTER);
            Fighter testFighter = fighterFactory.createFighter("Test Team", Utils.TEST_FIGHTER);

            int testedFighterWins = 0, testFighterWins = 0;

            for (int i = 0; i < 10; i++)
            {
                arena.fight(testFighter, testedFighter, doctor);

                if (testedFighter.Status == Status.ALIVE)
                {
                    testedFighterWins++;
                }
                else
                {
                    testFighterWins++;
                }

                testFighter.Status = Status.ALIVE;
                testedFighter.Status = Status.ALIVE;

                testedFighter.Health = 100;
                testFighter.Health = 100;
            }

            int balance = Math.Abs(testFighterWins - testedFighterWins);
            Assert.True(balance <= 3);

        }

        [Fact]
        public void Fight_BoxFighterShouldBeBalanced()
        {
            Arena arena = new Arena();
            Dictionary<string, Dictionary<string, double>> properties =
                Helpers.loadCharactersProperties(Utils.FIGHTERS_PROPERTIES_FILE);
            FighterFactory fighterFactory = new FighterFactory(properties);
            Doctor doctor = new Doctor();

            Fighter testedFighter = fighterFactory.createFighter("Tested Team", Utils.BOX_FIGHTER);
            Fighter testFighter = fighterFactory.createFighter("Test Team", Utils.TEST_FIGHTER);

            int testedFighterWins = 0, testFighterWins = 0;

            for (int i = 0; i < 10; i++)
            {
                arena.fight(testFighter, testedFighter, doctor);

                if (testedFighter.Status == Status.ALIVE)
                {
                    testedFighterWins++;
                }
                else
                {
                    testFighterWins++;
                }

                testFighter.Status = Status.ALIVE;
                testedFighter.Status = Status.ALIVE;

                testedFighter.Health = 100;
                testFighter.Health = 100;
            }

            int balance = Math.Abs(testFighterWins - testedFighterWins);
            Assert.True(balance <= 3);

        }

        [Fact]
        public void Fight_ComplexFighterShouldBeBalanced()
        {
            Arena arena = new Arena();
            Dictionary<string, Dictionary<string, double>> properties =
                Helpers.loadCharactersProperties(Utils.FIGHTERS_PROPERTIES_FILE);
            FighterFactory fighterFactory = new FighterFactory(properties);
            Doctor doctor = new Doctor();

            Fighter testedFighter = fighterFactory.createFighter("Tested Team", Utils.COMPLEX_FIGHTER);
            Fighter testFighter = fighterFactory.createFighter("Test Team", Utils.TEST_FIGHTER);

            int testedFighterWins = 0, testFighterWins = 0;

            for (int i = 0; i < 10; i++)
            {
                arena.fight(testFighter, testedFighter, doctor);

                if (testedFighter.Status == Status.ALIVE)
                {
                    testedFighterWins++;
                }
                else
                {
                    testFighterWins++;
                }

                testFighter.Status = Status.ALIVE;
                testedFighter.Status = Status.ALIVE;

                testedFighter.Health = 100;
                testFighter.Health = 100;
            }

            int balance = Math.Abs(testFighterWins - testedFighterWins);
            Assert.True(balance <= 3);

        }

    }

}