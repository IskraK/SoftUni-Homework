using System;

namespace FlowerShop
{
    class Program
    {
        static void Main(string[] args)
        {
            //•	Брой магнолии – цяло число в интервала[0 … 50]
            //•	Брой зюмбюли – цяло число в интервала[0 … 50]
            //•	Брой рози – цяло число в интервала[0 … 50]
            //•	Брой кактуси – цяло число в интервала[0 … 50]
            //•	Цена на подаръка – реално число в интервала[0.00 … 500.00]
            int numberMagnolii = int.Parse(Console.ReadLine());
            int numberZiumbuli = int.Parse(Console.ReadLine());
            int numberRoses = int.Parse(Console.ReadLine());
            int numberCactus = int.Parse(Console.ReadLine());
            double priceForGift = double.Parse(Console.ReadLine());
            //•	Магнолии – 3.25 лева
            //•	Зюмбюли – 4 лева
            //•	Рози – 3.50 лева
            //•	Кактуси – 8 лева
            //От общата сума, Мария трябва да плати 5 % данъци.
            const double magnolia = 3.25;
            const double ziumbul = 4;
            const double rose = 3.50;
            const double cactus = 8;
            double priceFlowers = numberMagnolii * magnolia + numberZiumbuli * ziumbul + numberRoses * rose + numberCactus * cactus;
            double realMoney = 0.95 * priceFlowers;
            double moneyLeft = Math.Abs(realMoney - priceForGift);
            //•	Ако парите СА стигнали: "She is left with {останали} leva." – сумата трябва да е закръглена към по - малко цяло число(пр. 1.90-> 1).
            //•	Ако парите НЕ достигат: "She will have to borrow {останали} leva." – сумата трябва да е закръглена към по - голямо цяло число(пр. 1.10-> 2).
            if (realMoney>=priceForGift)
            {
                Console.WriteLine($"She is left with {Math.Floor(moneyLeft)} leva.");
            }
            else
            {
                Console.WriteLine($"She will have to borrow {Math.Ceiling(moneyLeft)} leva.");
            }
        }
    }
}
