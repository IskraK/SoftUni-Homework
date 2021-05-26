using System;
using System.Linq;
using System.Numerics;

namespace _1.SinoTheWalker3var
{
    class Program
    {
        static void Main(string[] args)
        {
            BigInteger[] input = Console.ReadLine().Split(':').Select(BigInteger.Parse).ToArray();

            BigInteger hours = input[0];
            BigInteger minutes = input[1];
            BigInteger seconds = input[2];

            BigInteger totalSeconds = (hours * 60 * 60) + (minutes * 60) + seconds;

            BigInteger steps = BigInteger.Parse(Console.ReadLine());
            BigInteger secondsPerStep = BigInteger.Parse(Console.ReadLine());

            totalSeconds += steps * secondsPerStep;

            string output = $"Time Arrival: {totalSeconds / 60 / 60:D2}:{totalSeconds / 60 % 60:D2}:{totalSeconds % 60:D2}";

            if (totalSeconds / 60 / 60 > 23)
            {
                output = $"Time Arrival: {totalSeconds / 60 / 60 - ((totalSeconds / 60 / 60 / 24) * 24):D2}:{totalSeconds / 60 % 60:D2}:{totalSeconds % 60:D2}";
            }

            Console.WriteLine(output);
        }
    }
}
