using System;

namespace HotelRoom
{
    class Program
    {
        static void Main(string[] args)
        {
            string month = Console.ReadLine();
            int nights = int.Parse(Console.ReadLine());
            double priceStudio = 0;
            double priceApartment = 0;
            double totalMoneyStudio = 0;
            double totalMoneyApartment = 0;
            switch (month)
            {
                case "May":
                case "October":
                    priceStudio = 50;
                    priceApartment = 65;
                    totalMoneyStudio = priceStudio * nights;
                    totalMoneyApartment = priceApartment * nights;
                    if (nights>7 && nights<=14)
                    {
                        totalMoneyStudio -= totalMoneyStudio * 0.05;
                    }
                    else if (nights>14)
                    {
                        totalMoneyStudio -= totalMoneyStudio * 0.30;
                        totalMoneyApartment -= totalMoneyApartment * 0.10;
                    }
                    break;
                case "June":
                case "September":
                    priceStudio = 75.20;
                    priceApartment = 68.70;
                    totalMoneyStudio = priceStudio * nights;
                    totalMoneyApartment = priceApartment * nights;
                    if (nights > 14)
                    {
                        totalMoneyStudio -= totalMoneyStudio * 0.20;
                        totalMoneyApartment -= totalMoneyApartment * 0.10;
                    }
                    break;
                case "July":
                case "August":
                    priceStudio = 76;
                    priceApartment = 77;
                    totalMoneyStudio = priceStudio * nights;
                    totalMoneyApartment = priceApartment * nights;
                    if (nights > 14)
                    {
                        totalMoneyApartment -= totalMoneyApartment * 0.10;
                    }
                    break;
                //•	За студио, при повече от 7 нощувки през май и октомври: 5 % намаление.
                //•	За студио, при повече от 14 нощувки през май и октомври: 30 % намаление.
                //•	За студио, при повече от 14 нощувки през юни и септември: 20 % намаление.
                //•	За апартамент, при повече от 14 нощувки, без значение от месеца : 10 % намаление.
            }
            Console.WriteLine($"Apartment: {totalMoneyApartment:f2} lv.");
            Console.WriteLine($"Studio: {totalMoneyStudio:f2} lv.");
        }
    }
}
