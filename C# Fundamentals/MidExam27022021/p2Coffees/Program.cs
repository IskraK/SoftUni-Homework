using System;
using System.Collections.Generic;
using System.Linq;

namespace p2Coffees
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> coffees = Console.ReadLine()
                .Split()
                .ToList();

            int n = int.Parse(Console.ReadLine());


            for (int i = 0; i < n; i++)
            {
                string[] tokens = Console.ReadLine()
                    .Split(' ');

                string command = tokens[0];

                if (command == "Include")
                {
                    string coffee = tokens[1];

                    coffees.Add(coffee);
                }
                else if (command == "Remove")
                {
                    string position = tokens[1];
                    int count = int.Parse(tokens[2]);

                    if (count >= coffees.Count)
                    {
                        continue;
                    }

                    if (position == "first")
                    {
                        coffees.RemoveRange(0, count);
                    }
                    else
                    {
                        coffees.RemoveRange(coffees.Count - count, count);
                    }
                }
                else if (command == "Prefer")
                {
                    int firstIdx = int.Parse(tokens[1]);
                    int secondIdx = int.Parse(tokens[2]);

                    if (firstIdx >= 0 && firstIdx < coffees.Count && secondIdx >= 0 && secondIdx < coffees.Count)
                    {
                    string tempCoffee = coffees[firstIdx];
                    coffees[firstIdx] = coffees[secondIdx];
                    coffees[secondIdx] = tempCoffee;
                    }
                }
                else if (command == "Reverse")
                {
                    coffees.Reverse();
                }
            }

            Console.WriteLine($"Coffees: \n{string.Join(' ', coffees)}");
        }
    }
}
