using System;
using System.Collections.Generic;
using System.Linq;

namespace _3.P_rates
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int[]> cities = new Dictionary<string, int[]>();

            string input = Console.ReadLine();

            while (input != "Sail")
            {
                string[] cityData = input.Split("||", StringSplitOptions.RemoveEmptyEntries);
                string city = cityData[0];
                int population = int.Parse(cityData[1]);
                int gold = int.Parse(cityData[2]);
                if (!cities.ContainsKey(city))
                {
                    cities.Add(city, new int[] { population, gold });
                }
                else
                {
                    cities[city][0] += population;
                    cities[city][1] += gold;
                }

                input = Console.ReadLine();
            }

            string line = Console.ReadLine();

            while (line != "End")
            {
                //•	"Plunder=>{town}=>{people}=>{gold}"
                string[] parts = line.Split("=>", StringSplitOptions.RemoveEmptyEntries);
                string command = parts[0];
                string town = parts[1];

                if (command == "Plunder")
                {
                    int people = int.Parse(parts[2]);
                    int gold = int.Parse(parts[3]);

                    cities[town][0] -= people;
                    cities[town][1] -= gold;

                    Console.WriteLine($"{town} plundered! {gold} gold stolen, {people} citizens killed.");

                    if (cities[town][0] == 0 || cities[town][1] == 0)
                    {
                        Console.WriteLine($"{town} has been wiped off the map!");
                        cities.Remove(town);
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
                        cities[town][1] += gold;
                        Console.WriteLine($"{gold} gold added to the city treasury. {town} now has {cities[town][1]} gold.");
                    }
                }

                line = Console.ReadLine();
            }

            var sorted = cities
                .OrderByDescending(x => x.Value[1])
                .ThenBy(x => x.Key)
                .ToDictionary(x => x.Key, x => x.Value);

            if (sorted.Count == 0)
            {
                Console.WriteLine("Ahoy, Captain! All targets have been plundered and destroyed!");
            }
            else
            {
                Console.WriteLine($"Ahoy, Captain! There are {cities.Count} wealthy settlements to go to:");

                foreach (var town in sorted)
                {
                    Console.WriteLine($"{town.Key} -> Population: {town.Value[0]} citizens, Gold: {town.Value[1]} kg");
                }
            }
        }
    }
}
