using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestApp.enums;
using TestApp.visitor;

namespace TestApp.fighter
{
    public class BoxFighter : Fighter
    {
        public BoxFighter(string team) : base(team)
        {
            this.CriticalChance = 0.35;
            this.CriticalDamageBonus = 0.15;
            this.DodgeHitChance = 0.25;
        }

        public override void accept(IVisitor visitor)
        {
            visitor.Visit(this);
        }

        public override int hitDamage()
        {
            Random rand = new Random();
            int damage = rand.Next(30, 45);
            if (rand.NextDouble() < CriticalChance)
            {
                damage += (int)(CriticalDamageBonus * damage);
                Console.WriteLine("Critical damage bonus of "
                    + (int)(CriticalDamageBonus * damage)
                    + " DMG for Fighter " + this.GetType().Name
                    + " from Team " + this.Team);
            }
            return damage;
        }

    }
}
