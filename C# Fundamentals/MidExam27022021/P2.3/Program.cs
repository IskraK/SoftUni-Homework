using System;
using System.Collections.Generic;
using System.Linq;

namespace P2._3
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> parts = Console.ReadLine()
                .Split('|', StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            string input = Console.ReadLine();

            while (input != "Done")
            {
                string[] line = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string command = line[1];

                switch (command)
                {
                    case "Left":
                        int index = int.Parse(line[2]);

                        if (index > 0 && index <parts.Count)
                        {
                            string temp = parts[index-1];
                            parts[index - 1] = parts[index];
                            parts[index] = temp;
                        }
                        break;
                    case "Right":
                        index = int.Parse(line[2]);

                        if (index >= 0 && index < parts.Count-1)
                        {
                            string temp = parts[index + 1];
                            parts[index + 1] = parts[index];
                            parts[index] = temp;
                        }
                        break;
                    case "Even":
                        for (int i = 0; i < parts.Count; i++)
                        {
                            if (i % 2 == 0)
                            {
                                Console.Write($"{parts[i]} ");
                            }
                            Console.WriteLine();
                        }
                        break;
                    case "Odd":
                        for (int i = 0; i < parts.Count; i++)
                        {
                            if (i % 2 != 0)
                            {
                                Console.Write($"{parts[i]} ");
                            }
                            Console.WriteLine();
                        }
                        break;
                    default:
                        break;
                }

                input = Console.ReadLine();
            }

            //Console.Write("You crafted ");
            //Console.Write(string.Join("",parts));
            //Console.WriteLine("!");

            string weaponName = string.Join("", parts);
            Console.WriteLine($"You crafted {weaponName}!");
        }
    }
}
