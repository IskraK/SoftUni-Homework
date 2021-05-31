using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.CountSameValuesInArray
{
    class Program
    {
        static void Main(string[] args)
        {
            double[] numbers = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(double.Parse)
                .ToArray();
            Dictionary<double, int> timesRepeat = new Dictionary<double, int>();

            for (int i = 0; i < numbers.Length; i++)
            {
                double currentNumber = numbers[i];
                if (!timesRepeat.ContainsKey(currentNumber))
                {
                    timesRepeat.Add(currentNumber, 0);
                }
                timesRepeat[currentNumber]++;
            }

            foreach (var item in timesRepeat)
            {
                Console.WriteLine($"{item.Key} - {item.Value} times");
            }
        }
    }
}
