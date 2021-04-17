using System;
using System.Linq;

namespace _05.SumEvenNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            int evenSum = 0;

            for (int i = 0; i < arr.Length; i++)
            {
                int number = arr[i];
                if (number % 2 == 0)
                {
                    evenSum += number;
                }
            }

            Console.WriteLine(evenSum);
        }
    }
}
