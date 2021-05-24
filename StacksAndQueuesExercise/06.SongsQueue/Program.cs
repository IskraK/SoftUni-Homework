using System;
using System.Collections.Generic;
using System.Linq;

namespace _06.SongsQueue
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            Queue<string> songs = new Queue<string>(input);

            string commandLine = Console.ReadLine();

            while (songs.Count > 0)
            {
                switch (commandLine[0])
                {
                    case 'P':
                        songs.Dequeue();
                        break;
                    case 'A':
                        string song = commandLine.Substring(4);

                        if (songs.Contains(song))
                        {
                            Console.WriteLine($"{song} is already contained!");
                        }
                        else
                        {
                            songs.Enqueue(song);
                        }
                        break;
                    case 'S':
                        Console.WriteLine(string.Join(", ", songs));
                        break;
                    default:
                        break;
                }

                commandLine = Console.ReadLine();
            }

            Console.WriteLine("No more songs!");
        }
    }
}
