using System;
using System.Collections.Generic;
using System.Linq;

namespace _3.PlantDiscovery
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Dictionary<string, Dictionary<int,double>> plants = new Dictionary<string, Dictionary<int,double>>();
            for (int i = 0; i < n; i++)
            {
                string[] data = Console.ReadLine()
                    .Split("<->", StringSplitOptions.RemoveEmptyEntries);
                string plantName = data[0];
                int rarity = int.Parse(data[1]);
                if (!plants.ContainsKey(plantName))
                {
                    plants.Add(plantName, new Dictionary<int, double>());
                    plants[plantName][0]=rarity;
                    plants[plantName][1] = 0;
                }
                else
                {
                    if (plants[plantName][0] != rarity)
                    {
                        plants[plantName][0] = rarity;
                    }
                }
            }

            string line = Console.ReadLine();

            while (line != "Exhibition")
            {
                string[] parts = line.Split(new char[] { ' ', ':', '-' }, StringSplitOptions.RemoveEmptyEntries);
                string command = parts[0];
                string plantName = parts[1];

                switch (command)
                {
                    case "Rate":
                        //•	Rate: { plant} - { rating} – add the given rating to the plant(store all ratings)
                        int rating = int.Parse(parts[2]);
                        if (plants.ContainsKey(plantName))
                        {
                            if (plants[plantName][1] == 0)
                            {
                                plants[plantName][1] = rating;
                            }
                            else
                            {
                            plants[plantName][1] += rating;
                            plants[plantName][1] = plants[plantName][1]/2;
                            }
                        }
                        else
                        {
                            Console.WriteLine("error");
                        }
                        break;
                    case "Update":
                        //•	Update: { plant}- { new_rarity} – update the rarity of the plant with the new one
                        int newRarity = int.Parse(parts[2]);
                        if (plants.ContainsKey(plantName))
                        {
                            plants[plantName][0] = newRarity;
                        }
                        else
                        {
                            Console.WriteLine("error");
                        }
                        break;
                    case "Reset":
                        //•	Reset: { plant} – remove all the ratings of the given plant
                        if (plants.ContainsKey(plantName))
                        {
                            if (plants[plantName][1] != 0)
                            {
                            plants[plantName][1] = 0;
                            }
                        }
                        else
                        {
                            Console.WriteLine("error");
                        }
                        break;
                    default:
                        Console.WriteLine("error");
                        break;
                }

                line = Console.ReadLine();
            }

            //Plants for the exhibition:
            //- { plant_name}; Rarity: { rarity}; Rating: { average_rating formatted to the 2nd digit}
            Console.WriteLine("Plants for the exhibition:");
            foreach (var plant in plants.OrderByDescending(x => x.Value[0]).ThenByDescending(x => x.Value[1]))
            {
                Console.WriteLine($"- {plant.Key}; Rarity: {plant.Value[0]}; Rating: {plant.Value[1]:F2}");
            }
        }
    }
}
