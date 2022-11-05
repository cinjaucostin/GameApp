using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestApp.notifier;
using TestApp.visitor;

namespace TestApp.fighter
{
    public class MmaFighter : Fighter
    {
        public MmaFighter(string team, double criticalChance, double criticalDamageBonus,
            double dodgeHitChance, double agility, double healFactor, double minDamage, 
            double maxDamage, Notifier notifier)
            : base(team, criticalChance, criticalDamageBonus, dodgeHitChance, agility, healFactor,
                    minDamage, maxDamage, notifier)
        {
        }

        public override void Accept(IDoctorVisitor doctor)
        {
            doctor.Visit(this);
        }

        public override int HitDamage()
        {
            int damage = Fortune.Next(MinDamage, MaxDamage);
            if(Fortune.NextDouble() < CriticalChance)
            {
                damage += (int)(CriticalDamageBonus * damage);
                OnCriticalDamageHit((int)(CriticalDamageBonus * damage));
            }
            return damage;
        }

    }
}
