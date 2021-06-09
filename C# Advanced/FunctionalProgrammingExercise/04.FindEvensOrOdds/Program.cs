using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.FindEvensOrOdds
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] bounds = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int lowerBound = bounds[0];
            int upperBound = bounds[1];

            string filter = Console.ReadLine();

            List<int> numbers = new List<int>();

            for (int i = lowerBound; i <= upperBound; i++)
            {
                numbers.Add(i);
            }

            switch (filter)
            {
                case "even":
                    numbers = numbers.Where(n => n % 2 == 0).ToList();
                    break;
                case "odd":
                    numbers = numbers.Where(n => n % 2 != 0).ToList();
                    break;
                default:
                    break;
            }

            Console.WriteLine(string.Join(' ',numbers));
        }
    }
}
