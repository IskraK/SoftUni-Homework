using System;
using System.Text.RegularExpressions;

namespace _06.ExtractEmails2var
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] line = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            string emailPattern = @"^[A-Za-z]+[_.-]*?[A-Za-z]+[_.-]*?[A-Za-z]+@[A-Za-z]+-?[A-Za-z]+\.[A-Za-z]+-?[A-Za-z]+(?:\.[A-Za-z]+-?[A-Za-z]+)?";
            foreach (var item in line)
            {
                Match match = Regex.Match(item, emailPattern);
                if (match.Success)
                {
                    Console.WriteLine(match.Value);
                }
            }
        }
    }
}
