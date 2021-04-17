using System;
using System.Linq;

namespace _02.CarRace
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] timeCarRacers = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            double timeLeftRacer = 0;
            double timeRightRacer = 0;

            for (int i = 0; i < timeCarRacers.Length / 2; i++)
            {
                if (timeCarRacers[i] == 0)
                {
                    timeLeftRacer -= timeLeftRacer * 0.2;
                }
                timeLeftRacer += timeCarRacers[i];
            }

            for (int i = timeCarRacers.Length - 1; i >= (timeCarRacers.Length +1)/ 2; i--)
            {
                if (timeCarRacers[i] == 0)
                {
                    timeRightRacer -= timeRightRacer * 0.2;
                }
                timeRightRacer += timeCarRacers[i];
            }

            if (timeLeftRacer < timeRightRacer)
            {
                Console.WriteLine($"The winner is left with total time: {timeLeftRacer}");
            }
            else
            {
                Console.WriteLine($"The winner is right with total time: {timeRightRacer}");
            }
        }
    }
}
