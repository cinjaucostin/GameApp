using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestApp.factory;
using TestApp.fighter;
using TestApp.team;
using TestApp.enums;

namespace TestApp.arena
{
    public class Arena
    {
        public void fight(Fighter fighter1, Fighter fighter2)
        {
            int fighter1HitDamage = fighter1.hitDamage();
            fighter2.Health -= fighter1HitDamage;
            Console.WriteLine("Fighter " + fighter1.GetType().Name + " from team " + fighter1.Team + " hits with " +
                fighter1HitDamage + " dmg on Fighter " + fighter2.GetType().Name + " from team " + fighter2.Team);
            if (fighter2.Health <= 0)
            {
                fighter2.Status = Status.DEAD;
                Console.WriteLine("Fighter " + fighter2.GetType().Name + "from Team " + fighter2.Team + " dies.");
                return;
            }

            int fighter2HitDamage = fighter2.hitDamage();
            fighter1.Health -= fighter2HitDamage;
            Console.WriteLine("Fighter " + fighter2.GetType().Name + " from team " + fighter2.Team + " hits with " +
                fighter2HitDamage + " dmg on Fighter " + fighter1.GetType().Name + " from team " + fighter1.Team);

            if (fighter1.Health <= 0)
            {
                fighter1.Status = Status.DEAD;
                Console.WriteLine("Fighter " + fighter1.GetType().Name + "from Team " + fighter1.Team + " dies.");
            }

        }
    }
}
