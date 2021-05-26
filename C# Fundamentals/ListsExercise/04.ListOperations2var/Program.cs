using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.ListOperations2var
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().Split().Select(int.Parse).ToList();

            string input = Console.ReadLine();
            while (input != "End")
            {
                string[] command = input.Split();
                switch (command[0])
                {
                    case "Add":
                        numbers.Add(int.Parse(command[1]));
                        break;
                    case "Insert":
                        int index = int.Parse(command[2]);
                        if (index < 0 || index >= numbers.Count)
                        {
                            Console.WriteLine("Invalid index");
                            break;
                        }
                        numbers.Insert(index, int.Parse(command[1]));
                        break;
                    case "Remove":
                        index = int.Parse(command[1]);
                        if (index < 0 || index >= numbers.Count)
                        {
                            Console.WriteLine("Invalid index");
                            break;
                        }
                        numbers.RemoveAt(index);
                        break;
                    case "Shift":
                        for (int i = 0; i < int.Parse(command[2]); i++)
                        {
                            MoveListLeftOrRight(numbers, command[1]);
                        }
                        break;
                    default:
                        break;
                }

                input = Console.ReadLine();
            }

            Console.WriteLine(string.Join(" ", numbers));
        }

        private static void MoveListLeftOrRight(List<int> numbers, string leftOrRight)
        {
            if (leftOrRight == "left")
            {
                int firstElement = numbers[0];
                numbers.RemoveAt(0);
                numbers.Add(firstElement);
            }
            else
            {
                int lastElement = numbers[numbers.Count - 1];
                numbers.RemoveAt(numbers.Count - 1);
                numbers.Insert(0, lastElement);
            }
        }
    }
}
