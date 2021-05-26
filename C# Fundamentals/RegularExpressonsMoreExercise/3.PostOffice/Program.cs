using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace _3.PostOffice
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine()
                .Split('|', StringSplitOptions.RemoveEmptyEntries);

            string firstPart = input[0];
            string secondPart = input[1];
            string[] thirdPart = input[2].Split(' ',StringSplitOptions.RemoveEmptyEntries);

            string firstPattern = @"([#$%&*])([A-Z]+)(\1)";
            Regex regex1 = new Regex(firstPattern);
            var firstMatche = regex1.Match(firstPart);
            string capitalLetters = firstMatche.Groups[2].Value;

            string secondPattern = @"(\d{2}):(\d{2})";
            Regex regex2 = new Regex(secondPattern);
            var secondMatches = regex2.Matches(secondPart);

            Dictionary<char, int> firstLetterAndLength = new Dictionary<char, int>();

            foreach (Match match in secondMatches)
            {
                char capitalLetter = (char)int.Parse(match.Groups[1].Value);
                int length = int.Parse(match.Groups[2].Value) + 1;
                if (capitalLetters.Contains(capitalLetter) && !firstLetterAndLength.ContainsKey(capitalLetter))
                {
                    firstLetterAndLength.Add(capitalLetter, length);
                }
            }

            foreach (char letter in capitalLetters)
            {
                foreach (var word in thirdPart)
                {
                    if (word[0] == letter && word.Length == firstLetterAndLength[letter])
                    {
                        Console.WriteLine(word);
                    }
                }
            }
        }
    }
}
