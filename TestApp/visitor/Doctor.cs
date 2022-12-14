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

        public void Visit(Fighter fighter)
        {
            if (fighter.Health <= 0)
            {
                fighter.Status = Status.DEAD;
                OnFighterDied(fighter);
                return;
            }
            if (fighter.Health < 100)
            {
                double heal = fighter.HealFactor * fighter.Health;
                if ((int)heal > 0)
                {
                    fighter.Health += (int)heal;
                    OnFighterHealed(fighter, (int)heal);
                }
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
