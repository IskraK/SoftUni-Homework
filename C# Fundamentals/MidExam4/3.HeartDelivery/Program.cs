using System;
using System.Linq;

namespace _3.HeartDelivery
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] neighborhood = Console.ReadLine()
                .Split("@", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            string input = Console.ReadLine();
            int idx = 0;
            while (input != "Love!")
            {
                string[] command = input.Split();
                int jump = int.Parse(command[1]);

                 idx+= jump;

                if (idx > neighborhood.Length-1)
                {
                    idx = 0;
                }

                neighborhood[idx] -= 2;

                if (neighborhood[idx] == 0)
                {
                    Console.WriteLine($"Place {idx} has Valentine's day.");
                }
                else if (neighborhood[idx] < 0)
                {
                    Console.WriteLine($"Place {idx} already had Valentine's day.");
                }

                input = Console.ReadLine();
            }

            Console.WriteLine($"Cupid's last position was {idx}.");

            int counter = 0;
            for (int i = 0; i < neighborhood.Length; i++)
            {
                if (neighborhood[i] > 0)
                {
                    counter++;
                }
            }

            if (counter >= 1)
            {
                Console.WriteLine($"Cupid has failed {counter} places.");
            }
            else
            {
                Console.WriteLine("Mission was successful.");
            }
        }
    }
}
