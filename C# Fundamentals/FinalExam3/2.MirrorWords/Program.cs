using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace _2.MirrorWords
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            string pattern = @"([@#])([A-Za-z]{3,})\1{2}([A-Za-z]{3,})\1";
            Regex regex = new Regex(pattern);
            var matches = regex.Matches(text);

            if (matches.Count == 0)
            {
                Console.WriteLine($"No word pairs found!");
            }
            else
            {
                Console.WriteLine($"{matches.Count} word pairs found!");
            }

            List<string> mirrorPairs = new List<string>();

            foreach (Match match in matches)
            {
                string first = match.Groups[2].Value;
                string second = match.Groups[3].Value;
                string reversedSecond = new string(second.ToCharArray().Reverse().ToArray());
                if (first == reversedSecond)
                {
                    mirrorPairs.Add(first+" <=> "+second);
                }
            }

            if (mirrorPairs.Count == 0)
            {
                Console.WriteLine($"No mirror words!");
            }
            else
            {
                Console.WriteLine($"The mirror words are:");
                Console.WriteLine(string.Join(", ",mirrorPairs));
            }
        }
    }
}
