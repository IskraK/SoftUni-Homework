using System;
using System.Collections.Generic;
using System.Linq;

namespace _3.LegendaryFarming2var
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> LegendaryItem = new Dictionary<string, int>()
            {
                {"shards",0 },
                {"fragments",0 },
                {"motes",0 }
            };

            SortedDictionary<string, int> junkItems = new SortedDictionary<string, int>();

            string winnerItem = string.Empty;
            bool isRunning = true;

            while (isRunning)
            {
                string[] parts = Console.ReadLine().Split();

                for (int i = 0; i < parts.Length; i += 2)
                {
                    int quantity = int.Parse(parts[i]);
                    string item = parts[i + 1].ToLower();

                    if (LegendaryItem.ContainsKey(item))
                    {
                        LegendaryItem[item] += quantity;
                        if (LegendaryItem[item] >= 250)
                        {
                            LegendaryItem[item] -= 250;
                            winnerItem = item;
                            isRunning = false;
                            break;
                        }
                    }
                    else
                    {
                        if (junkItems.ContainsKey(item))
                        {
                            junkItems[item] += quantity;
                        }
                        else
                        {
                            junkItems.Add(item, quantity);
                        }
                    }

                }
            }

            if (winnerItem == "shards")
            {
                Console.WriteLine("Shadowmourne obtained!");
            }
            else if (winnerItem == "fragments")
            {
                Console.WriteLine("Valanyr obtained!");
            }
            else
            {
                Console.WriteLine("Dragonwrath obtained!");
            }

            Dictionary<string, int> sortedLegendaryItems = LegendaryItem
                .OrderByDescending(i => i.Value)
                .ThenBy(i => i.Key)
                .ToDictionary(x => x.Key, x => x.Value);

            foreach (var kvp in sortedLegendaryItems)
            {
                Console.WriteLine($"{kvp.Key}: {kvp.Value}");
            }

            foreach (var kvp in junkItems)
            {
                Console.WriteLine($"{kvp.Key}: {kvp.Value}");
            }
        }
    }
}
