using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestApp.visitor;

namespace TestApp.fighter
{
    public class MmaFighter : Fighter
    {
        public MmaFighter(string team) : base(team)
        {
            this.CriticalChance = 30;
            this.CriticalDamageBonus = 0.15;
            this.DodgeHitChance = 0.2;
        }

        public override void accept(IVisitor visitor)
        {
            visitor.Visit(this);
        }

        public override int hitDamage()
        {
            Random rand = new Random();
            int damage = rand.Next(35, 40);
            if(rand.NextDouble() < CriticalChance)
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
