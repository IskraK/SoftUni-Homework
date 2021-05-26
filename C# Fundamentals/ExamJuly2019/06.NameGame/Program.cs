using System;

namespace _06.NameGame
{
    class Program
    {
        static void Main(string[] args)
        {
            string name = Console.ReadLine();
            int totalPoints = 0;
            int currPoints = 0;
            int maxPoints = 0;
            string winner = "";
            while (name != "Stop")
            {
                for (int i = 0; i < name.Length; i++)
                {
                    int points = int.Parse(Console.ReadLine());
                    char currLetter = name[i];
                    if (points == (int)currLetter)
                    {
                        totalPoints += 10;
                    }
                    else
                    {
                        totalPoints += 2;
                    }
                    currPoints = totalPoints;
                    if (maxPoints <= currPoints)
                    {
                        maxPoints = currPoints;
                        winner = name;
                    }
                }
                totalPoints = 0;
                name = Console.ReadLine();
            }
                Console.WriteLine($"The winner is {winner} with {maxPoints} points!");
        }
    }
}
