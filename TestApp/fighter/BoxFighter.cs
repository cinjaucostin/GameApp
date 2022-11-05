using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestApp.enums;
using TestApp.notifier;
using TestApp.visitor;

namespace TestApp.fighter
{
    public class BoxFighter : Fighter
    {
        // prea multi parametri pentru un constructor. 
        // cred ca ar fi fost mai dragut sa faci o clasa care sa le adune pe toate.
        public BoxFighter(string team, double criticalChance, double criticalDamageBonus, 
            double dodgeHitChance, double agility, double healFactor, double minDamage, 
            double maxDamage, Notifier notifier) 
            : base(team, criticalChance, criticalDamageBonus, dodgeHitChance, agility, healFactor,
                    minDamage, maxDamage, notifier)
        {
        }

        //
        public override void Accept(IDoctorVisitor doctor)
        {
            doctor.Visit(this);
        }

        public override int HitDamage()
        {
            int damage = Fortune.Next(MinDamage, MaxDamage);
            if (Fortune.NextDouble() < CriticalChance)
            {
                damage += (int)(CriticalDamageBonus * damage);
                OnCriticalDamageHit((int)(CriticalDamageBonus * damage));
            }
            return damage;
        }

    }
}
