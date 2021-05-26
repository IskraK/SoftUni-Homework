using System;

namespace _05.Orders
{
    class Program
    {
        static void Main(string[] args)
        {
            const double coffeePrice = 1.50;
            const double waterPrice = 1.00;
            const double cokePrice = 1.40;
            const double snacksPrice = 2.00;
            string product = Console.ReadLine();
            int count = int.Parse(Console.ReadLine());
            //•	coffee – 1.50
            //•	water – 1.00
            //•	coke – 1.40
            //•	snacks – 2.00

            switch (product)
            {
                case "coffee":
                    TotalPrice(coffeePrice, count);
                    break;
                case "water":
                    TotalPrice(waterPrice, count);
                    break;
                case "coke":
                    TotalPrice(cokePrice, count);
                    break;
                case "snacks":
                    TotalPrice(snacksPrice, count);
                    break;
            }

        }

        static void TotalPrice(double price, int quantity )
        {
            Console.WriteLine($"{price* quantity:F2}");
        }
    }
}
