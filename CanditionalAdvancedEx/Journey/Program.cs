using System;

namespace Journey
{
    class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            string season = Console.ReadLine();
            double totalMoney = 0;
            if (budget<=100)
            {
                if (season=="summer")
                {
                    totalMoney = budget * 0.30;
                    Console.WriteLine($"Somewhere in Bulgaria");
                    Console.WriteLine($"Camp - {totalMoney:f2}");
                }
                else if (season=="winter")
                {
                    totalMoney = budget * 0.7;
                    Console.WriteLine($"Somewhere in Bulgaria");
                    Console.WriteLine($"Hotel - {totalMoney:f2}");
                }
            }
            else if (budget>100 && budget<=1000)
            {
                if (season=="summer")
                {
                    totalMoney = budget * 0.4;
                    Console.WriteLine($"Somewhere in Balkans");
                    Console.WriteLine($"Camp - {totalMoney:f2}");
                }
                else if (season=="winter")
                {
                    totalMoney = budget * 0.8;
                    Console.WriteLine($"Somewhere in Balkans");
                    Console.WriteLine($"Hotel - {totalMoney:f2}");
                }
            }
            else
            {
                totalMoney = budget * 0.9;
                Console.WriteLine($"Somewhere in Europe");
                Console.WriteLine($"Hotel - {totalMoney:f2}");
            }
            //•	Първи ред – „Somewhere in [дестинация]“ измежду “Bulgaria", "Balkans” и ”Europe”
            //•	Втори ред – “{ Вид почивка} – { Похарчена сума}“
            //o Почивката може да е между „Camp” и „Hotel”

        }
    }
}
