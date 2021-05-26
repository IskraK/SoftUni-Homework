using System;

namespace CharityCampaign
{
    class Program
    {
        static void Main(string[] args)
        {
            //1.Броят на дните, в които тече кампанията – цяло число в интервала[0 … 365]
            //2.Броят на сладкарите – цяло число в интервала[0 … 1000]
            //3.Броят на тортите – цяло число в интервала[0… 2000]
            //4.Броят на гофретите – цяло число в интервала[0 … 2000]
            //5.Броят на палачинките – цяло число в интервала[0 … 2000]
            int numberOfDays = int.Parse(Console.ReadLine());
            int numberOfCookers = int.Parse(Console.ReadLine());
            int numberOfCakes = int.Parse(Console.ReadLine());
            int numberOfWoffles = int.Parse(Console.ReadLine());
            int numberOfPancakes = int.Parse(Console.ReadLine());
            //•	Торта - 45 лв.
            //•	Гофрета - 5.80 лв.
            //•	Палачинка – 3.20 лв.
            const double priceForCake = 45;
            const double priceForWoffle = 5.80;
            const double priceForPancake = 3.20;
            double cakeTotalPrice = numberOfCakes * priceForCake;
            double woffleTotalPrice = numberOfWoffles * priceForWoffle;
            double pancakeTotalprice = numberOfPancakes * priceForPancake;
            double totalSumForDay = (cakeTotalPrice + woffleTotalPrice + pancakeTotalprice) * numberOfCookers;
            double totalSumForAllDays = totalSumForDay * numberOfDays;
            double finalSum = totalSumForAllDays - totalSumForAllDays / 8;
            Console.WriteLine(finalSum);
        }
    }
}
