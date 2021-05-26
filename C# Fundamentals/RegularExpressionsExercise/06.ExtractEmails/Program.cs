using System;
using System.Text.RegularExpressions;

namespace _06.ExtractEmails
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();

            //string pattern = @"^[A-Za-z]+[_.-]*?[A-Za-z]+[_.-]*?[A-Za-z]+@[A-Za-z]+-?[A-Za-z]+\-?[A-Za-z]+-?[A-Za-z]+(?:\.[A-Za-z]+-?[A-Za-z]+)?";

            //string pattern = @"(?<user>[^._-]\w+[._-]?\w+)@(?<host>[a-z]+\-?[a-z]+.[a-z]+\.?[a-z]+)";    75/100
            //string pattern = @"(?<user>(?:[^._-])[A-Za-z0-9]+[._-]?\w+)@(?<host>[A-Za-z]+\-?[A-Za-z]+.[A-Za-z]+\.?[A-Za-z]+)";  75/100 
            //string pattern = @"[A-Za-z0-9]+[._-]?[A-Za-z0-9]+@[A-Za-z]+[.-]?[A-Za-z]+[.-]?[A-Za-z]+\.+[A-Za-z]+-?[A-Za-z]+";    75/100
            string pattern = @"(^|(?<=\s))[A-Za-z0-9]+([._-][A-Za-z0-9]+)*@[A-Za-z]+(\-[A-Za-z]+)*(\.[A-Za-z]+)+";
            Regex regex = new Regex(pattern);
            var matches = regex.Matches(text);

            foreach (Match match in matches)
            {
                if (match.Success)
                {
                Console.WriteLine(match.Value);
                }
            }
            //100/100
        }
    }
}
