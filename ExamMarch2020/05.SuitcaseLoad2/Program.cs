using System;

namespace _05.SuitcaseLoad2
{
    class Program
    {
        static void Main(string[] args)
        {
            double capacity = double.Parse(Console.ReadLine());

            int counter = 0;

            while (true)
            {
                string input = Console.ReadLine();
                if (input == "End")
                {
                    Console.WriteLine("Congratulations! All suitcases are loaded!");
                    Console.WriteLine($"Statistic: {counter} suitcases loaded.");
                    break;
                }

                double suitcases = double.Parse(input);
                counter++;
                if (counter % 3 == 0)
                {
                    suitcases *= 1.1;
                }
                capacity -= suitcases;
                if (capacity < 0)
                {
                    Console.WriteLine("No more space!");
                    Console.WriteLine($"Statistic: {counter - 1} suitcases loaded.");
                    break;
                }
            }
        }
    }
}
