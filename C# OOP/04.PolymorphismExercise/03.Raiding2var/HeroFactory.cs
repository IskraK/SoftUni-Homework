using System;
using System.Collections.Generic;
using System.Text;

namespace _03.Raiding
{
    public static class HeroFactory
    {
        public static Hero CreateHero(string name,string heroType)
        {
            Hero hero;
            if (heroType == "Druid")
            {
                hero = new Druid(name);
            }
            else if (heroType == "Paladin")
            {
                hero = new Paladin(name);
            }
            else if (heroType == "Rogue")
            {
                hero = new Rogue(name);
            }
            else if (heroType == "Warrior")
            {
                hero = new Warrior(name);
            }
            else
            {
                throw new ArgumentException("Invalid hero!");
            }

            return hero;
        }
    }
}
