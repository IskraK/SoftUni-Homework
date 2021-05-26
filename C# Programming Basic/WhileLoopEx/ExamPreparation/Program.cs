using System;

namespace ExamPreparation
{
    class Program
    {
        static void Main(string[] args)
        {
            int poorMarksLimit = int.Parse(Console.ReadLine());
            int poorMarksCounter = 0;
            int marksCounter = 0;
            int marksSum = 0;
            bool isPerfect = true;
            string task = Console.ReadLine();
            string lastTask = " ";
            while (task != "Enough")
            {
                lastTask = task;
                int mark = int.Parse(Console.ReadLine());
                marksCounter++;
                marksSum += mark;
                if (mark <= 4)
                {
                    poorMarksCounter++;
                    if (poorMarksCounter >= poorMarksLimit)
                    {
                        isPerfect = false;
                        break;
                    }
                }
                task = Console.ReadLine();
            }
            double avgMark = 1.0 * marksSum / marksCounter;
            if (isPerfect)
            {
                Console.WriteLine($"Average score: {avgMark:f2}");
                Console.WriteLine($"Number of problems: {marksCounter}");
                Console.WriteLine($"Last problem: {lastTask}");
            }
            else
            {
                Console.WriteLine($"You need a break, {poorMarksCounter} poor grades.");
            }
        }
    }
}
