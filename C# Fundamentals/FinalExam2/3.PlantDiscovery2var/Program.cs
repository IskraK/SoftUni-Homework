using System;
using System.Collections.Generic;
using System.Linq;

namespace _3.PlantDiscovery2var
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<Plant> plants = new List<Plant>();

            for (int i = 0; i < n; i++)
            {
                string[] data = Console.ReadLine()
                    .Split("<->", StringSplitOptions.RemoveEmptyEntries);
                string plantName = data[0];
                int rarity = int.Parse(data[1]);

                if (!plants.Any(x => x.Name == plantName))
                {
                    Plant plant = new Plant(plantName, rarity);
                    plants.Add(plant);
                }
                else
                {
                    Plant plant = plants.FirstOrDefault(x => x.Name == plantName);
                    plant.Rarity = rarity;
                }
            }

            string line = Console.ReadLine();

            while (line != "Exhibition")
            {
                string[] parts = line.Split(new char[] { ' ', ':', '-' }, StringSplitOptions.RemoveEmptyEntries);
                string command = parts[0];
                string plantName = parts[1];

                Plant currPlant = plants.FirstOrDefault(x => x.Name == plantName);

                if (currPlant == null)
                {
                    command = "error";
                }
                    switch (command)
                    {
                        case "Rate":
                            //•	Rate: { plant} - { rating} – add the given rating to the plant(store all ratings)
                            int rating = int.Parse(parts[2]);
                            currPlant.Ratings.Add(rating);
                            break;
                        case "Update":
                            //•	Update: { plant}- { new_rarity} – update the rarity of the plant with the new one
                            int newRarity = int.Parse(parts[2]);
                            currPlant.Rarity = newRarity;
                            break;
                        case "Reset":
                            //•	Reset: { plant} – remove all the ratings of the given plant
                            currPlant.Ratings.Clear();
                            break;
                        default:
                            Console.WriteLine("error");
                            break;
                    }

                line = Console.ReadLine();
            }

            Console.WriteLine("Plants for the exhibition:");
            foreach (Plant plant in plants.OrderByDescending(x => x.Rarity).ThenByDescending(x => x.AverageRating()))
            {
                Console.WriteLine(plant);
            }
        }
    }

    internal class Plant
    {
        public string Name { get; set; }
        public int Rarity { get; set; }
        public List<int> Ratings { get; set; }

        public Plant(string name, int rarity)
        {
            Name = name;
            Rarity = rarity;
            Ratings = new List<int>();
        }

        public double AverageRating()
        {
            if (Ratings.Count == 0)
            {
                return 0;
            }

            return Ratings.Average();
        }
        public override string ToString()
        {
            return $"- {Name}; Rarity: {Rarity}; Rating: {AverageRating():F2}";
        }
    }
}
