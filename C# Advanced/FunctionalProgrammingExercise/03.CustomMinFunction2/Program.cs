using System;
using System.Linq;

namespace _03.CustomMinFunction2
{
    class Program
    {
        static void Main(string[] args)
        {
            Func<int[], int> minValue = n => n.Min();

            int[] numbers = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int minNumber = minValue(numbers);
            Console.WriteLine(minNumber);
        }
    }
}
