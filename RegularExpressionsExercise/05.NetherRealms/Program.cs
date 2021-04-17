using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace _05.NetherRealms
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] demonNames = Console.ReadLine()
                .Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);

            Dictionary<string, List<double>> demons = new Dictionary<string, List<double>>(demonNames.Length);

            foreach (var item in demonNames)
            {
                demons.Add(item, new List<double>(2));
            }

            string patternDigit = @"[+-]?(?:(?:\d+\.\d+)|(?:\d+))";
            //string patternDigit = @"(?<digit>[+-]?\d*\.?\d*)?";

            for (int i = 0; i < demonNames.Length; i++)
            {
                int health = 0;
                double damage = 0;
                foreach (var symbol in demonNames[i])
                {
                    if (!char.IsDigit(symbol) && symbol != '+' && symbol != '-' && symbol != '*' && symbol != '/' && symbol != '.')
                    {
                        health += symbol;
                    }

                }

                Regex regex = new Regex(patternDigit);

                var matchDigits = regex.Matches(demonNames[i]);
                foreach (Match match in matchDigits)
                {
                    damage += double.Parse(match.Value);
                }

                foreach (var item in demonNames[i])
                {
                    if (item == '*')
                    {
                        damage *= 2;
                    }
                    else if (item == '/')
                    {
                        damage /= 2;
                    }
                }

                demons[demonNames[i]].Add(health);
                demons[demonNames[i]].Add(damage);
            }

            demons = demons
                .OrderBy(x => x.Key)
                .ToDictionary(x => x.Key, y => y.Value);

            foreach (var item in demons)
            {
                Console.WriteLine($"{item.Key} - {item.Value[0]} health, {item.Value[1]:f2} damage");
            }
        }
    }
}
