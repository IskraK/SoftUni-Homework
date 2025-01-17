﻿using System;

namespace Walking
{
    class Program
    {
        static void Main(string[] args)
        {
            int target = 10000;
            int totalSteps = 0;
            while (totalSteps < target)
            {
                string input = Console.ReadLine();
                if (input == "Going home")
                {
                    int stepsToHome = int.Parse(Console.ReadLine());
                    totalSteps += stepsToHome;
                    break;
                }
                else
                {
                    int steps = int.Parse(input);
                    totalSteps += steps;
                }
            }
            if (totalSteps >= target)
            {
                int stepsOver = totalSteps - target;
                Console.WriteLine($"Goal reached! Good job!");
                Console.WriteLine($"{stepsOver} steps over the goal!");
            }
            else
            {
                int stepsNeeded = target - totalSteps;
                Console.WriteLine($"{stepsNeeded} more steps to reach goal.");
            }
        }
    }
}
