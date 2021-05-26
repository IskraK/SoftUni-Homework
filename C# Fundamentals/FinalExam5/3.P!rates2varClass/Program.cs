using System;
using System.Collections.Generic;
using System.Linq;

namespace _3.P_rates2varClass
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Town> towns = new Dictionary<string, Town>();

            string input = Console.ReadLine();

            while (input != "Sail")
            {
                string[] cityData = input.Split("||", StringSplitOptions.RemoveEmptyEntries);
                string cityName = cityData[0];
                int population = int.Parse(cityData[1]);
                int gold = int.Parse(cityData[2]);
                if (!towns.ContainsKey(cityName))
                {
                    Town town = new Town(cityName, population, gold);

                    towns.Add(cityName,town);
                }
                else
                {
                    Town town = towns[cityName];
                    town.Population += population;
                    town.Gold += gold;
                }

                input = Console.ReadLine();
            }

            string line = Console.ReadLine();

            while (line != "End")
            {
                string[] parts = line.Split("=>", StringSplitOptions.RemoveEmptyEntries);
                string command = parts[0];
                string townName = parts[1];
                Town town = towns[townName];

                if (command == "Plunder")
                {
                    int people = int.Parse(parts[2]);
                    int gold = int.Parse(parts[3]);

                    town.Population -= people;
                    town.Gold -= gold;

                    Console.WriteLine($"{townName} plundered! {gold} gold stolen, {people} citizens killed.");

                    if (town.Population == 0 || town.Gold == 0)
                    {
                        Console.WriteLine($"{townName} has been wiped off the map!");
                        towns.Remove(townName);
                    }
                }
                else if (command == "Prosper")
                {
                    int gold = int.Parse(parts[2]);

                    if (gold < 0)
                    {
                        Console.WriteLine("Gold added cannot be a negative number!");
                    }
                    else
                    {
                        town.Gold += gold;
                        Console.WriteLine($"{gold} gold added to the city treasury. {townName} now has {town.Gold} gold.");
                    }
                }

                line = Console.ReadLine();
            }

            var sorted = towns
                .OrderByDescending(x => x.Value.Gold)
                .ThenBy(x => x.Key)
                .ToDictionary(x => x.Key, x => x.Value);

            if (sorted.Count == 0)
            {
                Console.WriteLine("Ahoy, Captain! All targets have been plundered and destroyed!");
            }
            else
            {
                Console.WriteLine($"Ahoy, Captain! There are {towns.Count} wealthy settlements to go to:");

                foreach (var town in sorted)
                {
                    Console.WriteLine($"{town.Key} -> Population: {town.Value.Population} citizens, Gold: {town.Value.Gold} kg");
                }
            }
        }
    }

    internal class Town
    {
        public Town(string townName, int population, int gold)
        {
            Name = townName;
            Population = population;
            Gold = gold;
        }

        public string Name { get; set; }
        public int Population { get; set; }
        public int Gold { get; set; }
    }
}
