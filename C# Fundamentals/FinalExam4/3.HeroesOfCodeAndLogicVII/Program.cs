using System;
using System.Collections.Generic;
using System.Linq;

namespace _3.HeroesOfCodeAndLogicVII
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int[]> heroes = new Dictionary<string, int[]>();

            int numberOfHeroes = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfHeroes; i++)
            {
                string[] hero = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string heroName = hero[0];
                int hitPoints = int.Parse(hero[1]);
                int manaPoints = int.Parse(hero[2]);
                heroes.Add(heroName, new int[] { hitPoints, manaPoints });
            }

            string line = Console.ReadLine();

            while (line != "End")
            {
                string[] parts = line.Split(" - ", StringSplitOptions.RemoveEmptyEntries);
                string command = parts[0];
                string heroName = parts[1];

                switch (command)
                {
                    case "CastSpell":
                        int neededMP = int.Parse(parts[2]);
                        string spellName = parts[3];
                        //int heroMP = heroes[heroName][1];

                        if (heroes[heroName][1] >= neededMP)
                        {
                            heroes[heroName][1]-= neededMP;
                            Console.WriteLine($"{heroName} has successfully cast {spellName} and now has {heroes[heroName][1]} MP!");
                        }
                        else
                        {
                            Console.WriteLine($"{heroName} does not have enough MP to cast {spellName}!");
                        }
                        break;
                    case "TakeDamage":
                        int damage = int.Parse(parts[2]);
                        string attacker = parts[3];
                        //int heroHP = heroes[heroName][0];
                        heroes[heroName][0] -= damage;

                        if (heroes[heroName][0] > 0)
                        {
                            Console.WriteLine($"{heroName} was hit for {damage} HP by {attacker} and now has {heroes[heroName][0]} HP left!");
                        }
                        else
                        {
                            Console.WriteLine($"{heroName} has been killed by {attacker}!");
                            heroes.Remove(heroName);
                        }
                        break;
                    case "Recharge":
                        int amount = int.Parse(parts[2]);
                        //heroMP = heroes[heroName][1];

                        if (heroes[heroName][1] + amount > 200)
                        {
                            amount = 200 - heroes[heroName][1];
                            heroes[heroName][1] = 200;
                        }
                        else
                        {
                            heroes[heroName][1] += amount;
                        }
                        Console.WriteLine($"{heroName} recharged for {amount} MP!");
                        break;
                    case "Heal":
                        amount = int.Parse(parts[2]);
                        //heroHP = heroes[heroName][0];

                        if (heroes[heroName][0] + amount > 100)
                        {
                            amount = 100 - heroes[heroName][0];
                            heroes[heroName][0] = 100;
                        }
                        else
                        {
                            heroes[heroName][0] += amount;
                        }

                        Console.WriteLine($"{heroName} healed for {amount} HP!");
                        break;
                    default:
                        break;
                }

                line = Console.ReadLine();
            }

            heroes = heroes
                .OrderByDescending(h => h.Value[0])
                .ThenBy(n => n.Key)
                .ToDictionary(k => k.Key, v => v.Value);

            foreach (var hero in heroes)
            {
                Console.WriteLine($"{hero.Key}");
                Console.WriteLine($"  HP: {hero.Value[0]}");
                Console.WriteLine($"  MP: {hero.Value[1]}");
            }
        }
    }
}
