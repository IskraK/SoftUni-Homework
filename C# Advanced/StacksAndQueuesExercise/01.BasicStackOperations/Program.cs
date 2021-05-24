using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.BasicStackOperations
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] inputLine = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int numberElementsToPush = inputLine[0];
            int numberElementsToPop = inputLine[1];
            int stackElement = inputLine[2];

            int[] input = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Stack<int> numbers = new Stack<int>(input);

            for (int i = 0; i < numberElementsToPop; i++)
            {
                numbers.Pop();
            }

            if (numbers.Contains(stackElement))
            {
                Console.WriteLine("true");
            }
            else
            {
                if (numbers.Count != 0)
                {
                    Console.WriteLine(numbers.Min());
                }
                else
                {
                    Console.WriteLine("0");
                }
            }
        }
    }
}
