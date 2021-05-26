using System;

namespace BirthdayParty
{
    class Program
    {
        static void Main(string[] args)
        {
            //Наем за залата – реално число в интервала[100.00..10000.00]
            double rentForHall = double.Parse(Console.ReadLine());
            //Торта  – цената ѝ е 20 % от наема на залата
            //Напитки – цената им е 45 % по - малко от тази на тортата
            //Аниматор – цената му е 1 / 3 от цената за наема на залата
            double priceForCake = rentForHall * 0.20;
            double priceFordrinks = priceForCake * 0.55;
            double priceForAnimator = rentForHall / 3;
            double totalPrice = rentForHall + priceForCake + priceFordrinks + priceForAnimator;
            Console.WriteLine(totalPrice);
        }
    }
}
