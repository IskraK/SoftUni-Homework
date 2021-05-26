using System;

namespace _01.MiningRig
{
    class Program
    {
        static void Main(string[] args)
        {
            int priceVideoCard = int.Parse(Console.ReadLine());
            int pricePrehod = int.Parse(Console.ReadLine());
            double priceEnergyPerCard = double.Parse(Console.ReadLine());
            double profitPerCard = double.Parse(Console.ReadLine());
            double totalPriceMaterials = priceVideoCard * 13 + pricePrehod * 13 + 1000;
            double profitForCards = (profitPerCard - priceEnergyPerCard)*13;
            double days = Math.Ceiling(totalPriceMaterials / profitForCards);
            Console.WriteLine($"{totalPriceMaterials}");
            Console.WriteLine($"{days}");
        }
    }
}
