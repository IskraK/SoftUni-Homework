using System;
using System.Text;
using System.Text.RegularExpressions;

namespace _2.MessageTranslator
{
    class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"!(?<command>[A-Z][a-z]{2,})!:\[(?<textMessage>[A-Za-z]{8,})\]";

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string message = Console.ReadLine();
                Regex regex = new Regex(pattern);
                var match = regex.Match(message);

                if (match.Success)
                {
                    string text = match.Groups["textMessage"].Value;
                    int length = text.Length; 
                    StringBuilder sb = new StringBuilder();

                    for (int j = 0; j < length; j++)
                    {
                        sb.Append((int)text[j]);
                        sb.Append(' ');
                    }

                    Console.WriteLine($"{match.Groups["command"].Value}: "+sb.ToString());
                }
                else
                {
                    Console.WriteLine("The message is invalid");
                }
            }
        }
    }
}
