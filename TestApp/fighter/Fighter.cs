using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestApp.enums;
using TestApp.visitor;

namespace TestApp.fighter
{
    public abstract class Fighter
    {
        public int Health
        {
            get; set;
        }

        public string Team
        {
            get; set;
        }
        public Status Status
        {
            get; set;
        }
        public double CriticalChance
        {
            get; set;
        }
        public double DodgeHitChance
        {
            get; set;
        }

        public double CriticalDamageBonus
        {
            get; set;
        }

        public Fighter(string team)
        {
            Health = 100;
            Team = team;
            Status = Status.ALIVE;
        }

        public abstract int hitDamage();
        public abstract void accept(IVisitor visitor);

        public void getHit(Fighter adverseFighter, int damage)
        {
            Random random = new Random();

            if (random.NextDouble() < DodgeHitChance)
            {
                Console.WriteLine("Fighter " + this.GetType().Name + " dodged the hit from Fighter "
                    + adverseFighter.GetType().Name);
                return;
            }

            this.Health -= damage;

            Console.WriteLine("Fighter " + adverseFighter.GetType().Name + " from team " + adverseFighter.Team + " hits with " +
                    damage + " dmg on Fighter " + this.GetType().Name + " from team " + this.Team);

        }

        public override string ToString()
        {
            return "Player " + GetType().Name;
        }
    }
}
