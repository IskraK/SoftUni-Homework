using System;

namespace DepositCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            ////1.	Депозирана сума – реално число в интервала [100.00 … 10000.00];
            //2.Срок на депозита(в месеци) – цяло число в интервала[1…12];
            //3.Годишен лихвен процент – реално число в интервала[0.00 …100.00];
            double amount = double.Parse(Console.ReadLine());
            int interestInMonth = int.Parse(Console.ReadLine());
            double anualInterest = double.Parse(Console.ReadLine());
            ////4.Calculation
            double interest = amount * anualInterest / 100;
            double interestPerMonth = interest / 12;
            double totalSum = amount + interestPerMonth * interestInMonth;
            ////Output
            Console.WriteLine($"{totalSum:f2}");
        }
    }
}
