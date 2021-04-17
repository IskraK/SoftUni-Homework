using System;

namespace _1.BonusScoringSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            int countOfStudents = int.Parse(Console.ReadLine());
            int countOfLectures = int.Parse(Console.ReadLine());
            int additionalBonus = int.Parse(Console.ReadLine());
            double totalBonus = 0;
            double maxBonus = 0;
            int studentAttendance = 0;

            for (int i = 0; i < countOfStudents; i++)
            {
                int attendance = int.Parse(Console.ReadLine());
                totalBonus = (1.0*attendance / countOfLectures) * (5 + additionalBonus);

                if (maxBonus < totalBonus)
                {
                    maxBonus = totalBonus;
                    studentAttendance = attendance;
                }
            }

            Console.WriteLine($"Max Bonus: {Math.Ceiling(maxBonus)}.");
            Console.WriteLine($"The student has attended {studentAttendance} lectures.");
        }
    }
}
