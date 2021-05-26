using System;

namespace _03_TravellingAgencyAutor
{
    class Program
    {
        static void Main(string[] args)
        {
            string town = Console.ReadLine();
            string pack = Console.ReadLine();
            bool hasVIP = Console.ReadLine() == "yes";
            int days = int.Parse(Console.ReadLine());
            bool isValid = false;

            double price = 0.0;

            if (days > 7)
            {
                days--;
            }

            switch (town)
            {
                case "Bansko":
                case "Borovets":
                    if (hasVIP)
                    {
                        if ("noEquipment" == pack)
                        {
                            price = 80 * 0.95;
                        }
                        else if ("withEquipment" == pack)
                        {
                            price = 100 * 0.9;
                        }
                        else
                        {
                            isValid = true;
                        }
                    }
                    else
                    {
                        if ("noEquipment" == pack)
                        {
                            price = 80;
                        }
                        else if ("withEquipment" == pack)
                        {
                            price = 100;
                        }
                        else
                        {
                            isValid = true;
                        }
                    }
                    break;
                case "Varna":
                case "Burgas":
                    if (hasVIP)
                    {
                        if ("withBreakfast" == pack)
                        {
                            price = 130 * 0.88;
                        }
                        else if ("noBreakfast" == pack)
                        {
                            price = 100 * 0.92;
                        }
                        else
                        {
                            isValid = true;
                        }
                    }
                    else
                    {
                        if ("withBreakfast" == pack)
                        {
                            price = 130;
                        }
                        else if ("noBreakfast" == pack)
                        {
                            price = 100;
                        }
                        else
                        {
                            isValid = true;
                        }
                    }
                    break;
                default:
                    isValid = true;
                    break;
            }
            if (isValid)
            {
                Console.WriteLine("Invalid input!");
            }
            else if (days < 1)
            {
                Console.WriteLine("Days must be positive number!");
            }
            else
            {
                double finalPrice = days * price;
                Console.WriteLine($"The price is {finalPrice:F2}lv! Have a nice time!");
            }
        }
    }
}
