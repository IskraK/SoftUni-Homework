using System;
using System.Collections.Generic;
using System.Linq;

namespace _3.LegendaryFarming
{
    class Program
    {
        static void Main(string[] args)
        {
            //•	Shadowmourne - requires 250 Shards;
            //•	Valanyr - requires 250 Fragments;
            //•	Dragonwrath - requires 250 Motes;
            //Shards, Fragments and Motes are the key materials and everything else is junk.You will be given lines of input, in the format: 
            //2 motes 3 ores 15 stones

            Dictionary<string, string> keyMaterials = new Dictionary<string, string>()
            {
                {"shards","Shadowmourne" },
                {"fragments","Valanyr" },
                {"motes","Dragonwrath" }
            };

            string legendaryItem = "";

            SortedDictionary<string, int> items = new SortedDictionary<string, int>()
            {
                {"shards",0 },
                {"fragments",0 },
                {"motes",0 }
            };

            while (legendaryItem == "")
            {
                string[] materialsAndQuantity = Console.ReadLine().Split();

                for (int i = 0; i < materialsAndQuantity.Length; i+=2)
                {
                    string currMaterial = materialsAndQuantity[i+1].ToLower();
                    int currQuantity = int.Parse(materialsAndQuantity[i]);
                    if (items.ContainsKey(currMaterial))
                    {
                        items[currMaterial] += currQuantity;
                    }
                    else
                    {
                        items.Add(currMaterial, currQuantity);
                    }

                    if (keyMaterials.ContainsKey(currMaterial))
                    {
                        if (items[currMaterial] >= 250)
                        {
                            legendaryItem = keyMaterials[currMaterial];
                            items[currMaterial] -= 250;
                            break;
                        }
                    }
                }
            }

            Console.WriteLine($"{legendaryItem} obtained!");
            foreach (var item in items.Where(m => keyMaterials.ContainsKey(m.Key)).OrderByDescending(q => q.Value))
            {
                Console.WriteLine($"{item.Key}: {item.Value}");
            }

            foreach (var item in items.Where(m => keyMaterials.ContainsKey(m.Key) == false))
            {
                Console.WriteLine($"{item.Key}: {item.Value}");
            }
        }
    }
}
