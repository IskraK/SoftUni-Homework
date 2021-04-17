using System;
using System.Collections.Generic;
using System.Linq;

namespace _5.Students2._0var2
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Student> students = new List<Student>();

            string command = Console.ReadLine();
            while (command != "end")
            {
                string[] input = command.Split();
                string firstName = input[0];
                string lastName = input[1];
                int age = int.Parse(input[2]);
                string homeTown = input[3];
                bool isExist = false;

                foreach (var student in students)
                {
                    if (student.FirstName == firstName && student.LastName == lastName)
                    {
                        student.Age = age;
                        student.Hometown = homeTown;
                        isExist = true;
                    }
                }

                if (!isExist)
                {
                    Student currStudent = new Student(firstName, lastName, age, homeTown);
                    students.Add(currStudent);
                }

                command = Console.ReadLine();
            }

            string nameOfCity = Console.ReadLine();

            foreach (var student in students.Where(x => x.Hometown == nameOfCity))
            {
                Console.WriteLine($"{student.FirstName} {student.LastName} is {student.Age} years old.");
            }
        }
    }

    class Student
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string Hometown { get; set; }

        public Student(string firstName, string lastName, int age, string homeTown)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Age = age;
            this.Hometown = homeTown;
        }

    }
}

