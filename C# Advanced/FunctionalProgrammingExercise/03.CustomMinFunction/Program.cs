using System;
using System.Linq;

namespace _03.CustomMinFunction
{
    class Program
    {
        static void Main(string[] args)
        {
            Func<int[], int> minValue = FindMinValue;
            int[] numbers = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Console.WriteLine(minValue(numbers));  
        }

        private static int FindMinValue(int[] numbers)
        {
            return numbers.Min();
        }
    }
}
