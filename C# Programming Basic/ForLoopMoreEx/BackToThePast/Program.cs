using System;

namespace BackToThePast
{
    class Program
    {
        static void Main(string[] args)
        {
            double money = double.Parse(Console.ReadLine());
            int year = int.Parse(Console.ReadLine());
            double moneySpend = 0;
            for (int i = 1800; i <= year; i++)
            {
                int ageIvan = 18 + (i - 1800);
                if (i % 2 ==0)
                {
                    moneySpend += 12000;
                }
                else
                {
                    moneySpend += 12000 + 50 * ageIvan;
                }
            }
            double moneyLeft = Math.Abs(money - moneySpend);
            if (money >= moneySpend)
            {
                Console.WriteLine($"Yes! He will live a carefree life and will have {moneyLeft:f2} dollars left.");
            }
            else
            {
                Console.WriteLine($"He will need {moneyLeft:f2} dollars to survive." );
            }
        }
    }
}
