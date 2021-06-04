using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _03.WordCount
{
    class Program
    {
        static async Task Main(string[] args)
        {
            string[] words = await File.ReadAllLinesAsync("words.txt");
            //string lines = await File.ReadAllTextAsync("text.txt").ToLower();   ////Не приема ToLower() , когато е async
            string lines = File.ReadAllText("text.txt").ToLower();
            string[] allWords= Regex.Split(lines, @"[^A-Za-z]").Where(s => s.Length != 0).ToArray();

            Dictionary<string, int> countWords = new Dictionary<string, int>();

            foreach (var word in words)
            {
                if (!countWords.ContainsKey(word))
                {
                    countWords.Add(word, 0);
                }
            }

            foreach (var word in allWords)
            {
                if (countWords.ContainsKey(word))
                {
                    countWords[word]++;
                }
            }

            var sortedCountWords = countWords.OrderByDescending(n => n.Value).ToDictionary(x => x.Key, y => y.Value);

            List<string> output = new List<string>();

            foreach (var word in sortedCountWords)
            {
                string result = $"{word.Key} - {word.Value}";
                output.Add(result);
            }

            await File.WriteAllLinesAsync("../../../actualResult.txt", output);
        }
    }
}
