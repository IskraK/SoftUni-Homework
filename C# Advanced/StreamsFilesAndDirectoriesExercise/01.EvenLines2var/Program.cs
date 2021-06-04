using System;
using System.IO;
using System.Linq;
using System.Text;

namespace _01.EvenLines2var
{
    class Program
    {
        static void Main(string[] args)
        {
            char[] charsToReplace = { '-', '.',',', '!', '?' };
            StreamReader streamReader = new StreamReader("text.txt");
            int count = 0;

            while (!streamReader.EndOfStream)
            {
                string line = streamReader.ReadLine();

                if (line == null)
                {
                    break;
                }

                if (count % 2 == 0)
                {
                    line = ReplaceAll(charsToReplace, '@', line);
                    line = ReverseWordsInText(line);
                    Console.WriteLine(line);
                }

                count++;
            }
        }

        private static string ReverseWordsInText(string line)
        {
            string[] words = line.Split(' ', StringSplitOptions.RemoveEmptyEntries).ToArray();
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < words.Length; i++)
            {
                sb.Append(words[words.Length - i - 1]);
                sb.Append(' ');
            }
            return sb.ToString().TrimEnd();
        }

        private static string ReplaceAll(char[] charsToReplace, char replacement, string line)
        {
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < line.Length; i++)
            {
                char currSymbol = line[i];

                if (charsToReplace.Contains(currSymbol))
                {
                    sb.Append('@');
                }
                else
                {
                    sb.Append(currSymbol);
                }
            }
            return sb.ToString().TrimEnd();
        }
    }
}
