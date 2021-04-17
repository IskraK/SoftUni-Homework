using System;

namespace ChangeBureau
{
    class Program
    {
        static void Main(string[] args)
        {
            //•	На първия ред – броят биткойни. Цяло число в интервала[0…20]
            //•	На втория ред – броят китайски юана.Реално число в интервала[0.00… 50 000.00]
            //•	На третия ред – комисионната.Реално число в интервала[0.00... 5.00]
            const int bitcoinToLv = 1168;
            const double uanToDollar = 0.15;
            const double dollarToLv = 1.76;
            const double euToLv = 1.95;
            int numberBitcoins = int.Parse(Console.ReadLine());
            double numberUans = double.Parse(Console.ReadLine());
            double comission = double.Parse(Console.ReadLine());
            //•	1 биткойн = 1168 лева.
            //•	1 китайски юан = 0.15 долара.
            //•	1 долар = 1.76 лева.
            //•	1 евро = 1.95 лева
            double moneyLv = numberBitcoins * bitcoinToLv + numberUans * uanToDollar*dollarToLv;
            double moneyEu = (moneyLv /euToLv)*(1-comission/100);
            Console.WriteLine($"{moneyEu:f2}");
        }
    }
}
