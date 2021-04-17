using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _02.Race
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> participants = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            Dictionary<string, int> distanceByName = new Dictionary<string, int>(participants.Count);

            string input = Console.ReadLine();

            while (input != "end of race")
            {
                StringBuilder name = new StringBuilder();
                int distance = 0;

                foreach (var symbol in input)
                {
                    if (char.IsLetter(symbol))
                    {
                        name.Append(symbol);
                    }
                    else if (char.IsDigit(symbol))
                    {
                        distance += int.Parse(symbol.ToString());
                    }
                }

                if (participants.Contains(name.ToString()))
                {
                    if (!distanceByName.ContainsKey(name.ToString()))
                    {
                        distanceByName.Add(name.ToString(), distance);
                    }
                    else
                    {
                        distanceByName[name.ToString()] += distance;
                    }
                }

                input = Console.ReadLine();
            }

            string[] place = new string[] { "1st", "2nd", "3rd" };

            List<string> output = distanceByName
                .Where(d => d.Value > 0)
                .OrderByDescending(d => d.Value)
                .Select(n => n.Key)
                .ToList();

            int minIdx = Math.Min(3, output.Count);

            for (int i = 0; i < minIdx; i++)
            {
                Console.WriteLine($"{place[i]} place: {output[i]}");
            }
        }
    }
}
