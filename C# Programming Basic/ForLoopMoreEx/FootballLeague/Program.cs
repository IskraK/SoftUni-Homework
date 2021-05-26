using System;

namespace FootballLeague
{
    class Program
    {
        static void Main(string[] args)
        {
            int capacityStadium = int.Parse(Console.ReadLine());
            int numberAllFens = int.Parse(Console.ReadLine());
            int numFensA = 0;
            int numFensB = 0;
            int numFensV = 0;
            int numFensG = 0;
            for (int i = 1; i <= numberAllFens; i++)
            {
                string sector = Console.ReadLine();
                switch (sector)
                {
                    case "A":
                        numFensA++;
                        break;
                    case "B":
                        numFensB++;
                        break;
                    case "V":
                        numFensV++;
                        break;
                    case "G":
                        numFensG++;
                        break;
                }
            }
            double pFensA = 1.0 * numFensA / numberAllFens * 100;
            double pFensB = 1.0 * numFensB / numberAllFens * 100;
            double pFensV = 1.0 * numFensV / numberAllFens * 100;
            double pFensG = 1.0 * numFensG / numberAllFens * 100;
            double pAllFens = 1.0 * numberAllFens / capacityStadium * 100;
            Console.WriteLine($"{pFensA:f2}%");
            Console.WriteLine($"{pFensB:f2}%");
            Console.WriteLine($"{pFensV:f2}%");
            Console.WriteLine($"{pFensG:f2}%");
            Console.WriteLine($"{pAllFens:f2}%");
        }
    }
}
