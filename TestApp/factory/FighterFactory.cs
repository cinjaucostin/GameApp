using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestApp.common;
using TestApp.fighter;
using TestApp.notifier;

namespace TestApp.factory
{
    public class FighterFactory
    {
        public Dictionary<string, Dictionary<string, double>> Properties
        {
            get; set;
        }

        public Notifier Notifier
        {
            get; set;
        }

        public FighterFactory()
        {

        }

        public FighterFactory(Dictionary<string, Dictionary<string, double>> properties, 
            Notifier notifier)
        {
            Notifier = notifier;
            Properties = properties;
        }

        public Fighter createFighter(string team, string type)
        {
            switch(type)
            {
                case Utils.BOX_FIGHTER:
                    return new BoxFighter(team, 
                        Properties[type][Utils.CRITICAL_CHANCE],
                        Properties[type][Utils.CRITICAL_DAMAGE_BONUS],
                        Properties[type][Utils.DODGE_HIT_CHANCE],
                        Properties[type][Utils.AGILITY],
                        Properties[type][Utils.HEAL],
                         Properties[type][Utils.MIN_DAMAGE],
                         Properties[type][Utils.MAX_DAMAGE],
                         this.Notifier);
                case Utils.MMA_FIGHTER:
                    return new MmaFighter(team,
                         Properties[type][Utils.CRITICAL_CHANCE],
                         Properties[type][Utils.CRITICAL_DAMAGE_BONUS],
                         Properties[type][Utils.DODGE_HIT_CHANCE],
                         Properties[type][Utils.AGILITY],
                         Properties[type][Utils.HEAL],
                         Properties[type][Utils.MIN_DAMAGE],
                         Properties[type][Utils.MAX_DAMAGE],
                         this.Notifier);
                case Utils.COMPLEX_FIGHTER:
                    return new ComplexFighter(team,
                         Properties[type][Utils.CRITICAL_CHANCE],
                         Properties[type][Utils.CRITICAL_DAMAGE_BONUS],
                         Properties[type][Utils.DODGE_HIT_CHANCE],
                         Properties[type][Utils.AGILITY],
                         Properties[type][Utils.HEAL],
                         Properties[type][Utils.MIN_DAMAGE],
                         Properties[type][Utils.MAX_DAMAGE],
                         this.Notifier);
                case Utils.TEST_FIGHTER:
                    return new TestFighter(team,
                         Properties[type][Utils.CRITICAL_CHANCE],
                         Properties[type][Utils.CRITICAL_DAMAGE_BONUS],
                         Properties[type][Utils.DODGE_HIT_CHANCE],
                         Properties[type][Utils.AGILITY],
                         Properties[type][Utils.HEAL],
                         Properties[type][Utils.MIN_DAMAGE],
                         Properties[type][Utils.MAX_DAMAGE],
                         this.Notifier);
                default: throw new ArgumentException("Invalid argument for function createFighter.\n");
            }
        }

    }
}
