using System;
using System.Text.RegularExpressions;

namespace _2.MatchPhoneNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            string pattern = @"\+359([ \-])(2)\1([0-9]{3})\1([0-9]{4})\b";
            Regex regex = new Regex(pattern);
            var matches = regex.Matches(input);

            Console.WriteLine(string.Join(", ",matches));
        }
    }
}
