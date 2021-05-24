using System;
using System.Collections.Generic;
using System.Linq;

namespace _12.CupsAndBottles2var
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] cups = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .Reverse()
                .ToArray();
            int[] bottles = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            Stack<int> stackCups = new Stack<int>(cups);
            Stack<int> stackBottles = new Stack<int>(bottles);
            int wastedWater = 0;

            while (stackCups.Count > 0 && stackBottles.Count > 0)
            {
                if (stackCups.Peek() <= stackBottles.Peek())
                {
                    wastedWater += stackBottles.Pop() - stackCups.Pop();
                }
                else
                {
                    int deficit = stackCups.Pop() - stackBottles.Pop();
                    stackCups.Push(deficit);
                }
            }

            if (stackCups.Count == 0)
            {
                Console.WriteLine($"Bottles: {string.Join(' ', stackBottles)}");
            }
            else
            {
                Console.WriteLine($"Cups: {string.Join(' ', stackCups)}");
            }

            Console.WriteLine($"Wasted litters of water: {wastedWater}");
        }
    }
}
