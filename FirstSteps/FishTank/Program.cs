using System;

namespace FishTank
{
    class Program
    {
        static void Main(string[] args)
        {
            //1.Дължина в см – цяло число в интервала[10 … 500]
            //2.Широчина в см – цяло число в интервала[10 … 300]
            //3.Височина в см – цяло число в интервала[10… 200]
            //4.Процент  – реално число в интервала[0.000 … 100.000]
            int aCm = int.Parse(Console.ReadLine());
            int bCm = int.Parse(Console.ReadLine());
            int cCm = int.Parse(Console.ReadLine());
            double percent = double.Parse(Console.ReadLine());
            double capacityL = aCm * bCm * cCm * 0.001;
            double realCapacity = capacityL*(1 - percent / 100);
            Console.WriteLine($"{realCapacity:f5}");
        }
    }
}
