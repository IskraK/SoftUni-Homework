using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace _03.WordCount
{
    class Program
    {
        static void Main(string[] args)
        {
            string words = File.ReadAllText("../../../words.txt");
            string[] wordsLine = words.Split().ToArray();
            string text = File.ReadAllText("../../../text.txt");
            string[] textLines = text.Split(new char[] { ' ', ',', '.', '-', '?', '!' }, StringSplitOptions.RemoveEmptyEntries);
            Dictionary<string, int> wordsInText = new Dictionary<string, int>(wordsLine.Length);

            for (int i = 0; i < wordsLine.Length; i++)
            {
                if (!wordsInText.ContainsKey(wordsLine[i]))
                {
                    wordsInText.Add(wordsLine[i], 0);
                }

                for (int j = 0; j < textLines.Length; j++)
                {
                    if (textLines[j].ToLower() == wordsLine[i])
                    {
                        wordsInText[wordsLine[i]] += 1;
                    }
                }
            }

            wordsInText = wordsInText.OrderByDescending(x => x.Value).ToDictionary(x => x.Key, y => y.Value);

            foreach (var word in wordsInText)
            {
                Console.WriteLine($"{word.Key} - {word.Value}");
                string[] result = new string[] { $"{word.Key} - {word.Value}" };
                File.AppendAllLines("../../../output.txt", result);
            }

        }
    }
}
