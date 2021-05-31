using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.AverageStudentGrades
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Dictionary<string, List<decimal>> studentsGrades = new Dictionary<string, List<decimal>>();

            for (int i = 0; i < n; i++)
            {
                string[] student = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string name = student[0];
                decimal grade = decimal.Parse(student[1]);

                if (!studentsGrades.ContainsKey(name))
                {
                    studentsGrades.Add(name, new List<decimal>());
                }
                studentsGrades[name].Add(grade);
            }

            //foreach (var student in studentsGrades)
            //{
            //    Console.Write($"{student.Key} -> ");
            //    foreach (var grade in student.Value)
            //    {
            //        Console.Write($"{grade:F2} ");
            //    }
            //    Console.WriteLine($"(avg: {student.Value.Average():F2})");
            //}

            foreach (var student in studentsGrades) 
            {
                Console.WriteLine($"{student.Key} -> {string.Join(" ",student.Value.Select(v => $"{v:F2}"))} (avg: {student.Value.Average():F2})");
            }
        }
    }
}
