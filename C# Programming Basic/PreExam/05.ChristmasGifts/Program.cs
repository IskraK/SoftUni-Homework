using System;

namespace _05.ChristmasGifts
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            int countChildren = 0;
            int countAdult = 0;
            while (input != "Christmas")
            {
                int years = int.Parse(input);
                if (years <= 16)
                {
                    countChildren++;
                }
                else
                {
                    countAdult++;
                }
                input = Console.ReadLine();
            }
            double moneyForToys = countChildren * 5.0;
            double moneyForsweaters = countAdult * 15;
            Console.WriteLine($"Number of adults: {countAdult}");
            Console.WriteLine($"Number of kids: {countChildren}");
            Console.WriteLine($"Money for toys: {moneyForToys}");
            Console.WriteLine($"Money for sweaters: {moneyForsweaters}");
        }
    }
}
