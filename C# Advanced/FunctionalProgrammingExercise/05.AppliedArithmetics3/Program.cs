using System;
using System.Linq;

namespace _05.AppliedArithmetics3
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            Action<int[]> printer = n => Console.WriteLine(string.Join(' ',n));

            string command = Console.ReadLine();

            while (command != "end")
            {
                switch (command)
                {
                    case "add":
                        numbers=ForEach(numbers,n => ++n);
                        break;
                    case "multiply":
                        numbers = ForEach(numbers, n => n*2);
                        break;
                    case "subtract":
                        numbers = ForEach(numbers, n => --n);
                        break;
                    case "print":
                        printer(numbers);
                        break;
                    default:
                        break;
                }

                command = Console.ReadLine();
            }
        }

        private static int[] ForEach(int[] numbers, Func<int, int> func) => numbers.Select(numbers => func(numbers)).ToArray();
        
    }
}
