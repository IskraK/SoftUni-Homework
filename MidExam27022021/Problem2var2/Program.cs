using System;
using System.Collections.Generic;
using System.Linq;

namespace Problem2var2
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> elements = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            string input = Console.ReadLine();

            while (input != "end")
            {
                string[] line = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string command = line[0];
                switch (command)
                {
                    case "reverse":
                        int startIdx = int.Parse(line[2]);
                        int count = int.Parse(line[4]);
                        List<string> reversed = new List<string>(count);
                        for (int i = startIdx; i < startIdx+count; i++)
                        {
                            reversed.Add(elements[i]);
                        }

                        reversed.Reverse();

                        elements.RemoveRange(startIdx, count);
                        elements.InsertRange(startIdx, reversed);
                        break;
                    case "sort":
                        startIdx = int.Parse(line[2]);
                        count = int.Parse(line[4]);
                        List<string> sorted = new List<string>(count);

                        for (int i = startIdx; i < startIdx+count; i++)
                        {
                            sorted.Add(elements[i]);
                        }

                        sorted.Sort();
                        elements.RemoveRange(startIdx, count);
                        elements.InsertRange(startIdx, sorted);
                        break;
                    case "remove":
                        elements.RemoveRange(0, int.Parse(line[1]));
                        break;
                    default:
                        break;
                }

                input = Console.ReadLine();
            }

            Console.WriteLine(string.Join(", ", elements));
        }
    }
}
