using System;

namespace _05.FootballTournament
{
    class Program
    {
        static void Main(string[] args)
        {
            string team = Console.ReadLine();
            int numberGames = int.Parse(Console.ReadLine());
            int countW = 0;
            int countD = 0;
            int countL = 0;
            int points = 0;
            for (int i = 1; i <= numberGames; i++)
            {
                 string result = Console.ReadLine();
                if (result == "W")
                {
                    countW++;
                    points += 3;
                }
                else if (result == "D")
                {
                    countD++;
                    points += 1;
                }
                else if (result == "L")
                {
                    countL++;
                }
            }
            if (numberGames >= 1)
            {
            double pWins = 1.0 * countW / numberGames*100;
                Console.WriteLine($"{team} has won {points} points during this season.");
                Console.WriteLine("Total stats:");
                Console.WriteLine($"## W: {countW}");
                Console.WriteLine($"## D: {countD}");
                Console.WriteLine($"## L: {countL}");
                Console.WriteLine($"Win rate: {pWins:f2}%");
            }
            else
            {
            Console.WriteLine($"{team} hasn't played any games during this season.");
            }
        }
    }
}
