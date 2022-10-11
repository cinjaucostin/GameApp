using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestApp.factory;
using TestApp.fighter;
using TestApp.team;
using TestApp.enums;
using System.ComponentModel;
using TestApp.visitor;

namespace TestApp.arena
{
    public class Arena
    {
        public void fight(Fighter fighter1, Fighter fighter2, IVisitor doctor)
        {
            int fighter1HitDamage, fighter2HitDamage;
            Console.WriteLine("---------------------------------------------------");
            Console.WriteLine(fighter1.GetType().Name + " from team " + fighter1.Team +
                " VS " + fighter2.GetType().Name + " from team " + fighter2.Team);

            while(fighter1.Status == Status.ALIVE && fighter2.Status == Status.ALIVE)
            {

                if (fighter2.Status == Status.ALIVE)
                {
                    fighter2HitDamage = fighter2.hitDamage();
                    fighter1.getHit(fighter2, fighter2HitDamage);
                    fighter1.accept(doctor);
                }

                if (fighter1.Status == Status.ALIVE)
                {
                    fighter1HitDamage = fighter1.hitDamage();
                    fighter2.getHit(fighter1, fighter1HitDamage);
                    fighter2.accept(doctor);
                }

            }

            Console.WriteLine("---------------------------------------------------");

        }
    }
}
