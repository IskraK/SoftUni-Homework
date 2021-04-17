using System;
using System.Collections.Generic;
using System.Linq;

namespace _3.MemoryGame
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> elements = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            string input = Console.ReadLine();
            int counter = 0;

            while (input != "end")
            {
                counter++;
                string[] indexes = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                int idx1 = int.Parse(indexes[0]);
                int idx2 = int.Parse(indexes[1]);

                if (idx1 >= 0 && idx1 < elements.Count && idx2 >= 0 && idx2 < elements.Count && idx1 != idx2)
                {
                    if (elements[idx1] == elements[idx2])
                    {
                        Console.WriteLine($"Congrats! You have found matching elements - {elements[idx1]}!");
                        elements.RemoveAt(Math.Max(idx1, idx2));
                        elements.RemoveAt(Math.Min(idx1, idx2));
                    }
                    else
                    {
                        Console.WriteLine("Try again!");
                    }

                    if (elements.Count == 0)
                    {
                        Console.WriteLine($"You have won in {counter} turns!");
                        break;
                    }
                }
                else
                {
                    elements.Insert(elements.Count / 2, $"-{counter}a");
                    elements.Insert(elements.Count / 2, $"-{counter}a");
                    Console.WriteLine("Invalid input! Adding additional elements to the board");

                }

                input = Console.ReadLine();
            }

                Console.WriteLine("Sorry you lose :(");
                Console.WriteLine(string.Join(" ",elements));
        }
    }
}
