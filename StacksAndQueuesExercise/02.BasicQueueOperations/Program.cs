using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.BasicQueueOperations
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] inputLine = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int numberElementsToEnqueue = inputLine[0];
            int numberElementsToDequeue = inputLine[1];
            int queueElement = inputLine[2];

            int[] input = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Queue<int> numbers = new Queue<int>(input);

            for (int i = 0; i < numberElementsToDequeue; i++)
            {
                numbers.Dequeue();
            }

            if (numbers.Contains(queueElement))
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
