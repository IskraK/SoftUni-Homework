using System;
using System.Collections.Generic;

namespace _06.Wardrobe
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, int>> wardrobe = new Dictionary<string, Dictionary<string, int>>();
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                //Blue->dress,jeans,hat
                string[] inputLine = Console.ReadLine()
                    .Split(" -> ", StringSplitOptions.RemoveEmptyEntries);
                string color = inputLine[0];
                string[] clothes = inputLine[1].Split(',', StringSplitOptions.RemoveEmptyEntries);

                if (wardrobe.ContainsKey(color) == false)
                {
                    wardrobe.Add(color, new Dictionary<string, int>());
                }

                for (int j = 0; j < clothes.Length; j++)
                {
                    string currClothes = clothes[j];
                    if (wardrobe[color].ContainsKey(currClothes) == false)
                    {
                        wardrobe[color].Add(currClothes, 0);
                    }
                    wardrobe[color][currClothes]++;
                }
            }

            string[] wanted = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);
            string wantedColor = wanted[0];
            string wantedClothes = wanted[1];

            foreach (var item in wardrobe)
            {
                Console.WriteLine($"{item.Key} clothes:");

                foreach (var clothing in item.Value)
                {
                    if (item.Key == wantedColor && clothing.Key == wantedClothes)
                    {
                        Console.WriteLine($"* {clothing.Key} - {clothing.Value} (found!)");
                    }
                    else
                    {
                        Console.WriteLine($"* {clothing.Key} - {clothing.Value}");
                    }
                }
            }
        }
    }
}
