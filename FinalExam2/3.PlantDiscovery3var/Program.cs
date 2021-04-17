using System;
using System.Collections.Generic;
using System.Linq;

namespace _3.PlantDiscovery3var
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Dictionary<string, int> plants = new Dictionary<string, int>();
            Dictionary<string, List<double>> ratings = new Dictionary<string, List<double>>();

            for (int i = 0; i < n; i++)
            {
                string[] data = Console.ReadLine()
                    .Split("<->", StringSplitOptions.RemoveEmptyEntries);
                string plantName = data[0];
                int rarity = int.Parse(data[1]);
                if (!plants.ContainsKey(plantName))
                {
                    plants.Add(plantName, rarity);
                    ratings.Add(plantName, new List<double>());
                }
                else
                {
                    if (plants[plantName] != rarity)
                    {
                        plants[plantName] = rarity;
                    }
                }
            }

            string line = Console.ReadLine();

            while (line != "Exhibition")
            {
                string[] parts = line.Split(new char[] { ' ', ':', '-' }, StringSplitOptions.RemoveEmptyEntries);
                string command = parts[0];
                string plantName = parts[1];

                if (!plants.ContainsKey(plantName))
                {
                    Console.WriteLine("error");
                    line = Console.ReadLine();
                    continue;
                }

                switch (command)
                {
                    case "Rate":
                        //•	Rate: { plant} - { rating} – add the given rating to the plant(store all ratings)
                        int rating = int.Parse(parts[2]);
                        ratings[plantName].Add(rating);
                        break;
                    case "Update":
                        //•	Update: { plant}- { new_rarity} – update the rarity of the plant with the new one
                        int newRarity = int.Parse(parts[2]);
                            plants[plantName] = newRarity;
                        break;
                    case "Reset":
                        //•	Reset: { plant} – remove all the ratings of the given plant
                        ratings[plantName].Clear();
                        break;
                    default:
                        Console.WriteLine("error");
                        break;
                }

                line = Console.ReadLine();
            }

            Console.WriteLine("Plants for the exhibition:");
            var sorted = plants
                .OrderByDescending(x => x.Value)
                .ThenByDescending(x => ratings[x.Key].Count > 0 ? ratings[x.Key].Average(): 0.0);
            foreach (var plant in sorted)
            {
                var averageRating= ratings[plant.Key].Count > 0 ? ratings[plant.Key].Sum() / ratings[plant.Key].Count : 0.0;
                Console.WriteLine($"- {plant.Key}; Rarity: {plant.Value}; Rating: {averageRating:F2}");
            }
        }
    }
}
