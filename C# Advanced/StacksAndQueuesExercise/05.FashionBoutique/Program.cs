using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.FashionBoutique
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Stack<int> clothes = new Stack<int>(input);

            int rackCapacity = int.Parse(Console.ReadLine());
            int rackCapacityOrigin = rackCapacity;

            int numberOfRacks = 1;

            while (clothes.Count > 0)
            {
                if (rackCapacity >= clothes.Peek())
                {
                    rackCapacity -= clothes.Pop();
                }
                else
                {
                    rackCapacity = rackCapacityOrigin;
                    numberOfRacks++;
                }
            }

            Console.WriteLine(numberOfRacks);
        }
    }
}
