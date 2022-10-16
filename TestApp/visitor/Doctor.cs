using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestApp.fighter;
using TestApp.enums;

namespace TestApp.visitor
{
    public class Doctor : IVisitor
    {
        public void Visit(BoxFighter boxFighter)
        {
            if(boxFighter.Health <= 0)
            {
                boxFighter.Status = Status.DEAD;
                Console.WriteLine("\t\t\t" + boxFighter.GetType().Name + " from Team " + boxFighter.Team + " died.");
                return;
            }
            double heal = boxFighter.HealFactor * boxFighter.Health;
            boxFighter.Health += (int) heal;
            Console.WriteLine("The Doctor healed " + boxFighter.GetType().Name + " from Team " + boxFighter.Team
                + " with " + (int)heal + "HP.");
        }

        public void Visit(MmaFighter mmaFighter)
        {
            if (mmaFighter.Health <= 0)
            {
                mmaFighter.Status = Status.DEAD;
                Console.WriteLine("\t\t\t" + mmaFighter.GetType().Name + " from Team " + mmaFighter.Team + " died.");
                return;
            }
            double heal = mmaFighter.HealFactor * mmaFighter.Health;
            mmaFighter.Health += (int)heal;
            Console.WriteLine("The Doctor healed " + mmaFighter.GetType().Name + " from Team " + mmaFighter.Team
                + " with " + (int)heal + "HP.");

        }

        public void Visit(ComplexFighter complexFighter)
        {
            if (complexFighter.Health <= 0)
            {
                complexFighter.Status = Status.DEAD;
                Console.WriteLine("\t\t\t" + complexFighter.GetType().Name + " from Team " + complexFighter.Team + " died.");
                return;
            }
            double heal = complexFighter.HealFactor * complexFighter.Health;
            complexFighter.Health += (int)heal;
            Console.WriteLine("The Doctor healed " + complexFighter.GetType().Name + " from Team " + complexFighter.Team
                + " with " + (int)heal + "HP.");
        }

        public void Visit(TestFighter testFighter)
        {
            if (testFighter.Health <= 0)
            {
                testFighter.Status = Status.DEAD;
                Console.WriteLine("\t\t\t" + testFighter.GetType().Name + " from Team " + testFighter.Team + " died.");
                return;
            }
            double heal = testFighter.HealFactor * testFighter.Health;
            testFighter.Health += (int)heal;
            Console.WriteLine("The Doctor healed " + testFighter.GetType().Name + " from Team " + testFighter.Team
                + " with " + (int)heal + "HP."); ;
        }

    }
}
