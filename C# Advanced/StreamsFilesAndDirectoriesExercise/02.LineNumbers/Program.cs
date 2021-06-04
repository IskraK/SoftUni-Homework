using System;
using System.IO;
using System.Threading.Tasks;

namespace _02.LineNumbers
{
    class Program
    {
        static async Task Main(string[] args)
        {
            string punctuationMarks = "-.,!?'";

            string[] lines = await File.ReadAllLinesAsync("text.txt");

            for (int i = 0; i < lines.Length; i++)
            {
                int countLetters = 0;
                int countPunctuationMars = 0;

                string currLine = lines[i];

                for (int j = 0; j < currLine.Length; j++)
                {
                    if (char.IsLetter(currLine[j]))
                    {
                        countLetters++;
                    }

                    if (punctuationMarks.Contains(currLine[j]))
                    {
                        countPunctuationMars++;
                    }
                }

                lines[i] = $"Line {i + 1}:{lines[i]} ({countLetters})({countPunctuationMars})";
            }

            await File.WriteAllLinesAsync("../../../output.txt", lines);
        }
    }
}
