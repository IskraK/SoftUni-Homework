using System;
using System.Collections.Generic;
using System.Linq;

namespace P3
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> cards = Console.ReadLine()
                .Split(':', StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            string input = Console.ReadLine();

            while (input != "Ready")
            {
                string[] line = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string command = line[0];
                string cardName = line[1];

                switch (command)
                {
                    case "Add":
                        if (!cards.Contains(cardName))
                        {
                            Console.WriteLine("Card not found.");
                        }
                        cards.Add(cardName);
                        break;
                    case "Insert":
                        int idx = int.Parse(line[2]);
                        if (!cards.Contains(cardName) || idx < 0 || idx >= cards.Count)
                        {
                            Console.WriteLine("Error!");
                        }
                        cards.Insert(idx, cardName);
                        break;
                    case "Remove":
                        if (!cards.Contains(cardName))
                        {
                            Console.WriteLine("Card not found.");
                        }
                        cards.Remove(cardName);
                        break;
                    case "Swap":
                        string cardName2 = line[2];
                        string temp= cardName;
                        cardName = cardName2;
                        cardName2 = temp;
                        break;
                    case "Shuffle":
                        cards.Reverse();
                        break;
                    default:
                        break;
                }

                input = Console.ReadLine();
            }

            Console.WriteLine(string.Join(" ",cards));
        }
    }
}
