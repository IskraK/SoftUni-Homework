using System;

namespace Firm
{
    class Program
    {
        static void Main(string[] args)
        {
            //•	На първия ред са необходимите часовете – цяло число в интервала[0... 200 000]
            //•	На втория ред са дните, с които фирмата разполага – цяло число в интервала[0... 20 000]
            //•	На третия ред е броят на служителите, работещи извънредно – цяло число в интервала[0... 200]
            int hoursNeeded = int.Parse(Console.ReadLine());
            int days = int.Parse(Console.ReadLine());
            int workers = int.Parse(Console.ReadLine());
            //Фирма получава заявка за изработването на проект, за който са необходими определен брой часове.Фирмата разполага с определен брой дни. През 10 % от дните служителите са на обучение и не могат да работят по проекта. Един нормален работен ден във фирмата е 8 часа.Всеки служител може да работи по проекта в извънработно време по 2 часа на ден.
            //Часовете трябва да са закръглени към по - ниско цяло число
            double timeForWork = 0.9 * days;
            double realTime = Math.Floor(timeForWork * 8 +  days * 2*workers);
            //•	Ако времето е достатъчно:
            //    o   “Yes!{ оставащите часове} hours left.”
            //•	Ако времето НЕ Е достатъчно:
            //o   “Not enough time!{ недостигащите часове} hours needed.“
            double hoursLeft = Math.Abs(hoursNeeded - realTime);
            if (hoursNeeded<=realTime)
            {
                Console.WriteLine($"Yes!{hoursLeft} hours left.");
            }
            else
            {
                Console.WriteLine($"Not enough time!{hoursLeft} hours needed.");
            }
        }
    }
}
