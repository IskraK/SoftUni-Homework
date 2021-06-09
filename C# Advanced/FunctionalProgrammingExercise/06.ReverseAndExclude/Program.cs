using System;
using System.Linq;

namespace _06.ReverseAndExclude
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int divider = int.Parse(Console.ReadLine());

            //Predicate<int> filter = n => n % divider != 0;
            //numbers = numbers.Reverse().Where(x => filter(x)).ToArray();

            numbers = numbers.Reverse().Where(n => n % divider != 0).ToArray();

            Console.WriteLine(string.Join(' ',numbers));
        }
    }
}
