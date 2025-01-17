﻿using System;

namespace Moving
{
    class Program
    {
        static void Main(string[] args)
        {
            int a = int.Parse(Console.ReadLine());
            int b = int.Parse(Console.ReadLine());
            int c = int.Parse(Console.ReadLine());
            int volume = a * b * c;
            bool hasSpace = true;
            string input = Console.ReadLine();
            while (hasSpace && input != "Done")
            {
                int boxes = int.Parse(input);
                volume -= boxes;
                if (volume < 0)
                {
                    hasSpace = false;
                    break;
                }

                input = Console.ReadLine();
            }

            if (hasSpace)
            {
                Console.WriteLine($"{volume} Cubic meters left.");
            }
            else
            {
                Console.WriteLine($"No more free space! You need {Math.Abs(volume)} Cubic meters more.");
            }
        }
    }
}
