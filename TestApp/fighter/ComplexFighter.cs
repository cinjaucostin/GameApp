using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestApp.visitor;

namespace TestApp.fighter
{
    public class ComplexFighter : Fighter
    {
        public ComplexFighter(string team) : base(team)
        {
            this.CriticalChance = 25;
            this.CriticalDamageBonus = 0.1;
            this.DodgeHitChance = 0.2;
        }

        public override void accept(IVisitor visitor)
        {
            visitor.Visit(this);
        }

        public override int hitDamage()
        {
            Random rand = new Random();
            int damage = rand.Next(45, 50);
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
