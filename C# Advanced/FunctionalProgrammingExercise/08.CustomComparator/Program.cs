using System;
using System.Collections.Generic;
using System.Linq;

namespace _08.CustomComparator
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Func<int, bool> findEvenNumbers = n => n % 2 == 0;
            Func<int, bool> findOddNumbers = n => n % 2 != 0;

            int[] evenNumbers = numbers.Where(n => findEvenNumbers(n)).ToArray();
            int[] oddNumbers = numbers.Where(n => findOddNumbers(n)).ToArray();
            Array.Sort(evenNumbers);
            Array.Sort(oddNumbers);

            List<int> sortedNumbers = new List<int>();

            foreach (var number in evenNumbers)
            {
                sortedNumbers.Add(number);
            }

            foreach (var number in oddNumbers)
            {
                sortedNumbers.Add(number);
            }

            Console.WriteLine(string.Join(' ',sortedNumbers));
        }
    }
}
