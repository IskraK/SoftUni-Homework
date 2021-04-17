using System;

namespace TruckDriver
{
    class Program
    {
        static void Main(string[] args)
        {
            string season = Console.ReadLine();
            double kmPerMonth = double.Parse(Console.ReadLine());
            double sаlary = 0;
            //                                Пролет / Есен     Лято          Зима
            //км на месец <= 5000             0.75 лв./ км    0.90 лв./ км    1.05 лв./ км
            //5000 < км на месец <= 10000     0.95 лв./ км    1.10 лв./ км    1.25 лв./ км
            //10000 < км на месец <= 20000    1.45 лв./ км – за който и да е сезон
            switch (season)
            {
                case "Spring":
                case "Autumn":
                    if (kmPerMonth<=5000)
                    {
                        sаlary = kmPerMonth * 0.75 * 4;
                    }
                    else if (kmPerMonth>5000 && kmPerMonth<=10000)
                    {
                        sаlary = kmPerMonth * 0.95 * 4;
                    }
                    else if (kmPerMonth>10000)
                    {
                        sаlary = kmPerMonth * 1.45 * 4;
                    }
                    break;
                case "Summer":
                    if (kmPerMonth <= 5000)
                    {
                        sаlary = kmPerMonth * 0.90 * 4;
                    }
                    else if (kmPerMonth > 5000 && kmPerMonth <= 10000)
                    {
                        sаlary = kmPerMonth * 1.10 * 4;
                    }
                    else if (kmPerMonth > 10000)
                    {
                        sаlary = kmPerMonth * 1.45 * 4;
                    }
                    break;
                case "Winter":
                    if (kmPerMonth <= 5000)
                    {
                        sаlary = kmPerMonth * 1.05 * 4;
                    }
                    else if (kmPerMonth > 5000 && kmPerMonth <= 10000)
                    {
                        sаlary = kmPerMonth * 1.25 * 4;
                    }
                    else if (kmPerMonth > 10000)
                    {
                        sаlary = kmPerMonth * 1.45 * 4;
                    }
                    break;
            }
            sаlary -= sаlary * 0.10;
            Console.WriteLine($"{sаlary:f2}");
        }
    }
}
