using System;

namespace _05.PCGameShop
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberGames = int.Parse(Console.ReadLine());
            int countHearthstone = 0;
            int countFornite = 0;
            int countOverwatch = 0;
            int countOthers = 0;
            //•	Hearthstone
            //•	Fornite
            //•	Overwatch
            //•	Others
            for (int i = 1; i <= numberGames; i++)
            {
                string nameOfGame = Console.ReadLine();
                if (nameOfGame == "Hearthstone")
                {
                    countHearthstone++;
                }
                else if (nameOfGame == "Fornite")
                {
                    countFornite++;
                }
                else if (nameOfGame == "Overwatch")
                {
                    countOverwatch++;
                }
                else
                {
                    countOthers++;
                }
            }
            double pHearthstone = 1.0*countHearthstone/numberGames*100;
            double pFornite = 1.0*countFornite/numberGames*100;
            double pOverwatch = 1.0*countOverwatch/numberGames*100;
            double pOthers = 1.0*countOthers/numberGames*100;
            Console.WriteLine($"Hearthstone - {pHearthstone:f2}%");
            Console.WriteLine($"Fornite - {pFornite:f2}%");
            Console.WriteLine($"Overwatch - {pOverwatch:f2}%");
            Console.WriteLine($"Others - {pOthers:f2}%");
        }
    }
}
