using System;

namespace MatchTickets
{
    class Program
    {
        static void Main(string[] args)
        {
            //•	На първия ред е бюджетът – реално число в интервала[1 000.00... 1 000 000.00]
            //•	На втория ред е категорията – "VIP" или "Normal"
            //•	На третия ред е броят на хората в групата – цяло число в интервала[1... 200]
            double budget = double.Parse(Console.ReadLine());
            string typeTicket = Console.ReadLine();
            int people = int.Parse(Console.ReadLine());
            const double vipTicket = 499.99;
            const double normalTicket = 249.99;
            //•	От 1 до 4 – 75 % от бюджета.
            //•	От 5 до 9 – 60 % от бюджета.
            //•	От 10 до 24 – 50 % от бюджета.
            //•	От 25 до 49 – 40 % от бюджета.
            //•	50 или повече – 25 % от бюджета.
            double transportPrice = 0;
            if (people<=4)
            {
                transportPrice = budget * 0.75;
            }
            else if (people>=5 && people<=9)
            {
                transportPrice = budget * 0.60;
            }
            else if (people >= 10 && people <= 24)
            {
                transportPrice = budget * 0.50;
            }
            else if (people >= 25 && people <= 49)
            {
                transportPrice = budget * 0.40;
            }
            else if (people >= 50)
            {
                transportPrice = budget * 0.25;
            }
            double totalPrice = 0;
            if (typeTicket=="VIP")
            {
                totalPrice = people * vipTicket + transportPrice;
            }
            else
            {
                totalPrice = people * normalTicket + transportPrice;
            }
            double moneyLeft = Math.Abs(budget - totalPrice);
            if (budget>=totalPrice)
            {
                Console.WriteLine($"Yes! You have {moneyLeft:f2} leva left.");
            }
            else
            {
                Console.WriteLine($"Not enough money! You need {moneyLeft:f2} leva.");
            }
        }
    }
}
