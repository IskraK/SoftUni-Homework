using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassroomProject
{
    public class Classroom
    {
        private readonly List<Student> students;

        public Classroom(int capacity)
        {
            Capacity = capacity;
            students = new List<Student>();
        }
        public int Capacity { get; set; }
        public int Count 
        { 
            get
            {
                return students.Count;
            }
        }

        public string RegisterStudent(Student student)
        {
            if (Capacity > Count)
            {
                students.Add(student);
                return $"Added student {student.FirstName} {student.LastName}";
            }
            return "No seats in the classroom";
        }

        public string DismissStudent(string firstName, string lastName)
        {
            if (students.Any(n => n.FirstName == firstName &&  n.LastName == lastName))
            {
                Student studentToRemove = students.FirstOrDefault(n => n.FirstName == firstName &&  n.LastName == lastName);
                students.Remove(studentToRemove);
                return $"Dismissed student {firstName} {lastName}";
            }
            return "Student not found";
        }

        public string GetSubjectInfo(string subject)
        {
            List<Student> studentsWithSubject = students.Where(s => s.Subject == subject).ToList();
            if (studentsWithSubject.Count > 0)
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendLine($"Subject: {subject}");
                sb.AppendLine("Students:");
                foreach (var student in studentsWithSubject)
                {
                    sb.AppendLine($"{student.FirstName} {student.LastName}");
                }
                return sb.ToString().TrimEnd();
            }
            return "No students enrolled for the subject";
        }

        public int GetStudentsCount()
        {
            return Count;
        }

        public Student GetStudent(string firstName, string lastName)
        {
            return students.FirstOrDefault(s => s.FirstName == firstName && s.LastName == lastName);
        }
    }
}
