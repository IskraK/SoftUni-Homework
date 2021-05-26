using System;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace _2.RageQuit
{
    class Program
    {
        static void Main(string[] args)
        {
            string line = Console.ReadLine().ToUpper();
            string pattern = @"(\D+)(\d{1,2})";
            Regex regex = new Regex(pattern);
            StringBuilder result = new StringBuilder(100000);
            var matches = regex.Matches(line);
            foreach (Match match in matches)
            {
                int count = int.Parse(match.Groups[2].Value);
                for (int i = 0; i < count; i++)
                {
                    result.Append(match.Groups[1].ToString());
                }
            }

            Console.WriteLine($"Unique symbols used: {result.ToString().Distinct().Count()}");
            Console.WriteLine(result);
        }
    }
}
