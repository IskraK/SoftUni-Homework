using System;

namespace SkiTrip
{
    class Program
    {
        static void Main(string[] args)
        {
            //•	Първи ред -дни за престой -цяло число в интервала[0...365]
            //•	Втори ред -вид помещение - "room for one person", "apartment" или "president apartment"
            //•	Трети ред -оценка - "positive"  или "negative"
            int days = int.Parse(Console.ReadLine());
            string typeRoom = Console.ReadLine();
            string rating = Console.ReadLine();
            //вид помещение       по - малко от 10 дни    между 10 и 15 дни       повече от 15 дни
            //room for one person не ползва намаление     не ползва намаление     не ползва намаление
            //apartment           30 % от крайната цена    35 % от крайната цена    50 % от крайната цена
            //president apartment 10 % от крайната цена    15 % от крайната цена    20 % от крайната цена
            double roomPrice = 0;
            double totalPrice = 0;
            double discount = 0;
            switch (typeRoom)
            {
                case "room for one person":
                    roomPrice = 18;
                    break;
                case "apartment":
                    roomPrice = 25;
                    if (days<10)
                    {
                        discount = 30;
                    }
                    else if (days>=10 && days<=15)
                    {
                        discount = 35;
                    }
                    else if (days>15)
                    {
                        discount = 50;
                    }
                    break;
                case "president apartment":
                    roomPrice = 35;
                    if (days < 10)
                    {
                        discount = 10;
                    }
                    else if (days >= 10 && days <= 15)
                    {
                        discount = 15;
                    }
                    else if (days > 15)
                    {
                        discount = 20;
                    }
                    break;
            }
            if (days<=1)
            {
                totalPrice = 0;
            }
            else
            {
                totalPrice = (days - 1) * roomPrice;
                totalPrice = totalPrice - totalPrice * discount / 100;
            }
            //Ако оценката му е позитивна, към цената с вече приспаднатото намаление Атанас добавя 25 % от нея.Ако оценката му е негативна приспада от цената 10 %.
            if (rating=="positive")
            {
                totalPrice *= 1.25;
            }
            else
            {
                totalPrice *= 0.9;
            }
            Console.WriteLine($"{totalPrice:f2}");
        }
    }
}
