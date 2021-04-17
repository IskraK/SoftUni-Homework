using System;

namespace MoneyConvertor
{
    class StartUp
    {
        static void Main(string[] args)
        {
            double usd = double.Parse(Console.ReadLine());
            const double dollarsCourse = 1.79549;
            double bgn = usd * dollarsCourse;
            Console.WriteLine($"{bgn:f2}");
        }
    }
}
