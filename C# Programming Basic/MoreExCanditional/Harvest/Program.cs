using System;

namespace Harvest
{
    class Program
    {
        static void Main(string[] args)
        {
            //•	1ви ред: X кв.м е лозето – цяло число в интервала[10 … 5000]
            //•	2ри ред: Y грозде за един кв.м – реално число в интервала[0.00 … 10.00]
            //•	3ти ред: Z нужни литри вино – цяло число в интервала[10 … 600]
            //•	4ти ред: брой работници – цяло число в интервала[1 … 20]
            int area = int.Parse(Console.ReadLine());
            double dobiv = double.Parse(Console.ReadLine());
            int neededWine = int.Parse(Console.ReadLine());
            int numberWorkers = int.Parse(Console.ReadLine());
            //От лозе с площ X квадратни метри се заделя 40 % от реколтата за производство на вино.От 1 кв.м лозе се изкарват Y килограма грозде.За 1 литър вино са нужни 2,5 кг.грозде.Желаното количество вино за продан е Z литра.
            double realWine = area * 0.4 * dobiv / 2.5;
            //•	Ако произведеното вино е по - малко от нужното:
            //    o   “It will be a tough winter!More { недостигащо вино} liters wine needed.”
            //    	Резултатът трябва да е закръглен към по - ниско цяло число
            //•	Ако произведеното вино е повече от нужното:
            //    o   “Good harvest this year! Total wine: { общо вино} liters.”
            //        	Резултатът трябва да е закръглен към по - ниско цяло число
            //    o   “{ Оставащо вино } liters left -> { вино за 1 работник} liters per person.”
            //        	И двата резултата трябва да са закръглени към по - високото цяло число
                double wine = Math.Abs(realWine - neededWine);
            if (realWine<neededWine)
            {

                Console.WriteLine($"It will be a tough winter! More {Math.Floor(wine)} liters wine needed.");
            }
            else 
            {
                Console.WriteLine($"Good harvest this year! Total wine: {Math.Floor(realWine)} liters.");
                //Ако е достатъчно, остатъкът се разделя по равно между работниците на лозето.
                double wineForWorker = wine / numberWorkers;
                Console.WriteLine($"{Math.Ceiling(wine)} liters left -> {Math.Ceiling(wineForWorker)} liters per person.");
            }
        }
    }
}
