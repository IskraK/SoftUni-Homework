using System;

namespace _07.CinemaTickets
{
    class Program
    {
        static void Main(string[] args)
        {
            int studentTicket = 0;
            int standardTicket = 0;
            int kidTicket = 0;
            string input = Console.ReadLine();
            int totalTickets = 0;
            while (input != "Finish")
            {
                int freeSpots = int.Parse(Console.ReadLine());
                int currFreeSpots = freeSpots;
                while (currFreeSpots > 0)
                {
                    string ticketType = Console.ReadLine();
                    if (ticketType == "End")
                    {
                        break;
                    }
                    currFreeSpots--;
                    if (ticketType == "student")
                    {
                        studentTicket++;
                    }
                    else if (ticketType == "standard")
                    {
                        standardTicket++;
                    }
                    else if (ticketType == "kid")
                    {
                        kidTicket++;
                    }
                }
                double pFreeSpots = 100 - 1.0 * currFreeSpots / freeSpots * 100;
                Console.WriteLine($"{input} - {pFreeSpots:f2}% full.");
                input = Console.ReadLine();
                totalTickets = studentTicket + standardTicket + kidTicket;
            }
            double pStudentTickets = 1.0 * studentTicket / totalTickets * 100;
            double pStandardTickets = 1.0 * standardTicket / totalTickets * 100;
            double pKidTickets = 1.0 * kidTicket / totalTickets * 100;
            Console.WriteLine($"Total tickets: {totalTickets}");
            Console.WriteLine($"{pStudentTickets:f2}% student tickets.");
            Console.WriteLine($"{pStandardTickets:f2}% standard tickets.");
            Console.WriteLine($"{pKidTickets:f2}% kids tickets.");
        }
    }
}
