using System;

namespace _02.ANDProcessors
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberProcessors = int.Parse(Console.ReadLine());
            int numberWorkers = int.Parse(Console.ReadLine());
            int days = int.Parse(Console.ReadLine());
            double madeProcessors = Math.Floor(days * 8 * numberWorkers *1.0/ 3);
                double profit = (madeProcessors - numberProcessors) * 110.10;
            if (madeProcessors >= numberProcessors)
            {
                Console.WriteLine($"Profit: -> {profit:f2} BGN");
            }
            else
            {
                Console.WriteLine($"Losses: -> {Math.Abs(profit):f2} BGN");
            }
        }
    }
}
