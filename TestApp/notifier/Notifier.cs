using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestApp.fighter;
using TestApp.team;
using static System.Net.Mime.MediaTypeNames;

namespace TestApp.notifier
{
    public class Notifier
    {
        public void OnPunchedByAdverseFighter(object source, CustomEventArgs args)
        {
            Fighter adverseFighter = args.Fighter;
            int damage = args.Damage;
            Fighter fighter = (Fighter)source;

            Console.WriteLine(adverseFighter.GetType().Name + " from team " + adverseFighter.Team + " hits with " +
                    damage + " dmg on " + fighter.GetType().Name + " from team " + fighter.Team);
        }
        public void OnDodgedAdverseFighterHit(object source, CustomEventArgs args)
        {
            Fighter adverseFighter = args.Fighter;
            Fighter fighter = (Fighter)source;
            Console.WriteLine(fighter.GetType().Name + " from Team " + fighter.Team + " dodged the hit from "
                    + adverseFighter.GetType().Name + " from Team " + adverseFighter.Team);
        }
        public void OnCriticalDamageHit(object source, CustomEventArgs args)
        {
            Fighter fighter = (Fighter)source;
            int damage = args.Damage;
            Console.WriteLine("Critical damage bonus of "
                   + damage
                   + " DMG for " + fighter.GetType().Name
                   + " from Team " + fighter.Team);
        }

        public void OnFighterDied(object source, CustomEventArgs args)
        {
            Fighter fighter = args.Fighter;
            Console.WriteLine("\t\t\t" + fighter.GetType().Name
                + " from Team " + fighter.Team + " died.");
        }

        public void OnFighterHealed(object source, CustomEventArgs args)
        {
            Fighter fighter = args.Fighter;
            int heal = args.Heal;
            Console.WriteLine("The Doctor healed " + fighter.GetType().Name + " from Team " + fighter.Team
                + " with " + heal + "HP.");
        }

        public void OnTeamWon(object source, CustomEventArgs args)
        {
            Team team = args.Team;
            Console.WriteLine("Team " + team.Name + " has won the game.");
            Console.WriteLine("Fighters alive:");
            foreach (Fighter fighter in team.Fighters)
            {
                Console.WriteLine("Fighter: " + fighter.GetType().Name + " with " + fighter.Health + " HP.");
            }
        }

    }
}
