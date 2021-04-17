using System;

namespace FishingBoat
{
    class Program
    {
        static void Main(string[] args)
        {
            //•	Бюджет на групата – цяло число в интервала[1…8000]
            //•	Сезон –  текст: "Spring", "Summer", "Autumn", "Winter"
            //•	Брой рибари – цяло число в интервала[4…18]
            const int springRent = 3000;
            const int summerAndAutumnRent = 4200;
            const int winterRent = 2600;
            int budget = int.Parse(Console.ReadLine());
            string season = Console.ReadLine();
            int numberFisherman = int.Parse(Console.ReadLine());
            double totalSum = 0;
            //•	Ако групата е до 6 човека включително  –  отстъпка от 10 %.
            //•	Ако групата е от 7 до 11 човека включително  –  отстъпка от 15 %.
            //•	Ако групата е от 12 нагоре  –  отстъпка от 25 %.
            switch (season)
            {
                case "Spring":
                    totalSum = springRent;
                    break;
                case "Summer":
                case "Autumn":
                    totalSum = summerAndAutumnRent;
                    break;
                case "Winter":
                    totalSum = winterRent;
                    break;
            }
            if (numberFisherman<=6)
            {
                totalSum *= 0.9;
            }
            else if (numberFisherman>7 && numberFisherman<=11)
            {
                totalSum *= 0.85;
            }
            else if (numberFisherman>=12)
            {
                totalSum *= 0.75;
            }
            if (numberFisherman%2==0 && season!="Autumn")
            {
                totalSum -= totalSum * 0.05;
            }
            //•	Ако бюджетът е достатъчен:
            //    "Yes! You have {останалите пари} leva left."
            //•	Ако бюджетът НЕ Е достатъчен:
            //    "Not enough money! You need {сумата, която не достига} leva."
            double moneyLeft = Math.Abs(budget - totalSum);
            if (budget>=totalSum)
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
