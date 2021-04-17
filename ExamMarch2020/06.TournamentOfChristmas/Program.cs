using System;

namespace _06.TournamentOfChristmas
{
    class Program
    {
        static void Main(string[] args)
        {
            int days = int.Parse(Console.ReadLine());
            double totalMoney = 0;
            int allWins = 0;
            int allLoses = 0;
            for (int i = 1; i <= days; i++)
            {
                string nameOfGame = Console.ReadLine();
                int winForday = 0;
                int loseForDay = 0;
                double money = 0;
                while (nameOfGame != "Finish")
                {
                    string resultOfGame = Console.ReadLine();
                    if (resultOfGame == "win")
                    {
                        money += 20;
                        winForday++;
                    }
                    else
                    {
                        loseForDay++;
                    }
                    nameOfGame = Console.ReadLine();
                }
                if (winForday > loseForDay)
                {
                    money *= 1.1;
                    allWins++;
                }
                else
                {
                    allLoses++;
                }
                totalMoney += money;
            }
            if (allWins > allLoses)
            {
                totalMoney *= 1.2;
                Console.WriteLine($"You won the tournament! Total raised money: {totalMoney:f2}");
            }
            else
            {
                Console.WriteLine($"You lost the tournament! Total raised money: {totalMoney:f2}");
            }
        }
    }
}
