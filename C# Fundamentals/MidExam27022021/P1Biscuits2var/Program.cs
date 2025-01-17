﻿using System;

namespace P1Biscuits2var
{
    class Program
    {
        static void Main(string[] args)
        {
            int biscuitsPerDay = int.Parse(Console.ReadLine());
            int workers = int.Parse(Console.ReadLine());
            int otherFactory = int.Parse(Console.ReadLine());

            int sum = 0;

            for (int i = 1; i <= 30; i++)
            {
                if (i % 3 == 0)
                {
                    sum += (int)Math.Floor(biscuitsPerDay * workers * 0.75);
                    continue;
                }

                sum += biscuitsPerDay * workers;
            }

            Console.WriteLine($"You have produced {sum} biscuits for the past month.");

            double difference = Math.Abs(sum - otherFactory);
            double percentage = difference / otherFactory * 100;

            if (sum > otherFactory)
            {
                Console.WriteLine($"You produce {percentage:f2} percent more biscuits.");
            }
            else
            {
                Console.WriteLine($"You produce {percentage:f2} percent less biscuits.");
            }
        }
    }
}
