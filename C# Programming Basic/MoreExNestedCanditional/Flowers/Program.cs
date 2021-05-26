using System;

namespace Flowers
{
    class Program
    {
        static void Main(string[] args)
        {
            //•	На първия ред е броят на закупените хризантеми – цяло число в интервала[0... 200]
            //•	На втория ред е броят на закупените рози – цяло число в интервала[0... 200]
            //•	На третия ред е броят на закупените лалета – цяло число в интервала[0... 200]
            //•	На четвъртия ред е посочен сезона – [Spring, Summer, Аutumn, Winter]
            //•	На петия ред е посочено дали денят е празник – [Y – да / N - не]
            int numberHrizantems = int.Parse(Console.ReadLine());
            int numberRoses = int.Parse(Console.ReadLine());
            int numberTulips = int.Parse(Console.ReadLine());
            string season = Console.ReadLine();
            string typeDay = Console.ReadLine();
            // Сезон           Хризантеми          Рози            Лалета
            //Пролет / Лято   2.00 лв./ бр.    4.10 лв./ бр.    2.50 лв./ бр.
            // Есен / Зима     3.75 лв./ бр.    4.50 лв./ бр.    4.15 лв./ бр.
            double bouquetPrice = 0;
            switch (season)
            {
                case "Spring":
                case "Summer":
                    bouquetPrice = numberHrizantems * 2.00 + numberRoses * 4.10 + numberTulips * 2.50;
                    break;
                case "Autumn":
                case "Winter":
                    bouquetPrice = numberHrizantems * 3.75 + numberRoses * 4.50 + numberTulips * 4.15;
                    break;
                    //•	За закупени повече от 7 лалета през пролетта – 5 % от цената на целият букет.
                    //•	За закупени 10 или повече рози през зимата – 10 % от цената на целият букет.
                    //•	За закупени повече от 20 цветя общо през всички сезони – 20 % от цената на целият букет.
            }
            if (typeDay == "Y")
            {
                bouquetPrice = bouquetPrice * 1.15;
            }
            if (numberTulips > 7 && season == "Spring")
            {
                bouquetPrice -= bouquetPrice * 0.05;
            }
            if (numberRoses >= 10 && season == "Winter")
            {
                bouquetPrice -= bouquetPrice * 0.1;
            }
            if (numberHrizantems + numberRoses + numberTulips > 20)
            {
                bouquetPrice -= bouquetPrice * 0.2;
            }
            Console.WriteLine($"{(bouquetPrice+2):f2}");
        }
    }
}
