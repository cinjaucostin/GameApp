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
        public double CriticalDamageBonus
        {
            get; set;
        }
        public double DodgeHitChance
        {
            get; set;
        }

        public double Agility
        {
            get; set;
        }

        public double HealFactor
        {
            get; set;
        }

        public int MinDamage
        {
            get; set;
        }
        public int MaxDamage
        {
            get; set;
        }

        public Random Fortune
        {
            get; set;
        }

        public Fighter(string team, double criticalChance, double criticalDamageBonus, 
            double dodgeHitChance, double agility, double healFactor, double minDamage,
            double maxDamage)
        {
            Health = 100;
            Team = team;
            Status = Status.ALIVE;
            CriticalChance = criticalChance;
            CriticalDamageBonus = criticalDamageBonus;
            DodgeHitChance = dodgeHitChance;
            Agility = agility;
            HealFactor = healFactor;
            MinDamage = (int)minDamage;
            MaxDamage = (int)maxDamage;
            Fortune = new Random();
        }

        public abstract int hitDamage();
        public abstract void accept(IVisitor visitor);

        public void getHit(Fighter adverseFighter, int damage)
        {
            
            if (Fortune.NextDouble() < DodgeHitChance)
            {
                Console.WriteLine(this.GetType().Name + " dodged the hit from "
                    + adverseFighter.GetType().Name);
                return;
            }

            this.Health -= damage;

            Console.WriteLine(adverseFighter.GetType().Name + " from team " + adverseFighter.Team + " hits with " +
                    damage + " dmg on " + this.GetType().Name + " from team " + this.Team);

        }

        public override string ToString()
        {
            return "Player " + GetType().Name;
        }
    }
}
