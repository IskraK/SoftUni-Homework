using System;
using System.Collections.Generic;
using System.Linq;

namespace _12.CupsAndBottles
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] cups = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int[] bottles = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            Queue<int> queueCups = new Queue<int>(cups);
            Stack<int> stackBottles = new Stack<int>(bottles);
            int wastedWater = 0;
            int deficit = 0;

            while (queueCups.Count > 0 && stackBottles.Count > 0)
            {
                int water = stackBottles.Pop();
                if (queueCups.Peek() + deficit <= water)
                {
                    wastedWater += water - queueCups.Dequeue() - deficit;
                    deficit = 0;
                }
                else
                {
                    deficit -= water;
                }
            }

            if (queueCups.Count == 0)
            {
                Console.WriteLine($"Bottles: {string.Join(' ',stackBottles)}");
            }
            else
            {
                Console.WriteLine($"Cups: {string.Join(' ',queueCups)}");
            }

            Console.WriteLine($"Wasted litters of water: {wastedWater}");
        }
    }
}
