using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace _4.SantaSecretHelper2var
{
    class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"@(?<name>[A-Za-z]+)[^@!:>-]*!(?<type>[GN])!";
            int key = int.Parse(Console.ReadLine());
            string message = Console.ReadLine();
            List<string> goodChildrens = new List<string>();
            while (message != "end")
            {
                StringBuilder decryptMessage = new StringBuilder();
                foreach (char letter in message)
                {
                    decryptMessage.Append((char)(letter - key));
                }

                Match match = Regex.Match(decryptMessage.ToString(), pattern);
                if (match.Success)
                {
                    if (match.Groups["type"].Value == "G")
                    {
                        goodChildrens.Add(match.Groups["name"].Value);
                    }
                }

                message = Console.ReadLine();
            }
            Console.WriteLine(String.Join(Environment.NewLine, goodChildrens));
        }
    }
}
