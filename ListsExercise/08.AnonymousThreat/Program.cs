using System;
using System.Collections.Generic;
using System.Linq;

namespace _08.AnonymousThreat
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> data = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            string input = Console.ReadLine();

            while (input != "3:1")
            {
                string[] commands = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                switch (commands[0])
                {
                    case "merge":
                        int startIdx = int.Parse(commands[1]);
                        int endIdx = int.Parse(commands[2]);

                        if (startIdx >= data.Count || endIdx < 0)
                        {
                            continue;
                        }
                        if (startIdx < 0)
                        {
                            startIdx = 0;
                        }
                        if (endIdx >= data.Count)
                        {
                            endIdx = data.Count - 1;
                        }

                        string merged = string.Empty;

                        for (int i = startIdx; i <= endIdx; i++)
                        {
                            string elements = data[i];
                            merged += elements;
                        }

                        data.RemoveRange(startIdx, endIdx - startIdx + 1);
                        data.Insert(startIdx, merged);
                        break;
                    case "divide":
                        int index = int.Parse(commands[1]);
                        int partitions = int.Parse(commands[2]);
                        string element = data[index];
                        data.RemoveAt(index);
                        int partitionSize = element.Length / partitions;

                        List<string> substrings = new List<string>();

                        for (int i = 0; i < partitions - 1; i++)
                        {
                            string substring = element.Substring(i * partitionSize, partitionSize);
                            substrings.Add(substring);
                        }

                        string lastSubstring = element.Substring((partitions - 1) * partitionSize);
                        substrings.Add(lastSubstring);
                        data.InsertRange(index, substrings);
                        break;
                    default:
                        break;
                }

                input = Console.ReadLine();
            }

            Console.WriteLine(string.Join(" ", data));
        }
    }
}
