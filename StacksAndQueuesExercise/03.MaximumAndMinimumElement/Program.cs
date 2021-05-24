using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.MaximumAndMinimumElement
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack<int> numbers = new Stack<int>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();

                if (input.Length == 1)
                {
                    if (numbers.Count != 0)
                    {
                        switch (input)
                        {
                            case "2":
                                numbers.Pop();
                                break;
                            case "3":
                                Console.WriteLine(numbers.Max());
                                break;
                            case "4":
                                Console.WriteLine(numbers.Min());
                                break;
                            default:
                                break;
                        }
                    }
                }
                else
                {
                    int[] command = input
                        .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                        .Select(int.Parse)
                        .ToArray();

                    int number = command[1];
                    numbers.Push(number);

                }
            }

            Console.WriteLine(string.Join(", ", numbers));
        }
    }
}
