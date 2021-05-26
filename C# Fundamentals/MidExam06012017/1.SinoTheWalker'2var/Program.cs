using System;
using System.Linq;

namespace _1.SinoTheWalker_2var
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine().Split(':').Select(int.Parse).ToArray();
            int steps = int.Parse(Console.ReadLine());
            int timeInsecondsPerstep = int.Parse(Console.ReadLine());

            int hours = input[0];
            int minutes = input[1];
            int seconds = input[2];

            int allSeconds = steps * timeInsecondsPerstep;

            seconds += allSeconds;

            while (seconds >= 60)
            {
                minutes++;
                seconds -= 60;

                if (minutes >= 60)
                {
                    hours++;
                    minutes = 0;

                    if (hours >= 24)
                    {
                        hours -= 24;
                    }
                }
            }

            Console.WriteLine($"Time Arrival: {hours:d2}:{minutes:d2}:{seconds:d2}");
        }
    }
}
