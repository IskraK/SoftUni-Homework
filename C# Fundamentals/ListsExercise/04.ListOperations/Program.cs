using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.ListOperations
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
                //•	Add { number} – add number at the end.
                //•	Insert { number} { index} – insert number at given index.
                //•	Remove { index} – remove at index.
                //•	Shift left { count} – first number becomes last ‘count’ times.
                //•	Shift right { count} – last number becomes first ‘count’ times.
                //Note: there is a possibility that the given index is outside of the bounds of the array.In that case print "Invalid index"

                switch (command[0].ToLower())
                {
                    case "add":
                        numbers.Add(int.Parse(command[1]));
                        break;
                    case "insert":
                        if (int.Parse(command[2]) < 0 || int.Parse(command[2]) >= numbers.Count)
                        {
                            Console.WriteLine("Invalid index");
                            break;
                        }
                        numbers.Insert(int.Parse(command[2]), int.Parse(command[1]));
                        break;
                    case "remove":
                        if (int.Parse(command[1]) < 0 || int.Parse(command[1]) >= numbers.Count)
                        {
                            Console.WriteLine("Invalid index");
                            break;
                        }
                        //numbers.Remove(numbers[int.Parse(command[1])]);
                        numbers.RemoveAt(int.Parse(command[1]));
                        break;
                    case "shift":
                        if (command[1] == "left")
                        {
                            for (int i = 0; i < int.Parse(command[2]); i++)
                            {
                                numbers.Add(numbers[0]);
                                numbers.Remove(numbers[0]);
                            }
                        }
                        else if (command[1] == "right")
                        {
                            for (int i = 0; i < int.Parse(command[2]); i++)
                            {
                                numbers.Insert(0, numbers[numbers.Count - 1]);
                                numbers.RemoveAt(numbers.Count - 1);
                            }

                        }
                        break;
                    default:
                        break;
                }
                command = Console.ReadLine().Split();
            }

            Console.WriteLine(string.Join(" ", numbers));
        }
    }
}
