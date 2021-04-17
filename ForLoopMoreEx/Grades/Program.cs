using System;

namespace Grades
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberStudents = int.Parse(Console.ReadLine());
            int marksOver5 = 0;
            int marksOver4 = 0;
            int marksOver3 = 0;
            int marksOver2 = 0;
            double pMarksOver5 = 0;
            double pMarksOver4 = 0;
            double pMarksOver3 = 0;
            double pMarksOver2 = 0;
            double averageMark = 0;
            double sumMarks = 0;
            for (int i = 1; i <= numberStudents; i++)
            {
                double studentsMark = double.Parse(Console.ReadLine());
                sumMarks += studentsMark;
                if (studentsMark >= 5)
                {
                    marksOver5++;
                }
                else if (studentsMark >= 4)
                {
                    marksOver4++;
                }
                else if (studentsMark >= 3)
                {
                    marksOver3++;
                }
                else if (studentsMark >= 2)
                {
                    marksOver2++;
                }
            }
            pMarksOver5 = 1.0 * marksOver5 / numberStudents * 100;
            pMarksOver4 = 1.0 * marksOver4 / numberStudents * 100;
            pMarksOver3 = 1.0 * marksOver3 / numberStudents * 100;
            pMarksOver2 = 1.0 * marksOver2 / numberStudents * 100;
            averageMark = sumMarks / numberStudents;
            Console.WriteLine($"Top students: {pMarksOver5:f2}%");
            Console.WriteLine($"Between 4.00 and 4.99: {pMarksOver4:f2}%");
            Console.WriteLine($"Between 3.00 and 3.99: {pMarksOver3:f2}%");
            Console.WriteLine($"Fail: {pMarksOver2:f2}%");
            Console.WriteLine($"Average: {averageMark:f2}");
        }
    }
}
