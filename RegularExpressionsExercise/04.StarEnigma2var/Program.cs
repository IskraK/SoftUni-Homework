using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace _04.StarEnigma2var
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Planet> planets = new List<Planet>();
            string pattern = @"^[^@:!>-]*?@[^@:!>-]*?(?<name>[A-Za-z]+)[^@:!>-]*?:[^@:!>-]*?(?<population>\d+)[^@:!>-]*?![^@:!>-]*?(?<atackType>[AD])[^@:!>-]*?![^@:!>-]*?->[^@:!>-]*?(?<count>\d+)[^@:!>-]*?$";
            int number = int.Parse(Console.ReadLine());
            for (int i = 0; i < number; i++)
            {
                string currLine = Console.ReadLine();
                currLine = EncryptMessage(currLine);

                Match match = Regex.Match(currLine, pattern);
                if (match.Success)
                {
                    Planet planet = new Planet(match.Groups["name"].Value,
                                               int.Parse(match.Groups["population"].Value),
                                               match.Groups["atackType"].Value[0],
                                               int.Parse(match.Groups["count"].Value));
                    planets.Add(planet);
                }
            }

            Console.WriteLine($"Attacked planets: {Planet.PlanetCount(planets, 'A')}");
            foreach (var planet in planets.Where(a => a.AtackType == 'A').OrderBy(n => n.Name))
            {
                Console.WriteLine($"-> {planet.Name}");
            }

            Console.WriteLine($"Destroyed planets: {Planet.PlanetCount(planets, 'D')}");
            foreach (var planet in planets.Where(a => a.AtackType == 'D').OrderBy(n => n.Name))
            {
                Console.WriteLine($"-> {planet.Name}");
            }
        }

        private static string EncryptMessage(string currLine)
        {
            long key = currLine.ToLower().LongCount(x => x == 's' || x == 't' || x == 'a' || x == 'r');
            StringBuilder encryptedLine = new StringBuilder();
            currLine.ToCharArray().ToList().ForEach(x => encryptedLine.Append((char)((int)x - key)));
            return encryptedLine.ToString();
        }

        private class Planet
        {
            public string Name { get; set; }
            public int Population { get; set; }
            public char AtackType { get; set; }
            public int SoldiersCount { get; set; }
            public Planet(string name, int population, char atackType, int count)
            {
                Name = name;
                Population = population;
                AtackType = atackType;
                SoldiersCount = count;
            }

            internal static int PlanetCount(List<Planet> planets, char v)
            {
                return planets.Where(a => a.AtackType == v).Count();
            }
        }
    }
}
