using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace _4.SantaSecretHelper
{
    class Program
    {
        static void Main(string[] args)
        {
            int key = int.Parse(Console.ReadLine());
            string line = Console.ReadLine();
            List<string> goodChildren = new List<string>();

            while (line != "end")
            {
                StringBuilder message = new StringBuilder();

                foreach (var symbol in line)
                {
                    char ch = (char)(symbol - key);
                    message.Append(ch);
                }

                string patternName = @"@([A-Z][a-z]+)";
                string patternBehaviour = @"!([GN])!";

                Regex nameReg = new Regex(patternName);
                Regex behaviourReg = new Regex(patternBehaviour);
                var matchName = nameReg.Match(message.ToString());
                var matchBehaviour = behaviourReg.Match(message.ToString());

                if (matchName.Success && matchBehaviour.Success)
                {
                    if (matchBehaviour.Groups[1].Value == "G")
                    {
                        goodChildren.Add(matchName.Groups[1].Value);
                    }
                }

                line = Console.ReadLine();
            }

            Console.WriteLine(string.Join("\n",goodChildren));
            // 33/100 Не е изпълнено условието - The order in the message should be: child’s name -> child’s behavior ??? -> общ Regex
        }
    }
}
