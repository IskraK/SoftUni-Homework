using System;

namespace ToyShop
{
    class Program
    {
        static void Main(string[] args)
        {
            //• Пъзел - 2.60 лв.
            //•	Говореща кукла -3 лв.
            //•	Плюшено мече -4.10 лв.
            //•	Миньон - 8.20 лв.
            //•	Камионче - 2 лв.
            const double puzzlePrice = 2.60;
            const double talkingDollPrice = 3;
            const double teddyBearPrice = 4.10;
            const double minionPrice = 8.20;
            const double truckPrice = 2;
            // 1.Цена на екскурзията -реално число в интервала[1.00 … 10000.00]
            //2.Брой пъзели - цяло число в интервала[0… 1000]
            //3.Брой говорещи кукли -цяло число в интервала[0 … 1000]
            //4.Брой плюшени мечета -цяло число в интервала[0 … 1000]
            //5.Брой миньони - цяло число в интервала[0 … 1000]
            //6.Брой камиончета - цяло число в интервала[0 … 1000]
            double priceForExcursion = double.Parse(Console.ReadLine());
            int numberOfPuzzles = int.Parse(Console.ReadLine());
            
            int numberOfTalkingDolls = int.Parse(Console.ReadLine());
            int numberOfTeddyBears = int.Parse(Console.ReadLine());
            int numberOfMinions = int.Parse(Console.ReadLine());
            int numberOfTrucks = int.Parse(Console.ReadLine());
            double sum = numberOfPuzzles * puzzlePrice + numberOfTalkingDolls * talkingDollPrice + numberOfTeddyBears * teddyBearPrice + numberOfMinions * minionPrice + numberOfTrucks * truckPrice;
            int numberOfToys = numberOfPuzzles + numberOfTalkingDolls + numberOfTeddyBears + numberOfMinions + numberOfTrucks;
            double discount = 0;
            if (numberOfToys >= 50)
            {
                discount = sum * 0.25;
            }
            double finalSum = sum - discount;
            double rent = finalSum * 0.1;
            double money = finalSum - rent;
            if (priceForExcursion > money)
            {
                double moneyNeeded = priceForExcursion - money;
                Console.WriteLine($"Not enough money! {moneyNeeded:f2} lv needed.");
            }
            else
            {
                double moneyLeft = money - priceForExcursion;
                Console.WriteLine($"Yes! {moneyLeft:f2} lv left.");
            }
        }
    }
}
