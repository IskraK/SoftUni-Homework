﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace _7.StudentAcademy
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<double>> students = new Dictionary<string, List<double>>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string name = Console.ReadLine();
                double grade = double.Parse(Console.ReadLine());

                if (!students.ContainsKey(name))
                {
                    students.Add(name, new List<double>());
                }
                students[name].Add(grade);
            }

            Dictionary<string, List<double>> sortedStudents = students
                .Where(s => s.Value.Average() >= 4.50)
                .OrderByDescending(s => s.Value.Average())
                .ToDictionary(x => x.Key, x => x.Value);

            foreach (var student in sortedStudents)
            {
                Console.WriteLine($"{student.Key} -> {student.Value.Average():F2}");
            }
        }
    }
}
