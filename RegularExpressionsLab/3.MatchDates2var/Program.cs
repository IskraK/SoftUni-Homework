using System;
using System.Text.RegularExpressions;

namespace _3.MatchDates2var
{
    class Program
    {
        static void Main(string[] args)
        {
            string dates = Console.ReadLine();
            string pattern = @"\b(?<day>(?:[0-2][0-9])|(?:3[01]))([-.\/])(?<month>[A-Z][a-z]{2})\1(?<year>[0-9]{4})\b";
            Regex regex = new Regex(pattern);
            var matches = regex.Matches(dates);

            foreach (Match match in matches)
            {
                Console.WriteLine($"Day: {match.Groups["day"]}, Month: {match.Groups["month"]}, Year: {match.Groups["year"]}");
            }
        }
    }
}
