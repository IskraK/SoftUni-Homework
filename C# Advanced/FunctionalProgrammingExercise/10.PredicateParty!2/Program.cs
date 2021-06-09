using System;
using System.Collections.Generic;
using System.Linq;

namespace _10.PredicateParty_2
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> guests = Console.ReadLine()
                .Split(' ',StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            Func<string, string, string, bool> filtering = (guest, criteria, filter) =>
            {
                switch (criteria)
                {
                    case "StartsWith":
                        if (guest.StartsWith(filter))
                        {
                            return true;
                        }
                        break;
                    case "EndsWith":
                        if (guest.EndsWith(filter))
                        {
                            return true;
                        }
                        break;
                    case "Length":
                        if (guest.Length == int.Parse(filter))
                        {
                            return true;
                        }
                        break;
                }
                return false;
            };

            string input = Console.ReadLine();

            while (input != "Party!")
            {
                string[] cmdParts = input.Split(' ',StringSplitOptions.RemoveEmptyEntries);
                string command = cmdParts[0];

                switch (command)
                {
                    case "Remove":
                        guests = guests.Where(p => !filtering(p, cmdParts[1], cmdParts[2])).ToList();
                        break;
                    case "Double":
                        List<string> guestsToAdd = guests.Where(p => filtering(p, cmdParts[1], cmdParts[2])).ToList();

                        foreach (var guest in guestsToAdd)
                        {
                            guests.Insert(guests.IndexOf(guest), guest);
                        }
                        break;
                    default:
                        break;
                }
                input = Console.ReadLine();
            }

            if (guests.Count == 0)
            {
                Console.WriteLine("Nobody is going to the party!");
            }
            else
            {
                Console.Write(String.Join(", ", guests));
                Console.WriteLine(" are going to the party!");
            }
        }
    }
}
