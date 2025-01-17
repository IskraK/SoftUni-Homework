﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.FastFood2var
{
    class Program
    {
        static void Main(string[] args)
        {
            int food = int.Parse(Console.ReadLine());
            Queue<int> orders = new Queue<int>(Console.ReadLine().Split().Select(int.Parse));

            Console.WriteLine(orders.Max());

            while (orders.Count > 0)
            {
                int currOrder = orders.Peek();
                if (food < currOrder)
                {
                    break;
                }
                else
                {
                    food -= orders.Dequeue();
                }
            }

            if (orders.Count > 0)
            {
                Console.WriteLine("Orders left: " + string.Join(" ", orders));
            }
            else
            {
                Console.WriteLine("Orders complete");
            }
        }
    }
}
