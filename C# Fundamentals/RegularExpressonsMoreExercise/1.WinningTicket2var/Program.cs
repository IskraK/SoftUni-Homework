using System;
using System.Text.RegularExpressions;

namespace _1.WinningTicket2var
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] tickets = Console.ReadLine()
                .Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);

            string pattern = @".*?(([@#$^])\2{5,9}).*?";

            foreach (var ticket in tickets)
            {
                if (ticket.Length == 20)
                {
                    string leftSide = ticket.Substring(0, 10);
                    string rightSide = ticket.Substring(10);
                    Match matchLeftSide = Regex.Match(leftSide, pattern);
                    Match matchRightSide = Regex.Match(rightSide, pattern);

                    if (matchLeftSide.Success && matchRightSide.Success && matchLeftSide.Groups[2].Value == matchRightSide.Groups[2].Value)
                    {
                        int min = Math.Min(matchLeftSide.Groups[1].Length, matchRightSide.Groups[1].Length);
                        if (min == 10)
                        {
                            Console.WriteLine($"ticket \"{ticket}\" - 10{matchLeftSide.Groups[2].Value} Jackpot!");
                        }
                        else
                        {
                            Console.WriteLine($"ticket \"{ticket}\" - {min}{matchLeftSide.Groups[2].Value}");
                        }
                    }
                    else
                    {
                        Console.WriteLine($"ticket \"{ticket}\" - no match");
                    }
                }
                else
                {
                    Console.WriteLine("invalid ticket");
                }
            }
        }
    }
}
