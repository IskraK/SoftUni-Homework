using System;
using System.Collections.Generic;
using System.Linq;

namespace _3.Nikulden_smeals
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<string>> likedMeals = new Dictionary<string, List<string>>();

            string line = Console.ReadLine();
            int unlikedMeals = 0;

            while (line != "Stop")
            {
                string[] parts = line.Split('-',StringSplitOptions.RemoveEmptyEntries);
                string command = parts[0];
                string guest = parts[1];
                string meal = parts[2];

                if (command == "Like")
                {
                    if (!likedMeals.ContainsKey(guest))
                    {
                        likedMeals.Add(guest, new List<string> { meal });
                    }
                    else
                    {
                        if (!likedMeals[guest].Contains(meal))
                        {
                            likedMeals[guest].Add(meal);
                        }
                    }
                }
                else if (command == "Unlike")
                {
                    if (!likedMeals.ContainsKey(guest))
                    {
                        Console.WriteLine($"{guest} is not at the party.");
                    }
                    else
                    {
                        if (!likedMeals[guest].Contains(meal))
                        {
                            Console.WriteLine($"{guest} doesn't have the {meal} in his/her collection.");
                        }
                        else
                        {
                            likedMeals[guest].Remove(meal);
                            unlikedMeals++;
                            Console.WriteLine($"{guest} doesn't like the {meal}.");
                        }
                    }
                }

                line = Console.ReadLine();
            }

            likedMeals = likedMeals
                .OrderByDescending(m => m.Value.Count)
                .ThenBy(n => n.Key)
                .ToDictionary(k => k.Key, v => v.Value);

            foreach (var item in likedMeals)
            {
                Console.WriteLine($"{item.Key}: "+string.Join(", ",item.Value));
            }

            Console.WriteLine($"Unliked meals: {unlikedMeals}");
        }
    }
}
