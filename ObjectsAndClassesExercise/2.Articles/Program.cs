using System;
using System.Linq;

namespace _2.Articles
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries);

            int numCommands = int.Parse(Console.ReadLine());

            string[] commands = new string[numCommands];

            for (int i = 0; i < numCommands; i++)
            {
                commands[i]=Console.ReadLine();
                string[] currCommand = commands[i]
                    .Split(": ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                switch (currCommand[0])
                {
                    case "Edit":
                        input[1] = currCommand[1];
                        break;
                    case "ChangeAuthor":
                        input[2] = currCommand[1];
                        break;
                    case "Rename":
                        input[0] = currCommand[1];
                        break;
                    default:
                        break;
                }
            }
            Console.WriteLine($"{input[0]} - {input[1]}: {input[2]}");
        }
    }
}
