using System;

namespace _03_TravelAgency
{
    class Program
    {
        static void Main(string[] args)
        {
            //От конзолата се четат 4 реда:
            //1.Име на града -текст с възможности("Bansko",  "Borovets", "Varna" или "Burgas")
            //2.Вид на пакета -текст с възможности("noEquipment",  "withEquipment", "noBreakfast" или "withBreakfast")
            //3.Притежание на VIP отстъпка - текст с възможности  "yes" или "no"
            //4.Дни за престой -цяло число в интервала[1 … 10000]
            string town = Console.ReadLine();
            string typePackage = Console.ReadLine();
            string vip = Console.ReadLine();
            int days = int.Parse(Console.ReadLine());
            double totalPrice = 0;
            //    Цена за ден     Банско/ Боровец                 Варна / Бургас

            //            с екипировка    без екипировка      със закуска     без закуска

            //                100лв.          80лв                130лв.          100лв.
            //VIP отстъпка    10 %            5 %                 12 %            7 %

            if (days < 7)
            {
                days--;
            }
            switch (town)
            {
                case "Bansko":
                case "Borovets":
                    if (typePackage == "withEquipment")
                    {
                        totalPrice = days * 100;
                        if (vip == "yes")
                        {
                            totalPrice *= 0.9;
                        }
                    }
                    else if (typePackage == "noEquipment")
                    {
                        totalPrice = days * 80;
                        if (vip == "yes")
                        {
                            totalPrice *= 0.95;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid input!");
                    }
                    break;
                case "Varna":
                case "Burgas":
                    if (typePackage == "withBreakfast")
                    {
                        totalPrice = days * 130;
                        if (vip == "yes")
                        {
                            totalPrice *= 0.88;
                        }
                    }
                    else if (typePackage == "noBreakfast")
                    {
                        totalPrice = days * 100;
                        if (vip == "yes")
                        {
                            totalPrice *= 0.93;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid input!");
                    }
                    break;
                default:
                    Console.WriteLine("Invalid input!");
                    break;
            }
            if (days < 1)
            {
                Console.WriteLine("Days must be positive number!");
            }
            else
            {
                Console.WriteLine($"The price is {totalPrice:f2}lv! Have a nice time!");
            }
        }
    }
}
