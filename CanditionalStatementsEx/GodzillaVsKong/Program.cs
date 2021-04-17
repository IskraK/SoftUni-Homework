using System;

namespace GodzillaVsKong
{
    class Program
    {
        static void Main(string[] args)
        {
            //Ред 1.Бюджет за филма – реално число в интервала[1.00 … 1000000.00]
            //Ред 2.Брой на статистите – цяло число в интервала[1 … 500]
            //Ред 3.Цена за облекло на един статист – реално число в интервала[1.00 … 1000.00]
            double budget = double.Parse(Console.ReadLine());
            int numberOfStatists = int.Parse(Console.ReadLine());
            double clothesForstatist = double.Parse(Console.ReadLine());
            double decor = budget * 0.1;
            double priceForClothes = numberOfStatists * clothesForstatist;
            if (numberOfStatists > 150)
            {
                priceForClothes = priceForClothes * 0.9;
            }
            double totalMoney = decor + priceForClothes;
            if (totalMoney <= budget)
            {
                double moneyLeft = budget-totalMoney;
                Console.WriteLine("Action!");
                Console.WriteLine($"Wingard starts filming with {moneyLeft:f2} leva left.");
            }
            else
            {
                double moneyNeeded = totalMoney-budget;
                Console.WriteLine("Not enough money!");
                Console.WriteLine($"Wingard needs {moneyNeeded:f2} leva more.");
            }
        }
    }
}
