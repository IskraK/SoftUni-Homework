using System;
using System.Linq;
using System.Numerics;

namespace _1.SinoTheWalker
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] leavingTime = Console.ReadLine()
                .Split(':')
                .Select(int.Parse)
                .ToArray();
            int numberSteps = int.Parse(Console.ReadLine());
            int secondsPerStep = int.Parse(Console.ReadLine());

            BigInteger secondsForAllSteps = numberSteps * secondsPerStep;
            int hours = leavingTime[0];
            int minutes = leavingTime[1];
            int seconds = leavingTime[2];
            BigInteger leavingTimeInSeconds = seconds + minutes * 60 + hours * 60 * 60;
            BigInteger arrivingTimeInSeconds = leavingTimeInSeconds + secondsForAllSteps;
            int arrivingHours = (int)arrivingTimeInSeconds / 3600;
            int arrivingMinutes = (int)(arrivingTimeInSeconds % 3600) / 60;
            int arrivingSeconds = (int)arrivingTimeInSeconds% 60;

            if (arrivingHours > 23)
            {
                arrivingHours -= 24;
            }

            if (arrivingMinutes >= 60)
            {
                arrivingMinutes -= 60;
            }

            if (arrivingSeconds >= 60)
            {
                arrivingSeconds -= 60;
            }

            Console.WriteLine($"Time Arrival: {arrivingHours:D2}:{arrivingMinutes:D2}:{arrivingSeconds:D2}");

        }
    }
}
