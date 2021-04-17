using System;
using System.Collections.Generic;

namespace _03.HouseParty
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfCommands = int.Parse(Console.ReadLine());

            List<string> guests = new List<string>();

            for (int i = 0; i < numberOfCommands; i++)
            {
                string[] line = Console.ReadLine().Split();

                if (line[2] == "going!")
                {
                    if (guests.Contains(line[0]))
                    {
                        Console.WriteLine($"{line[0]} is already in the list!");
                    }
                    else
                    {
                        guests.Add(line[0]);
                    }
                }
                else if (line[2] == "not")
                {
                    if (guests.Contains(line[0]))
                    {
                        guests.Remove(line[0]);
                    }
                    else
                    {
                        Console.WriteLine($"{line[0]} is not in the list!");
                    }
                }
            }

            Console.WriteLine(string.Join("\n",guests));
        }
    }
}
