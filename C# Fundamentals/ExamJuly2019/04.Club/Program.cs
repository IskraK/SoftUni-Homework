using System;

namespace _04.Club
{
    class Program
    {
        static void Main(string[] args)
        {
            double target = double.Parse(Console.ReadLine());
            double priceCocteils = 0;
            double income = 0;
            double moneyLeft = 0;
            string nameCocteil = Console.ReadLine();
            while (nameCocteil != "Party!")
            {
            int numberCocteils = int.Parse(Console.ReadLine());
                priceCocteils = numberCocteils * (nameCocteil.Length);
                if (priceCocteils %2 != 0)
                {
                    priceCocteils *= 0.75;
                }
                income += priceCocteils;
                moneyLeft = Math.Abs(target - income);
                if (income >= target)
                {
                    Console.WriteLine("Target acquired.");
                    Console.WriteLine($"Club income - {income:f2} leva.");
                    break;
                }
                priceCocteils = 0;
                nameCocteil = Console.ReadLine();
            }
                if (nameCocteil == "Party!")
                {
                    Console.WriteLine($"We need {moneyLeft:f2} leva more.");
                    Console.WriteLine($"Club income - {income:f2} leva.");
                }
        }
    }
}
