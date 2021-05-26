using System;

namespace TransportPrice
{
    class Program
    {
        static void Main(string[] args)
        {
            //•	Първият ред съдържа числото n – брой километри – цяло число в интервала[1…5000]
            //•	Вторият ред съдържа дума “day” или “night” – пътуване през деня или през нощта
            int distance = int.Parse(Console.ReadLine());
            string time = Console.ReadLine();
            //•	Такси.Начална такса: 0.70 лв.Дневна тарифа: 0.79 лв. / км.Нощна тарифа: 0.90 лв. / км.
            //•	Автобус.Дневна / нощна тарифа: 0.09 лв. / км.Може да се използва за разстояния минимум 20 км.
            //•	Влак.Дневна / нощна тарифа: 0.06 лв. / км.Може да се използва за разстояния минимум 100 км.
            double price = 0;
            double taxiPrice = 0;
            double busPrice = 0.09 * distance;
            double trainPrice = 0.06 * distance;
            if (time == "day")
            {
             taxiPrice += 0.7 + 0.79 * distance;
            }
            else
            {
            taxiPrice += 0.7 + 0.9 * distance;
            }
            if (distance<20)
            {
             price = taxiPrice;
            }
            else if (distance>=100)
            {
              price = Math.Min(taxiPrice,trainPrice);
            }
            else
            {
             price = Math.Min(taxiPrice, busPrice);
            }
            Console.WriteLine($"{price:f2}");
        }
    }
}
