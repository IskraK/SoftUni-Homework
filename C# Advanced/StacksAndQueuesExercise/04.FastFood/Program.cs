using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.FastFood
{
    class Program
    {
        static void Main(string[] args)
        {
            int food = int.Parse(Console.ReadLine());
            int[] input = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Queue<int> orders = new Queue<int>(input);

            Console.WriteLine(orders.Max());

            for (int i = 0; i < orders.Count; i++)
            {
                if (food >= orders.Peek())
                {
                    food -= orders.Dequeue();
                    i--;
                }
                else
                {
                    Console.Write("Orders left: ");
                    Console.WriteLine(string.Join(" ",orders));
                    break;
                }
            }

            if (orders.Count == 0)
            {
                Console.WriteLine("Orders complete");
            }
        }
    }
}
