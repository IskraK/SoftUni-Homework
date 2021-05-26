using System;

namespace _02.FamilyTrip
{
    class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            int nights = int.Parse(Console.ReadLine());
            double priceForNight = double.Parse(Console.ReadLine());
            int pMoreCharge = int.Parse(Console.ReadLine());
            double totalPriceForNigfts = nights * priceForNight;
            if (nights > 7)
            {
                totalPriceForNigfts *= 0.95;
            }
            double totalPrice = totalPriceForNigfts + 1.0 * pMoreCharge * budget/100;
            double moneyLeft = Math.Abs(budget - totalPrice);
            if (budget >= totalPrice)
            {
                Console.WriteLine($"Ivanovi will be left with {moneyLeft:f2} leva after vacation.");
            }
            else
            {
                Console.WriteLine($"{moneyLeft:f2} leva needed.");
            }
        }
    }
}
