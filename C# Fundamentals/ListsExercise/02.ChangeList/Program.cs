using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.ChangeList
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            string[] command = Console.ReadLine().Split();

            while (command[0].ToLower() != "end")
            {
                switch (command[0].ToLower())
                {
                    case "delete":
                        int element = int.Parse(command[1]);

                        for (int i = 0; i < numbers.Count; i++)
                        {
                            if (numbers[i] == int.Parse(command[1]))
                            {
                                numbers.RemoveAt(i);
                            }
                        }
                        break;
                    case "insert":
                        numbers.Insert(int.Parse(command[2]), int.Parse(command[1]));
                        break;
                    default:
                        break;
                }

                command = Console.ReadLine().Split();
            }

            Console.WriteLine(string.Join(" ",numbers));
        }
    }
}
