using System;

namespace CarToGo
{
    class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            string season = Console.ReadLine();
            double priceForCar = 0;
            //•	При бюджет по - малък или равен от 100лв.:
            //    o Класът ще е -"Economy class"
            //    o Според сезона колата и цената ще са:
            //    	Лято – Кабрио – 35 % от бюджета
            //        	Зима – Джип – 65 % от бюджета
            //•	При бюджет по - голям от 100лв.и по-малък или равен от 500лв.:
            //    o        Класът ще е -"Compact class"
            //    o Според сезона колата и цената ще са:
            //    	Лято – Кабрио – 45 % от бюджета
            //    	Зима – Джип – 80 % от бюджета
            //•	При бюджет по - голям от 500лв.:
            //    o Класът ще е – "Luxury class"
            //    o За всеки сезон колата ще е джип и цената ще е:
            //        	90 % от бюджета
            if (budget<=100)
            {
                if (season=="Summer")
                {
                    priceForCar = budget * 0.35;
                    Console.WriteLine("Economy class");
                    Console.WriteLine($"Cabrio - {priceForCar:f2}");
                }
                else
                {
                    priceForCar = budget * 0.65;
                    Console.WriteLine("Economy class");
                    Console.WriteLine($"Jeep - {priceForCar:f2}");
                }
            }
            else if (budget>100 && budget<=500)
            {
                if (season == "Summer")
                {
                    priceForCar = budget * 0.45;
                    Console.WriteLine("Compact class");
                    Console.WriteLine($"Cabrio - {priceForCar:f2}");
                }
                else
                {
                    priceForCar = budget * 0.80;
                    Console.WriteLine("Compact class");
                    Console.WriteLine($"Jeep - {priceForCar:f2}");
                }
            }
            else if (budget>500)
            {
                priceForCar = budget * 0.90;
                Console.WriteLine("Luxury class");
                Console.WriteLine($"Jeep - {priceForCar:f2}");
            }
            //•	Първи ред – "{Вид на класа}"
            //    o   "Economy class", "Compact class" или "Luxury class"
            //•	Втори ред – "{Вид на колата} - {цена на колата}"
            //    o Видът на колата – "Cabrio" или "Jeep"

        }
    }
}
