using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace _04.StarEnigma
{
    class Program
    {
        static void Main(string[] args)
        {
            const string searchedLetters = "SsTtAaRr";

            List<string> attackedPlanets = new List<string>();
            List<string> destroyedPlanets = new List<string>();

            int numberOfmessages = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfmessages; i++)
            {
                string message = Console.ReadLine();
                StringBuilder encryptedMessage = new StringBuilder();
                int key = 0;

                foreach (var symbol in message)
                {
                    if (searchedLetters.Contains(symbol))
                    {
                        key++;
                    }
                }

                for (int j = 0; j < message.Length; j++)
                {
                    encryptedMessage.Append((char)(message[j] - key));
                }

                string pattern = @"(?:[^@\-!:>]*)?(?:@(?<planetName>[A-Z][a-z]+))(?:[^@\-!:>]*)?(?:\:(?<population>\d+))(?:[^@\-!:>]*)?(?:!(?<attackType>[AD]{1})!)(?:[^@\-!:>]*)?(?:->(?<soldierCount>\d+))(?:[^@\-!:>]*)?";
                //string pattern = @"^[^@:!>-]*?@[^@:!>-]*?(?<name>[A-Za-z]+)[^@:!>-]*?:[^@:!>-]*?(?<population>\d+)[^@:!>-]*?![^@:!>-]*?(?<atackType>[AD])[^@:!>-]*?![^@:!>-]*?->[^@:!>-]*?(?<count>\d+)[^@:!>-]*?$";
                Regex regex = new Regex(pattern);

                if (regex.IsMatch(encryptedMessage.ToString()))
                {
                    string planetName = regex.Match(encryptedMessage.ToString()).Groups["planetName"].Value;
                    char attackedType = char.Parse(regex.Match(encryptedMessage.ToString()).Groups["attackType"].Value);
                    if (attackedType == 'A')
                    {
                        attackedPlanets.Add(planetName);
                    }
                    else
                    {
                        destroyedPlanets.Add(planetName);
                    }
                }
            }

            attackedPlanets = attackedPlanets
                .OrderBy(n => n)
                .ToList();
            destroyedPlanets = destroyedPlanets
                .OrderBy(n => n)
                .ToList();

            Console.WriteLine($"Attacked planets: {attackedPlanets.Count}");
            if (attackedPlanets.Count != 0)
            {
                foreach (var item in attackedPlanets)
                {
                    Console.WriteLine($"-> {item}");
                }
            }

            Console.WriteLine($"Destroyed planets: {destroyedPlanets.Count}");
            if (destroyedPlanets.Count != 0)
            {
                foreach (var item in destroyedPlanets)
                {
                    Console.WriteLine($"-> {item}");
                }
            }
        }
    }
}
