using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.DrumSet
{
    class Program
    {
        static void Main(string[] args)
        {
            double money = double.Parse(Console.ReadLine());

            List<int> drumSet = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            string input = Console.ReadLine();

            List<int> initialDrumSet = drumSet.ToList();

            while (input != "Hit it again, Gabsy!")
            {
                int hitPower = int.Parse(input);

                for (int i = 0; i < drumSet.Count; i++)
                {
                    drumSet[i] -= hitPower;
                }

                for (int i = 0; i < drumSet.Count; i++)
                {
                    if (drumSet[i] <= 0)
                    {
                        if (initialDrumSet[i] * 3 <= money)
                        {
                            drumSet[i] = initialDrumSet[i];
                            money -= initialDrumSet[i] * 3;
                        }
                        else
                        {
                            initialDrumSet.RemoveAt(i);
                            drumSet.RemoveAt(i);
                        }
                    }
                }

                input = Console.ReadLine();
            }
            Console.WriteLine(string.Join(" ", drumSet));
            Console.WriteLine($"Gabsy has {money:F2}lv.");
        }
    }
}

