using System;
using System.Linq;

namespace _05.AppliedArithmetics
{
    class Program
    {
        public delegate int Calculator(int a, int b);
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Calculator add = (a, b) => a + b;
            Calculator multiply = (a, b) => a * b;
            Calculator subtract = (a, b) => a - b;

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
                        Console.WriteLine(string.Join(' ',numbers));
                        break;
                    default:
                        break;
                }

                command = Console.ReadLine();
            }
        }

        private static int Calculate(int a, int b, Calculator operation)
        {
            return operation(a, b);
        }
    }
}
