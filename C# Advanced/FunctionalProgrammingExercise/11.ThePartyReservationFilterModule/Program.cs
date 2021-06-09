using System;
using System.Collections.Generic;
using System.Linq;

namespace _11.ThePartyReservationFilterModule
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> guests = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .ToList();
            List<string> filters = new List<string>();

            string input = Console.ReadLine();

            //"{command;filter type;filter parameter}"
            //You can receive the following PRFM commands:
            //    •	"Add filter"
            //    •	"Remove filter"
            //    •	"Print"
            //The possible PRFM filter types are: 
            //    •	"Starts with"
            //    •	"Ends with"
            //    •	"Length"
            //    •	"Contains"

            while (input != "Print")
            {
                string[] parts = input.Split(';', StringSplitOptions.RemoveEmptyEntries);
                string command = parts[0];
                string filterType = parts[1];
                string filterParameter = parts[2];

                switch (command)
                {
                    case "Add filter":
                        filters.Add(filterType + " " + filterParameter);
                        break;
                    case "Remove filter":
                        if (filters.Contains(filterType + " " + filterParameter))
                        {
                        filters.Remove(filterType + " " + filterParameter);
                        }
                        break;
                    default:
                        break;
                }

                input = Console.ReadLine();
            }

            foreach (var filter in filters)
            {
                string[] cmd = filter.Split(' ',StringSplitOptions.RemoveEmptyEntries);
                switch (cmd[0])
                {
                    case "Starts":
                        guests = guests.Where(p => !p.StartsWith(cmd[2])).ToList();
                        break;
                    case "Ends":
                        guests = guests.Where(p => !p.EndsWith(cmd[2])).ToList();
                        break;
                    case "Length":
                        guests = guests.Where(p => p.Length != int.Parse(cmd[1])).ToList();
                        break;
                    case "Contains":
                        guests = guests.Where(p => !p.Contains(cmd[1])).ToList();
                        break;
                    default:
                        break;
                }
            }

            Console.WriteLine(string.Join(' ', guests));
        }
    }
}
