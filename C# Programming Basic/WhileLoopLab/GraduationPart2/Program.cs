using System;

namespace GraduationPart2
{
    class Program
    {
        static void Main(string[] args)
        {
            string name = Console.ReadLine();
            int grade = 1;
            int notPassed = 0;
            double averageMark = 0;
            bool isExpelled = false;
            while (grade <= 12)
            {
                double mark = double.Parse(Console.ReadLine());
                if (mark < 4)
                {
                    notPassed++;

                    if (notPassed > 1)
                    {
                        isExpelled = true;
                        break;
                    }
                    continue;
                }
                averageMark += mark;
                grade++;
            }

            if (isExpelled)
            {
                Console.WriteLine($"{name} has been excluded at {grade} grade");
            }
            else
            {
                Console.WriteLine($"{name} graduated. Average grade: {(averageMark / 12):f2}");
            }
        }
    }
}
