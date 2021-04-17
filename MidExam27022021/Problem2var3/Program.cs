using System;
using System.Collections.Generic;
using System.Linq;

namespace Problem2var3
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> elements = Console.ReadLine()
                .Split()
                .ToList();

            while (true)
            {
                string[] line = Console.ReadLine().Split();

                if (line[0] == "end")
                {
                    break;
                }

                if (line[0] == "reverse")
                {
                    int startIdx = int.Parse(line[2]);
                    int count = int.Parse(line[4]);

                    List<string> reversed = new List<string>(count);

                    for (int i = startIdx; i < startIdx + count; i++)
                    {
                        reversed.Add(elements[i]);
                    }

                    reversed.Reverse();

                    elements.RemoveRange(startIdx, count);
                    elements.InsertRange(startIdx, reversed);
                }
                else if (line[0] == "sort")
                {
                    int startIdx = int.Parse(line[2]);
                    int count = int.Parse(line[4]);

                    List<string> sorted = new List<string>(count);

                    for (int i = startIdx; i < startIdx + count; i++)
                    {
                        sorted.Add(elements[i]);
                    }

                    sorted.Sort();

                    elements.RemoveRange(startIdx, count);
                    elements.InsertRange(startIdx, sorted);
                }
                else
                {
                    int count = int.Parse(line[1]);

                    elements.RemoveRange(0, count);
                }
            }

            Console.WriteLine(String.Join(", ", elements));
        }
    }
}
