using System;

namespace BikeRace
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberJunior = int.Parse(Console.ReadLine());
            int numberSenior = int.Parse(Console.ReadLine());
            string typeRace = Console.ReadLine();
            //Група       trail   cross - country   downhill    road
            //juniors     5.50        8                12.25     20
            //seniors     7           9.50             13.75     21.50
            double totalSum = 0;
            switch (typeRace)
            {
                case "trail":
                    totalSum = numberJunior * 5.50 + numberSenior * 7;
                    break;
                case "cross-country":
                    totalSum = numberJunior * 8 + numberSenior * 9.50;
                    if (numberJunior+numberSenior>=50)
                    {
                        totalSum -= totalSum * 0.25;
                    }
                    break;
                case "downhill":
                    totalSum = numberJunior * 12.25 + numberSenior * 13.75;
                    break;
                case "road":
                    totalSum = numberJunior * 20 + numberSenior * 21.50;
                    break;
            }
            totalSum -= totalSum * 0.05;
            Console.WriteLine($"{totalSum:f2}");
        }
    }
}
