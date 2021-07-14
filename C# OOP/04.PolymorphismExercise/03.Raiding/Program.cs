using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.Raiding
{
    public class Program
    {
        static void Main(string[] args)
        {
            List<Hero> heroes = new List<Hero>();

            int numberOfHeroes = int.Parse(Console.ReadLine());

            while (heroes.Count != numberOfHeroes)
            {
                try
                {
                    string name = Console.ReadLine();
                    string heroType = Console.ReadLine();

                    if (heroType == "Druid")
                    {
                        heroes.Add(new Druid(name));
                    }
                    else if (heroType == "Paladin")
                    {
                        heroes.Add(new Paladin(name));
                    }
                    else if (heroType == "Rogue")
                    {
                        heroes.Add(new Rogue(name));
                    }
                    else if (heroType == "Warrior")
                    {
                        heroes.Add(new Warrior(name));
                    }
                    else
                    {
                        throw new ArgumentException("Invalid hero!");
                    }
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            int bossPower = int.Parse(Console.ReadLine());

            foreach (var hero in heroes)
            {
                Console.WriteLine(hero.CastAbility());
            }

            int heroesPower = heroes.Sum(n => n.Power);

            if (heroesPower >= bossPower)
            {
                Console.WriteLine("Victory!");
            }
            else
            {
                Console.WriteLine("Defeat...");
            }
        }
    }
}
