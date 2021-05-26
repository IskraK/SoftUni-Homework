using System;

namespace _03.FitnessCard
{
    class Program
    {
        static void Main(string[] args)
        {
            //•	Сумата, с която разполагаме - реално число в интервала[10.00…1000.00]
            //•	Пол - символ('m' за мъж и 'f' за жена)
            //•	Възраст - цяло число в интервала[5…105]
            //•	Спорт - текст(една от възможностите в таблицата)
            double myMoney = double.Parse(Console.ReadLine());
            string gender = Console.ReadLine();
            int age = int.Parse(Console.ReadLine());
            string sport = Console.ReadLine();
            double cardPrice = 0;
            //Пол     Gym     Boxing      Yoga    Zumba   Dances  Pilates
            //мъж	    $42     $41         $45      $34     $51     $39
            //жена    $35     $37         $42      $31     $53     $37
            switch (sport)
            {
                case "Gym":
                    if (gender == "m")
                    {
                        cardPrice = 42;
                    }
                    else
                    {
                        cardPrice = 35;
                    }
                    break;
                case "Boxing":
                    if (gender == "m")
                    {
                        cardPrice = 41;
                    }
                    else
                    {
                        cardPrice = 37;
                    }
                    break;
                case "Yoga":
                    if (gender == "m")
                    {
                        cardPrice = 45;
                    }
                    else
                    {
                        cardPrice = 42;
                    }
                    break;
                case "Zumba":
                    if (gender == "m")
                    {
                        cardPrice = 34;
                    }
                    else
                    {
                        cardPrice = 31;
                    }
                    break;
                case "Dances":
                    if (gender == "m")
                    {
                        cardPrice = 51;
                    }
                    else
                    {
                        cardPrice = 53;
                    }
                    break;
                case "Pilates":
                    if (gender == "m")
                    {
                        cardPrice = 39;
                    }
                    else
                    {
                        cardPrice = 37;
                    }
                    break;
            }
            if (age <= 19)
            {
                cardPrice *= 0.8;
            }

            //•	Ако сумата е достатъчна:
            //    "You purchased a 1 month pass for {sport}."
            //        където { sport} е въведения тип спорт
            //•	Ако сумата не е достатъчна трябва да се пресметне колко още пари са необходими, за да се закупи карта:
            //    "You don't have enough money! You need ${money} more."
            //        където { money} e оставащата сума нужна, за да се закупи картата, форматирана до втория знак след десетичната запетая.
            if (myMoney >= cardPrice)
            {
                Console.WriteLine($"You purchased a 1 month pass for {sport}.");
            }
            else
            {
                double neededMoney = cardPrice - myMoney;
                Console.WriteLine($"You don't have enough money! You need ${neededMoney:f2} more.");
            }
        }
    }
}
