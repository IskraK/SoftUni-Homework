using System;
using System.Text.RegularExpressions;

namespace _1.WinningTicket
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] tickets = Console.ReadLine()
                .Split(new char[] {' ',','}, StringSplitOptions.RemoveEmptyEntries);

            string pattern = @"(.*?)([@#$^]{6,})(.*?)(\2)(.*)";

            Regex regex = new Regex(pattern);

            foreach (var ticket in tickets)
            {
                Match match = regex.Match(ticket);
                if (ticket.Length != 20)
                {
                    Console.WriteLine("invalid ticket");
                }
                else
                {
                    if (!match.Success)
                    {
                        Console.WriteLine($"ticket \"{ticket}\" - no match");
                    }
                    else
                    {
                        string winning = string.Empty;
                        if (match.Groups[2].Value.Length <= match.Groups[4].Value.Length)
                        {
                            winning = match.Groups[2].Value;
                        }
                        else
                        {
                            winning = match.Groups[4].Value;
                        }

                        if (winning.Length >= 6 & winning.Length <= 9)
                        {
                            Console.WriteLine($"ticket \"{ticket}\" - {winning.Length}{winning[0]}");
                        }
                        else if (winning.Length == 10)
                        {
                            Console.WriteLine($"ticket \"{ticket}\" - {winning.Length}{winning[0]} Jackpot!");
                        }
                    }
                }
            }
            //80/100
        }
    }
}
