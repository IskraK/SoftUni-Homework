using System;
using System.Collections.Generic;

namespace _2.OddOccurrences
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] words = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);

            Dictionary<string, int> counts = new Dictionary<string, int>();

            foreach (string word in words)
            {
                string wordLowerCase = word.ToLower();

                if (counts.ContainsKey(wordLowerCase))
                {
                    counts[wordLowerCase]++;
                }
                else
                {
                    counts.Add(wordLowerCase,1);
                }
            }

            foreach (var count in counts)
            {
                if (count.Value % 2 != 0)
                {
                    Console.Write(count.Key+" ");
                }
            }
        }
    }
}
