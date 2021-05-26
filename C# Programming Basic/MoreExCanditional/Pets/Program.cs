using System;

namespace Pets
{
    class Program
    {
        static void Main(string[] args)
        {
            //•	Първи ред – брой дни – цяло число в интервал[1…5000]
            //•	Втори ред – оставена храна в килограми – цяло число в интервал[0…100000]
            //•	Трети ред – храна на ден за кучето в килограми – реално число в интервал[0.00…100.00]
            //•	Четвърти ред – храна на ден за котката в килограми– реално число в интервал[0.00…100.00]
            //•	Пети ред – храна на ден за костенурката в грамове – реално число в интервал[0.00…10000.00]
            int days = int.Parse(Console.ReadLine());
            int foodAll = int.Parse(Console.ReadLine());
            double foodDogPerDay = double.Parse(Console.ReadLine());
            double foodCatPerDay = double.Parse(Console.ReadLine());
            double foodTurtlePerDay = double.Parse(Console.ReadLine());
            double foodNeeded = (foodDogPerDay + foodCatPerDay + foodTurtlePerDay*0.001) * days;
//            •	Ако оставената храна Е достатъчна:
//            o   "{килограма остатък} kilos of food left."
//                	Резултатът трябва да е закръглен към по - ниското цяло число
//            •	Ако оставената храна НЕ Е достатъчна:
//o                  “{ килограма недостигат}
//            more kilos of food are needed.”
//                    	Резултатът трябва да е закръглен към по - високото цяло число
            double foodLeft = Math.Abs(foodAll - foodNeeded);
            if (foodAll>=foodNeeded)
            {
                Console.WriteLine($"{Math.Floor(foodLeft)} kilos of food left.");
            }
            else
            {
                Console.WriteLine($"{Math.Ceiling(foodLeft)} more kilos of food are needed.");
            }
        }
    }
}
