using System;

namespace SchoolCamp
{
    class Program
    {
        static void Main(string[] args)
        {
            //1.Сезонът – текст - “Winter”, “Spring” или “Summer”;
            //2.Видът на групата – текст - “boys”, “girls” или “mixed”;
            //3.Брой на учениците – цяло число в интервала[1 … 10000];
            //4.Брой на нощувките – цяло число в интервала[1 … 100].
            string season = Console.ReadLine();
            string typeGroup = Console.ReadLine();
            int numberChildren = int.Parse(Console.ReadLine());
            int numberNights = int.Parse(Console.ReadLine());
            //                        Зимна ваканция  Пролетна ваканция   Лятна ваканция
            //момчета / момичета          9.60            7.20                15
            //смесена група               10              9.50                20
            double totalSum = 0;
            switch (season)
            {
                case "Winter":
                    if (typeGroup == "boys" || typeGroup == "girls")
                    {
                        totalSum = numberChildren *numberNights* 9.60;
                    }
                    else if (typeGroup == "mixed")
                    {
                        totalSum = numberChildren * numberNights * 10.0;
                    }
                    break;
                case "Spring":
                    if (typeGroup == "boys" || typeGroup == "girls")
                    {
                        totalSum = numberChildren * numberNights * 7.20;
                    }
                    else if (typeGroup == "mixed")
                    {
                        totalSum = numberChildren * numberNights * 9.50;
                    }
                    break;
                case "Summer":
                    if (typeGroup == "boys" || typeGroup == "girls")
                    {
                        totalSum = numberChildren * numberNights * 15.0;
                    }
                    else if (typeGroup == "mixed")
                    {
                        totalSum = numberChildren * numberNights * 20.0;
                    }
                    break;
            }
            //•	Ако броят на учениците е 50 или повече, училището получава 50 % отстъпка
            //•	Ако броят на учениците е 20 или повече и в същото време по - малък от 50, училището получава 15 % отстъпка
            //•	Ако броят на учениците е 10 или повече и в същото време по - малък от 20, училището получава 5 % отстъпка
            if (numberChildren >= 50)
            {
                totalSum = totalSum * 0.50;
            }
            else if (numberChildren >= 20 && numberChildren < 50)
            {
                totalSum = totalSum * 0.85;
            }
            else if (numberChildren >= 10 && numberChildren < 20)
            {
                totalSum = totalSum * 0.95;
            }
            //                Зимна ваканция  Пролетна ваканция   Лятна ваканция
            //момичета            Gymnastics      Athletics           Volleyball
            //момчета             Judo            Tennis              Football
            //смесена група       Ski             Cycling             Swimming
            if (season == "Winter" && typeGroup == "girls")
            {
                Console.WriteLine($"Gymnastics {totalSum:f2}");
            }
            else if (season == "Winter" && typeGroup == "boys")
            {
                Console.WriteLine($"Judo {totalSum:f2} lv.");
            }
            else if (season == "Winter" && typeGroup == "mixed")
            {
                Console.WriteLine($"Ski {totalSum:f2} lv.");
            }
            else if (season == "Spring" && typeGroup == "girls")
            {
                Console.WriteLine($"Athletics {totalSum:f2} lv.");
            }
            else if (season == "Spring" && typeGroup == "boys")
            {
                Console.WriteLine($"Tennis {totalSum:f2} lv.");
            }
            else if (season == "Spring" && typeGroup == "mixed")
            {
                Console.WriteLine($"Cycling {totalSum:f2} lv.");
            }
            else if (season == "Summer" && typeGroup == "girls")
            {
                Console.WriteLine($"Volleyball {totalSum:f2} lv.");
            }
            else if (season == "Summer" && typeGroup == "boys")
            {
                Console.WriteLine($"Football {totalSum:f2} lv.");
            }
            else if (season == "Summer" && typeGroup == "mixed")
            {
                Console.WriteLine($"Swimming {totalSum:f2} lv.");
            }
        }
    }
}
