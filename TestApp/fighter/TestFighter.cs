using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestApp.visitor;

namespace TestApp.fighter
{
    public class TestFighter : Fighter
    {
        public TestFighter(string team, double criticalChance, double criticalDamageBonus, double dodgeHitChance, 
            double agility, double healFactor, double minDamage, double maxDamage) : 
            base(team, criticalChance, criticalDamageBonus, dodgeHitChance, agility, healFactor, minDamage, maxDamage)
        {
        }

        public override void accept(IVisitor visitor)
        {
            visitor.Visit(this);
        }

        public override int hitDamage()
        {
            int damage = Fortune.Next(MinDamage, MaxDamage);
            if (Fortune.NextDouble() < CriticalChance)
            {
                damage += (int)(CriticalDamageBonus * damage);
                Console.WriteLine("Critical damage bonus of "
                   + (int)(CriticalDamageBonus * damage)
                   + " DMG for " + this.GetType().Name
                   + " from Team " + this.Team);
            }
            return damage;
        }
    }
}
