using System;

namespace _05.SuitcasesLoad
{
    class Program
    {
        static void Main(string[] args)
        {
            double capacity = double.Parse(Console.ReadLine());
            int counter = 0;
            string suitcase = Console.ReadLine();
            while (suitcase != "End")
            {
                double volumeCase = double.Parse(suitcase);
                counter++;
                if (counter % 3 == 0)
                {
                    volumeCase *= 1.1;
                }
                capacity -= volumeCase;
                if (capacity < 0)
                {
                    Console.WriteLine("No more space!");
                    Console.WriteLine($"Statistic: {counter - 1} suitcases loaded.");
                    break;
                }
                suitcase = Console.ReadLine();
            }
            if (suitcase == "End")
            {
                Console.WriteLine("Congratulations! All suitcases are loaded!");
                Console.WriteLine($"Statistic: {counter} suitcases loaded.");
            }
        }
    }
}
