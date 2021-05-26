using System;

namespace FruitMarket
{
    class Program
    {
        static void Main(string[] args)
        {
            //1.Цена на ягодите в лева – реално число в интервала[0.00 … 10000.00]
            //2.Количество на бананите в килограми – реално число в интервала[0.00 … 1 0000.00]
            //3.Количество на портокалите в килограми – реално число в интервала[0.00 … 10000.00]
            //4.Количество на малините в килограми – реално число в интервала[0.00 … 10000.00]
            //5.Количество на ягодите в килограми – реално число в интервала[0.00 … 10000.00]
            double strawberryPriceKg = double.Parse(Console.ReadLine());
            double kgBananas = double.Parse(Console.ReadLine());
            double kgOranges = double.Parse(Console.ReadLine());
            double kgRaspberry = double.Parse(Console.ReadLine());
            double kgStrawberry = double.Parse(Console.ReadLine());

            //•	цената на малините е на половина по - ниска от тази на ягодите;
            //•	цената на портокалите е с 40 % по - ниска от цената на малините;
            //  •	цената на бананите е с 80 % по - ниска от цената на малините.
            double raspberryPriceKg = strawberryPriceKg / 2;
            double orangePriceKg = raspberryPriceKg * 0.6;
            double bananasPriceKg = raspberryPriceKg * 0.2;
            double priceStrawberry = kgStrawberry * strawberryPriceKg;
            double priceRaspberry = kgRaspberry * raspberryPriceKg;
            double priceOranges = kgOranges * orangePriceKg;
            double priceBananas = kgBananas * bananasPriceKg;
            double totalSum = priceStrawberry + priceRaspberry + priceOranges + priceBananas;
            Console.WriteLine($"{totalSum:f2}");
        }
    }
}
