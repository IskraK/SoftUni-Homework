using System;
using System.Text.RegularExpressions;

namespace _2.EmojiDetector
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            long coolThreshold = 1;

            foreach (char symbol in text)
            {
                if (char.IsDigit(symbol))
                {
                    coolThreshold *= int.Parse(symbol.ToString());
                }
            }

            string pattern = @"([*:])\1([A-Z][a-z]{2,})\1\1";
            Regex regex = new Regex(pattern);
            var matches = regex.Matches(text);
            Console.WriteLine($"Cool threshold: {coolThreshold}");
            Console.WriteLine($"{matches.Count} emojis found in the text. The cool ones are:");

            foreach (Match match in matches)
            {
                long coolness = 0;
                string emojiText = match.Groups[2].Value;
                foreach (char letter in emojiText)
                {
                    coolness += letter;
                }

                if (coolness > coolThreshold)
                {
                    Console.WriteLine(match.Value);
                }
            }
        }
    }
}
