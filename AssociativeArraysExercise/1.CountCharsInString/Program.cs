using System;
using System.Collections.Generic;
using System.Linq;

namespace _1.CountCharsInString
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine()
                .Replace(" ", "");
                

            Dictionary<char, int> counts = new Dictionary<char, int>();

            foreach (var symbol in text)
            {
                if (counts.ContainsKey(symbol))
                {
                    counts[symbol]++;
                }
                else
                {
                    counts.Add(symbol, 1);
                }
            }

            foreach (var symbol  in counts)
            {
                Console.WriteLine($"{symbol.Key} -> {symbol.Value}");
            }
        }
    }
}
