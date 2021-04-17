using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace _2.DestinationMapper
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            string pattern = @"([=/])([A-Z][A-Za-z]{2,})\1";
            Regex regex = new Regex(pattern);
            var matches = regex.Matches(input);
            int travelPoints = 0;
            foreach (Match match in matches)
            {
                travelPoints += match.Groups[2].Value.Length;
            }

            List<string> destinations = new List<string>(matches.Count);
            foreach (Match match in matches)
            {
                destinations.Add(match.Groups[2].Value);
            }
            Console.Write("Destinations: ");
            Console.WriteLine(string.Join(", ",destinations));
            Console.WriteLine($"Travel Points: {travelPoints}");
        }
    }
}
