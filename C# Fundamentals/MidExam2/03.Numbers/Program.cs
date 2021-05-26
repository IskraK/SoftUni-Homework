using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();
            double sumNumbers = 0;

            for (int i = 0; i < numbers.Count; i++)
            {
                sumNumbers += numbers[i];
            }

            double avgNumbers = (double)sumNumbers / numbers.Count;
            numbers.Sort();
            numbers.Reverse();

            List<int> maxFiveNumbers = new List<int>(5);
            bool isExist = false;

            for (int i = 0; i < 5; i++)
            {
                if (numbers.Count == 1)
                {
                    avgNumbers = numbers[0];
                    break;
                }
                if (numbers[i] > avgNumbers)
                {
                    maxFiveNumbers.Add(numbers[i]);
                    isExist = true;
                }
            }

            if (isExist)
            {
                Console.WriteLine(string.Join(" ",maxFiveNumbers));
            }
            else
            {
                Console.WriteLine("No");
            }
        }
    }
}
