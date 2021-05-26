using System;
using System.Collections.Generic;

namespace _2.AMinerTask
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            Dictionary<string, int> resources = new Dictionary<string, int>();

            while (input != "stop")
            {
                string currResource = input;
                int currQuantity = int.Parse(Console.ReadLine());
                if (resources.ContainsKey(currResource))
                {
                    resources[currResource] += currQuantity;
                }
                else
                {
                    resources.Add(currResource, currQuantity);
                }

                input = Console.ReadLine();
            }

            foreach (var item in resources)
            {
                Console.WriteLine($"{item.Key} -> {item.Value}");
            }
        }
    }
}
