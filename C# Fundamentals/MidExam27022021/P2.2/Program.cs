using System;
using System.Collections.Generic;
using System.Linq;

namespace P2._2
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> cubes = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();
            string input = Console.ReadLine();

            while (input != "Mort")
            {
                string[] line = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string command = line[0];
                int value = int.Parse(line[1]);

                switch (command)
                {
                    case "Add":
                        cubes.Add(value);
                        break;
                    case "Remove":
                        cubes.Remove(value);
                        break;
                    case "Replace":
                        int replacement = int.Parse(line[2]);
                        int idx = cubes.IndexOf(value);
                        cubes.RemoveAt(idx);
                        cubes.Insert(idx, replacement);
                        break;
                    case "Collapse":
                        for (int i = 0; i < cubes.Count; i++)
                        {
                            if (cubes[i] < value)
                            {
                                cubes.Remove(cubes[i]);
                                i--;
                            }
                        }
                        break;
                    default:
                        break;
                }

                input = Console.ReadLine();
            }

            Console.WriteLine(string.Join(" ",cubes));
        }
    }
}
