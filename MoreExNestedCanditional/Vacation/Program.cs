using System;

namespace Vacation
{
    class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            string season = Console.ReadLine();
            double price = 0;
            //•	При бюджет по - малък или равен от 1000лв.:
            //    o Настаняване в "Camp"
            //    o Според сезона локацията ще е една от следните и ще струва определен процент от бюджета:
            //        	Лято – Аляска – 65 % от бюджета
            //        	Зима – Мароко – 45 % от бюджета
            //•	При бюджет по - голям от 1000лв.и по-малък или равен от 3000лв.:
            //    o Настаняване в "Hut"
            //    o Според сезона локацията ще е една от следните и ще струва определен процент от бюджета:
            //        	Лято – Аляска – 80 % от бюджета
            //        	Зима – Мароко – 60 % от бюджета
            //•	При бюджет по - голям от 3000лв.:
            //    o Настаняване в "Hotel"
            //    o Според сезона локацията ще е една от следните и ще струва 90 % от бюджета:
            //        	Лято – Аляска
            //        	Зима – Мароко
            if (budget<=1000)
            {
                if (season=="Summer")
                {
                    price = budget * 0.65;
                    Console.WriteLine($"Alaska - Camp - {price:f2}");
                }
                else
                {
                    price = budget * 0.45;
                    Console.WriteLine($"Morocco - Camp - {price:f2}");
                }
            }
            else if (budget>1000 && budget<=3000)
            {
                if (season == "Summer")
                {
                    price = budget * 0.80;
                    Console.WriteLine($"Alaska - Hut - {price:f2}");
                }
                else 
                {
                    price = budget * 0.60;
                    Console.WriteLine($"Morocco - Hut - {price:f2}");
                }
            }
            else if (budget>3000)
            {
                if (season == "Summer")
                {
                    price = budget * 0.90;
                    Console.WriteLine($"Alaska - Hotel - {price:f2}");
                }
                else
                {
                    price = budget * 0.90;
                    Console.WriteLine($"Morocco - Hotel - {price:f2}");
                }
            }
            //"{локацията} – {мястото за настаняване} – {цената}"
        }
    }
}
