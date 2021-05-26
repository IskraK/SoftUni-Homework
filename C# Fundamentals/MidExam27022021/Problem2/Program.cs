using System;
using System.Collections.Generic;
using System.Linq;

namespace Problem2
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
                        List<string> temp = elements;
                        temp.RemoveRange(0, startIdx-1);
                        temp.RemoveRange(startIdx+count, elements.Count-startIdx-count);
                        string[] result=temp.ToArray();
                        elements.RemoveRange(startIdx, count);
                        elements.Insert(startIdx,result.Reverse().ToString());
                        break;
                    case "sort":
                         startIdx = int.Parse(line[2]);
                         count = int.Parse(line[4]);
                         temp = elements;
                        temp.RemoveRange(0, startIdx - 1);
                        temp.RemoveRange(startIdx +count, elements.Count-startIdx-count);
                        result = temp.OrderByDescending(n => n).ToArray();
                        elements.RemoveRange(startIdx, count);
                        elements.Insert(startIdx, result.ToString());
                        break;
                    case "remove":
                        elements.RemoveRange(0, int.Parse(line[1]));
                        break;
                    default:
                        break;
                }

                input = Console.ReadLine();
            }

            Console.WriteLine(string.Join(", ",elements));
        }
    }
}
