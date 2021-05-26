using System;
using System.Collections.Generic;
using System.Linq;

namespace _1.RandomizeWords
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> words = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            Random rnd = new Random();

            for (int i = 0; i < words.Count; i++)
            {
                int idx = rnd.Next(0, words.Count);
                string word = words[i];
                words[i] = words[idx];
                words[idx] = word;
            }

            Console.WriteLine(string.Join(Environment.NewLine,words));
        }
    }
}
