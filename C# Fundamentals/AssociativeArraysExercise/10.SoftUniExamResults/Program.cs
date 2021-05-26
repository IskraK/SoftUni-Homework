using System;
using System.Collections.Generic;
using System.Linq;

namespace _10.SoftUniExamResults
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> pointsByName = new Dictionary<string, int>();
            List<string> languages = new List<string>();

            string input = Console.ReadLine();

            while (input != "exam finished")
            {
                string[] parts = input.Split("-", StringSplitOptions.RemoveEmptyEntries);
                string name = parts[0];

                if (parts[1] != "banned")
                {
                    string language = parts[1];
                    int points = int.Parse(parts[2]);
                    languages.Add(language);

                    if (!pointsByName.ContainsKey(name))
                    {
                        pointsByName[name] = points;
                    }
                    else
                    {
                        if (pointsByName[name] < points)
                        {
                            pointsByName[name] = points;
                        }
                    }
                }
                else
                {
                    pointsByName.Remove(name);
                }

                input = Console.ReadLine();
            }

            Dictionary<string, int> sortedResults = pointsByName
                .OrderByDescending(p => p.Value)
                .ThenBy(p => p.Key)
                .ToDictionary(x => x.Key, x => x.Value);

            Console.WriteLine("Results:");
            foreach (var student in sortedResults)
            {
                Console.WriteLine($"{student.Key} | {student.Value}");
            }

            SortedDictionary<string, int> sortedLanguages = new SortedDictionary<string, int>();

            foreach (var item in languages)
            {
                if (sortedLanguages.ContainsKey(item))
                {
                    sortedLanguages[item]++;
                }
                else
                {
                    sortedLanguages.Add(item, 1);
                }
            }

            Console.WriteLine("Submissions:");
            foreach (var item in sortedLanguages.OrderByDescending(p => p.Value))
            {
                Console.WriteLine($"{item.Key} - {item.Value}");
            }
        }
    }
}
