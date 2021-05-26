using System;

namespace ReportSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            int requiredMoney = int.Parse(Console.ReadLine());
            string input = Console.ReadLine();
            int counter = 0;
            int cashSum = 0;
            int cardSum = 0;
            int totalSum = 0;
            int cashCounter = 0;
            int cardCounter = 0;
            while (totalSum < requiredMoney)
            {
                counter++;
                if (input == "End")
                {
                    Console.WriteLine("Failed to collect required money for charity.");
                    break;
                }
                int money = int.Parse(input);
                if (counter % 2 != 0 && money <= 100)
                {
                    Console.WriteLine("Product sold!");
                    cashSum += money;
                    cashCounter++;
                }
                else if (counter % 2 == 0 && money >= 10)
                {
                    Console.WriteLine("Product sold!");
                    cardSum += money;
                    cardCounter++;
                }
                else
                {
                    Console.WriteLine("Error in transaction!");
                }
                totalSum = cashSum + cardSum;
                input = Console.ReadLine();
            }
            if (totalSum >= requiredMoney)
            {
                Console.WriteLine($"Average CS: {1.0*cashSum/cashCounter:f2}");
                Console.WriteLine($"Average CC: {1.0*cardSum/cardCounter:f2}");
            }
        }
    }
}
