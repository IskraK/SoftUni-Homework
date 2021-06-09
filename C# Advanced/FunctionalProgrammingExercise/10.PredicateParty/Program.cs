using System;
using System.Collections.Generic;
using System.Linq;

namespace _10.PredicateParty
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> guests = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            string input = Console.ReadLine();

            while (input != "Party!")
            {
                string[] cmdParts = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string command = cmdParts[0];
                string criteria = cmdParts[1];

                switch (command)
                {
                    case "Remove":
                        if (criteria == "StartsWith")
                        {
                            guests = guests.Where(name => !name.StartsWith(cmdParts[2])).ToList();
                        }
                        else if (criteria == "EndsWith")
                        {
                            guests = guests.Where(name => !name.EndsWith(cmdParts[2])).ToList();
                        }
                        else if (criteria == "Length")
                        {
                            int length = int.Parse(cmdParts[2]);
                            guests = guests.Where(name => name.Length != length).ToList();
                        }
                    break;
                    case "Double":
                        List<string> guestsToDouble = new List<string>();

                        if (criteria == "StartsWith")
                        {
                            guestsToDouble = guests.Where(name => name.StartsWith(cmdParts[2])).ToList();
                        }
                        else if (criteria == "EndsWith")
                        {
                            guestsToDouble = guests.Where(name => name.EndsWith(cmdParts[2])).ToList();
                        }
                        else if (criteria == "Length")
                        {
                            int length = int.Parse(cmdParts[2]);
                            guestsToDouble = guests.Where(name => name.Length == length).ToList();
                        }

                        foreach (var guest in guestsToDouble)
                        {
                            int idx = guests.IndexOf(guest);
                            guests.Insert(idx, guest);
                        }
                        break;
                    default:
                        break;
                }

                input = Console.ReadLine();
            }

            if (guests.Count > 0)
            {
            Console.WriteLine(string.Join(", ",guests) + " are going to the party!");
            }
            else
            {
                Console.WriteLine("Nobody is going to the party!");
            }
        }
    }
}
