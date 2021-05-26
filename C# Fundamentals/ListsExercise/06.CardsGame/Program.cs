using System;
using System.Collections.Generic;
using System.Linq;

namespace _06.CardsGame
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> first = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            List<int> second = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            for (int i = 0; i < Math.Max(first.Count,second.Count); i++)
            {
                if (first[i] == second[i])
                {
                    first.RemoveAt(i);
                    second.RemoveAt(i);
                }
                else if (first[i] > second[i])
                {
                    first.Add(first[i]);
                    first.Add(second[i]);
                    first.RemoveAt(i);
                    second.RemoveAt(i);
                }
                else if (second[i] > first[i])
                {
                    second.Add(second[i]);
                    second.Add(first[i]);
                    second.RemoveAt(i);
                    first.RemoveAt(i);
                }

                i--;

                if (first.Count == 0)
                {
                    Console.WriteLine($"Second player wins! Sum: {second.Sum()}");
                    break;
                }
                else if (second.Count == 0)
                {
                    Console.WriteLine($"First player wins! Sum: {first.Sum()}");
                    break;
                }
            }
        }
    }
}
