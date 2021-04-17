using System;

namespace _01.PoolDay
{
    class Program
    {
        static void Main(string[] args)
        {
            int people = int.Parse(Console.ReadLine());
            double entryPrice = double.Parse(Console.ReadLine());
            double shezlongPrice = double.Parse(Console.ReadLine());
            double umbrellaPrice = double.Parse(Console.ReadLine());
            double totalPriceShezlong = Math.Ceiling(0.75 * people) * shezlongPrice;
            double totalRriceUmbrellas = Math.Ceiling(0.5 * people) * umbrellaPrice;
            double totalPrice = entryPrice * people + totalPriceShezlong + totalRriceUmbrellas;
            Console.WriteLine($"{totalPrice:f2} lv.");
        }
    }
}
