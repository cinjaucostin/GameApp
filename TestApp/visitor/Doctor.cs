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
                Console.WriteLine("Fighter " + boxFighter.GetType().Name + " from Team " + boxFighter.Team + " died.");
                return;
            }
            double heal = 0.1 * boxFighter.Health;
            boxFighter.Health += (int) heal;
            Console.WriteLine("The Doctor healed Fighter " + boxFighter.GetType().Name + " from Team " + boxFighter.Team
                + " with " + (int)heal + "HP.");
        }

        public void Visit(MmaFighter mmaFighter)
        {
            if (mmaFighter.Health <= 0)
            {
                mmaFighter.Status = Status.DEAD;
                Console.WriteLine("Fighter " + mmaFighter.GetType().Name + "from Team " + mmaFighter.Team + " died.");
                return;
            }
            double heal = 0.1 * mmaFighter.Health;
            mmaFighter.Health += (int)heal;
            Console.WriteLine("The Doctor healed Fighter " + mmaFighter.GetType().Name + " from Team " + mmaFighter.Team
                + " with " + (int)heal + "HP.");

        }

        public void Visit(ComplexFighter complexFighter)
        {
            if (complexFighter.Health <= 0)
            {
                complexFighter.Status = Status.DEAD;
                Console.WriteLine("Fighter " + complexFighter.GetType().Name + "from Team " + complexFighter.Team + " died.");
                return;
            }
            double heal = 0.05 * complexFighter.Health;
            complexFighter.Health += (int)heal;
            Console.WriteLine("The Doctor healed Fighter " + complexFighter.GetType().Name + " from Team " + complexFighter.Team
                + " with " + (int)heal + "HP.");
        }
    }
}
