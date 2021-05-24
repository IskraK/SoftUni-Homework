using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.StackSum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Stack<int> stack = new Stack<int>(numbers);
            string input = Console.ReadLine().ToLower();

            while (input != "end")
            {
                string[] commandParts = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string command = commandParts[0];

                if (command == "add")
                {
                    stack.Push(int.Parse(commandParts[1]));
                    stack.Push(int.Parse(commandParts[2]));
                }
                else if (command == "remove")
                {
                    int numbersToRemove = int.Parse(commandParts[1]);

                    if (stack.Count >= numbersToRemove)
                    {
                        for (int i = 0; i < numbersToRemove; i++)
                        {
                            stack.Pop();
                        }
                    }
                }

                input = Console.ReadLine().ToLower();
            }

            Console.WriteLine($"Sum: {stack.Sum()}");
        }
    }
}
