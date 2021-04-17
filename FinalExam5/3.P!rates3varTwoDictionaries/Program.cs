using System;
using System.Collections.Generic;
using System.Linq;

namespace _3.P_rates3varTwoDictionaries
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> goldByTown = new Dictionary<string, int>();
            Dictionary<string, int> populationByTown = new Dictionary<string, int>();

            string input = Console.ReadLine();

            while (input != "Sail")
            {
                string[] cityData = input.Split("||", StringSplitOptions.RemoveEmptyEntries);
                string cityName = cityData[0];
                int population = int.Parse(cityData[1]);
                int gold = int.Parse(cityData[2]);
                if (!goldByTown.ContainsKey(cityName))
                {
                    goldByTown.Add(cityName, gold);
                    populationByTown.Add(cityName, population);
                }
                else
                {
                    populationByTown[cityName] += population;
                    goldByTown[cityName] += gold;
                }

                input = Console.ReadLine();
            }

            string line = Console.ReadLine();

            while (line != "End")
            {
                string[] parts = line.Split("=>", StringSplitOptions.RemoveEmptyEntries);
                string command = parts[0];
                string townName = parts[1];

                if (command == "Plunder")
                {
                    int people = int.Parse(parts[2]);
                    int gold = int.Parse(parts[3]);

                    populationByTown[townName] -= people;
                    goldByTown[townName] -= gold;

                    Console.WriteLine($"{townName} plundered! {gold} gold stolen, {people} citizens killed.");

                    if (populationByTown[townName] == 0 || goldByTown[townName] == 0)
                    {
                        Console.WriteLine($"{townName} has been wiped off the map!");
                        goldByTown.Remove(townName);
                        populationByTown.Remove(townName);
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
                        goldByTown[townName] += gold;
                        Console.WriteLine($"{gold} gold added to the city treasury. {townName} now has {goldByTown[townName]} gold.");
                    }
                }

                line = Console.ReadLine();
            }

            var sorted = goldByTown
                .OrderByDescending(x => x.Value)
                .ThenBy(x => x.Key)
                .ToDictionary(x => x.Key, x => x.Value);

            if (sorted.Count == 0)
            {
                Console.WriteLine("Ahoy, Captain! All targets have been plundered and destroyed!");
            }
            else
            {
                Console.WriteLine($"Ahoy, Captain! There are {goldByTown.Count} wealthy settlements to go to:");

                foreach (var town in sorted)
                {
                    string townName = town.Key;
                    int gold = town.Value;
                    int population = populationByTown[townName];

                    Console.WriteLine($"{townName} -> Population: {population} citizens, Gold: {gold} kg");
                }
            }
        }
    }
}
