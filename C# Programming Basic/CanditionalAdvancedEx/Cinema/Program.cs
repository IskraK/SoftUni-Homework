using System;

namespace Cinema
{
    class Program
    {
        static void Main(string[] args)
        {
            //чете тип прожекция(стринг), брой редове и брой колони в залата(цели числа)
            string type = Console.ReadLine();
            int rows=int.Parse(Console.ReadLine());
            int columns=int.Parse(Console.ReadLine());
            double totalPrice = 0;
            const double ticketPricePremiere = 12.00;
            const double ticketPriceNormal = 7.50;
            const double ticketPriceDiscount = 5.00;
            switch (type)
            {
                case "Premiere":
                    totalPrice = rows * columns * ticketPricePremiere;
                    break;
                case "Normal":
                    totalPrice = rows * columns * ticketPriceNormal;
                    break;
                case "Discount":
                    totalPrice = rows * columns * ticketPriceDiscount;
                    break;
            }
            Console.WriteLine($"{totalPrice:f2} leva");
        }
    }
}
