using System;
using System.Linq;

namespace _05.AppliedArithmetics2
{
    class Program
    {
        static void Main(string[] args)
        {
            Func<int, int, int> add = (a, b) => a + b;
            Func<int, int, int> multiply = (a, b) => a * b;
            Func<int, int, int> subtract = (a, b) => a - b;
            Action<int[]> print = n => Console.WriteLine(string.Join(' ', n));

            int[] numbers = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            string command = Console.ReadLine();

            while (command != "end")
            {
                switch (command)
                {
                    case "add":
                        for (int i = 0; i < numbers.Length; i++)
                        {
                            numbers[i] = add(numbers[i], 1);
                        }
                        break;
                    case "multiply":
                        for (int i = 0; i < numbers.Length; i++)
                        {
                            numbers[i] = multiply(numbers[i], 2);
                        }
                        break;
                    case "subtract":
                        for (int i = 0; i < numbers.Length; i++)
                        {
                            numbers[i] = subtract(numbers[i], 1);
                        }
                        break;
                    case "print":
                        print(numbers);
                        break;
                    default:
                        break;
                }

                command = Console.ReadLine();
            }
        }
    }
}
