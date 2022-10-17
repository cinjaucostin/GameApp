using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestApp.fighter;
using TestApp.enums;
using TestApp.notifier;

namespace TestApp.visitor
{
    public class Doctor : IVisitor
    {

        public event EventHandler<CustomEventArgs> FighterDied;
        public event EventHandler<CustomEventArgs> FighterHealed;

        public Doctor(Notifier notifier)
        {
            this.FighterDied += notifier.OnFighterDied;
            this.FighterHealed += notifier.OnFighterHealed;
        }

        public void Visit(BoxFighter boxFighter)
        {
            if(boxFighter.Health <= 0)
            {
                boxFighter.Status = Status.DEAD;
                OnFighterDied(boxFighter);
                return;
            }
            if(boxFighter.Health < 100)
            {
                double heal = boxFighter.HealFactor * boxFighter.Health;
                boxFighter.Health += (int)heal;
                OnFighterHealed(boxFighter, (int)heal);
            }
        }

        public void Visit(MmaFighter mmaFighter)
        {
            if (mmaFighter.Health <= 0)
            {
                mmaFighter.Status = Status.DEAD;
                OnFighterDied(mmaFighter);
                return;
            }
            if(mmaFighter.Health < 100)
            {
                double heal = mmaFighter.HealFactor * mmaFighter.Health;
                mmaFighter.Health += (int)heal;
                OnFighterHealed(mmaFighter, (int)heal);
            }

        }

        public void Visit(ComplexFighter complexFighter)
        {
            if (complexFighter.Health <= 0)
            {
                complexFighter.Status = Status.DEAD;
                OnFighterDied(complexFighter);
                return;
            }
            if (complexFighter.Health < 100)
            {
                double heal = complexFighter.HealFactor * complexFighter.Health;
                complexFighter.Health += (int)heal;
                OnFighterHealed(complexFighter, (int)heal);
            }
        }

        public void Visit(TestFighter testFighter)
        {
            if (testFighter.Health <= 0)
            {
                testFighter.Status = Status.DEAD;
                OnFighterDied(testFighter);
                return;
            }
            if (testFighter.Health < 100)
            {
                double heal = testFighter.HealFactor * testFighter.Health;
                testFighter.Health += (int)heal;
                OnFighterHealed(testFighter, (int)heal);
            }
        }

        protected virtual void OnFighterDied(Fighter fighter)
        {
            if(FighterDied != null)
            {
                FighterDied(this, new CustomEventArgs(fighter));
            }
        }

        protected virtual void OnFighterHealed(Fighter fighter, int heal)
        {
            if (FighterHealed != null)
            {
                CustomEventArgs customEventArgs = new CustomEventArgs(fighter);
                customEventArgs.Heal = heal;
                FighterHealed(this, customEventArgs);
            }
        }

    }
}
