using System;
using System.Text.RegularExpressions;

namespace _1.ValidUsernames2varRegex
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries);

            string pattern = @"^([A-Za-z0-9_-]{3,16})$";

            Regex regex = new Regex(pattern);

            foreach (string item in input)
            {
                var match = regex.Match(item);
                if (match.Success)
                {
                    Console.WriteLine(match);
                }
            }
        }
    }
}
