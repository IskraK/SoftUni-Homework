using System;
using System.Collections.Generic;
using System.Linq;

namespace _4.Students
{
    public class Student
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public double Grade { get; set; }

        public override string ToString()
        {
            return $"{FirstName} {LastName}: {Grade:F2}";
        }

    }
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            List<Student> students = new List<Student>();

            for (int i = 0; i < n; i++)
            {
                string[] studentData = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                Student student = new Student
                {
                    FirstName = studentData[0],
                    LastName = studentData[1],
                    Grade = double.Parse(studentData[2])
                };

                students.Add(student);
            }

            List<Student> sortedStudents = students
                .OrderByDescending(x => x.Grade)
                .ToList();

            foreach (var student in sortedStudents)
            {
                Console.WriteLine(student);
            }
        }
    }
}
