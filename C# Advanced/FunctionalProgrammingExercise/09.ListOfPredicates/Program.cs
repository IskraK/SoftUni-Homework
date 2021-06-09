using System;
using System.Linq;

namespace _09.ListOfPredicates
{
    class Program
    {
        static void Main(string[] args)
        {
            int endOfRange = int.Parse(Console.ReadLine());
            int[] dividers = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int[] numbers = new int[endOfRange];

            for (int i = 0; i < endOfRange; i++)
            {
                numbers[i] = i+1;
            }

            Func<int[], int, bool> filter = (allDividers, number) =>
               {
                   bool divisible = true;

                   for (int i = 0; i < allDividers.Length; i++)
                   {
                       if (number % allDividers[i] != 0)
                       {
                           divisible = false;
                           break;
                       }
                   }
                   return divisible;
               };

            numbers = numbers.Where(num => filter(dividers, num)).ToArray();

            Console.WriteLine(string.Join(' ',numbers));
        }
    }
}
