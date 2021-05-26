using System;
using System.Text;
using System.Text.RegularExpressions;

namespace Problem2
{
    class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"^([$%])([A-Z][a-z]{2,})\1\:[\s]\[(\d+)\]\|\[(\d+)\]\|\[(\d+)\]\|$";

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string message = Console.ReadLine();
                Regex regex = new Regex(pattern);
                var match = regex.Match(message);
                if (match.Success)
                {
                    StringBuilder decryptedMessage = new StringBuilder();
                    decryptedMessage.Append((char)int.Parse(match.Groups[3].Value));
                    decryptedMessage.Append((char)int.Parse(match.Groups[4].Value));
                    decryptedMessage.Append((char)int.Parse(match.Groups[5].Value));
                    
                    Console.WriteLine($"{match.Groups[2].Value}: {decryptedMessage}");
                }
                else
                {
                    Console.WriteLine("Valid message not found!");
                }
            }
        }
    }
}
