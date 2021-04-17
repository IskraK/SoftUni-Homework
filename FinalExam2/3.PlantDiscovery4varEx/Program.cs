using System;
using System.Collections.Generic;
using System.Linq;

namespace _3.PlantDiscovery4varEx
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Dictionary<string, int> rarityByPlant = new Dictionary<string, int>();
            Dictionary<string, List<int>> ratingsByPlant = new Dictionary<string, List<int>>();

            for (int i = 0; i < n; i++)
            {
                string[] parts = Console.ReadLine()
                    .Split("<->", StringSplitOptions.RemoveEmptyEntries);
                string plantName = parts[0];
                int rarity = int.Parse(parts[1]);
                rarityByPlant[plantName] = rarity;

                if (!ratingsByPlant.ContainsKey(plantName))
                {
                    ratingsByPlant[plantName] = new List<int>();
                }
            }

            while (true)
            {
                string line = Console.ReadLine();

                if (line == "Exhibition")
                {
                    break;
                }

                string[] commandParts = line
                    .Split(": ", StringSplitOptions.RemoveEmptyEntries);
                string command = commandParts[0];

                if (command == "Rate")
                {
                    string[] arg = commandParts[1]
                        .Split(" - ", StringSplitOptions.RemoveEmptyEntries);

                    if (arg.Length != 2)
                    {
                        Console.WriteLine("error");
                    }

                    string plant = arg[0];
                    int rating = int.Parse(arg[1]);

                    if (!ratingsByPlant.ContainsKey(plant))
                    {
                        Console.WriteLine("error");
                        continue;
                    }

                    ratingsByPlant[plant].Add(rating);
                }
                else if (command == "Reset")
                {
                    string plant = commandParts[1];
                    if (!ratingsByPlant.ContainsKey(plant))
                    {
                        Console.WriteLine("error");
                        continue;
                    }
                    ratingsByPlant[plant].Clear();
                }
                else if (command == "Update")
                {
                    string[] arg = commandParts[1]
                                            .Split(" - ", StringSplitOptions.RemoveEmptyEntries);
                    if (arg.Length != 2)
                    {
                        Console.WriteLine("error");
                        continue;
                    }

                    string plant = arg[0];
                    int newRarity = int.Parse(arg[1]);

                    if (!rarityByPlant.ContainsKey(plant))
                    {
                        Console.WriteLine("error");
                        continue;
                    }
                    rarityByPlant[plant] = newRarity;
                }
                else
                {
                    Console.WriteLine("error");
                }
            }

            Dictionary<string, int> sorted = rarityByPlant
                .OrderByDescending(x => x.Value)
                .ThenByDescending(x =>
                {
                    List<int> ratings = ratingsByPlant[x.Key];
                    if (ratings.Count == 0)
                    {
                        return 0;
                    }
                    return ratings.Average();
                })
                .ToDictionary(x => x.Key, x => x.Value);

            Console.WriteLine("Plants for the exhibition :");

            foreach (var kvp in sorted)
            {
                string plantName = kvp.Key;
                int rarity = kvp.Value;
                double rating = 0;
                List<int> ratings = ratingsByPlant[kvp.Key];

                if (ratings.Count != 0)
                {
                    rating = ratings.Average();
                }

                Console.WriteLine($" {plantName}; Rarity: {rarity}; Rating: {rating:F2}");
            }
        }
    }
}
