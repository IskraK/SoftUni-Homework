using System;
using System.Linq;

namespace P2._1
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] names = Console.ReadLine()
                .Split(", ")
                .ToArray();

            string input = Console.ReadLine();

            while (input != "Report")
            {
                string[] line = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string command = line[0];

                switch (command)
                {
                    case "Blacklist":
                        string name = line[1];
                        if (!names.Contains(name))
                        {
                            Console.WriteLine($"{name} was not found.");
                        }
                        else
                        {
                            name = "Blacklisted";
                            Console.WriteLine($"{name} was blacklisted.");
                        }
                        break;
                    case "Error":
                        int idx = int.Parse(line[1]);

                        if (names[idx] != "Blacklisted" || names[idx] != "Lost")
                        {
                            Console.WriteLine($"{names[idx]} was lost due to an error.");
                        }

                        names[idx] = "Lost";
                        break;
                    case "Change":
                        idx = int.Parse(line[1]);
                        string newName = line[2];

                        if (idx >= 0 && idx < names.Length)
                        {
                            Console.WriteLine($"{names[idx]} changed his username to {newName}");
                            names[idx] = newName;
                        }
                        break;
                    default:
                        break;
                }

                input = Console.ReadLine();
            }

            int countBlacklistedNames = 0;
            int countLostNames = 0;

            for (int i = 0; i < names.Length; i++)
            {
                if (names[i] == "Blacklisted")
                {
                    countBlacklistedNames++;
                }
                else if (names[i] == "Lost")
                {
                    countLostNames++;
                }
            }

            Console.WriteLine($"Count of blacklisted names: {countBlacklistedNames}.");
            Console.WriteLine($"Count of lost names: {countLostNames}.");
            Console.WriteLine(string.Join(" ",names));
        }
    }
}
