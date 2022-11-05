using TestApp.enums;
using TestApp.notifier;
using TestApp.visitor;

namespace TestApp.fighter
{
    public abstract class Fighter
    {

        public event EventHandler<CustomEventArgs> PunchedByAdverseFighter;

        public event EventHandler<CustomEventArgs> DodgedAdverseFighterHit;

        public event EventHandler<CustomEventArgs> CriticalDamageHit;

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
            double maxDamage, Notifier notifier)
        {
            if (notifier is null)
            {
                throw new ArgumentNullException(nameof(notifier));
            }

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
            this.PunchedByAdverseFighter += notifier.OnPunchedByAdverseFighter;
            this.CriticalDamageHit += notifier.OnCriticalDamageHit;
            this.DodgedAdverseFighterHit += notifier.OnDodgedAdverseFighterHit;

        }

        public abstract int HitDamage();
        public abstract void Accept(IDoctorVisitor doctor);

        public void getHit(Fighter adverseFighter, int damage)
        {
            if (adverseFighter is null)
            {
                throw new ArgumentNullException(nameof(adverseFighter));
            }
            if (Fortune.NextDouble() < DodgeHitChance)
            {
                OnDodgedAdverseFighterHit(adverseFighter);
                return;
            }
            Health -= damage;
            OnPunchedByAdverseFighter(adverseFighter, damage);
        }

        protected virtual void OnPunchedByAdverseFighter(Fighter adverseFighter, int damage)
        {
            if(PunchedByAdverseFighter != null)
            {
                PunchedByAdverseFighter(this, 
                    new CustomEventArgs(adverseFighter, damage));
            }
        }

        protected virtual void OnDodgedAdverseFighterHit(Fighter adverseFighter)
        {
            if(DodgedAdverseFighterHit != null)
            {
                DodgedAdverseFighterHit(this, 
                    new CustomEventArgs(adverseFighter));
            }
        }

        protected virtual void OnCriticalDamageHit(int criticalDamage)
        {
            if (CriticalDamageHit != null)
            {
                CriticalDamageHit(this, 
                    new CustomEventArgs(criticalDamage));
            }
        }
    }
}
