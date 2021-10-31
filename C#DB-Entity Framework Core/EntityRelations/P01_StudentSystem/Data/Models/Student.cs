using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace P01_StudentSystem.Data.Models
{
    public class Student
    {
        public Student()
        {
            CourseEnrollments = new HashSet<StudentCourse>();
            HomeworkSubmissions = new HashSet<Homework>();
        }

        [Key]
        public int StudentId { get; set; }

        [StringLength(100)]
        [Required]
        public string Name { get; set; }

        [StringLength(10,MinimumLength =10)]
        [Column(TypeName = "char(10)")]
        public string PhoneNumber { get; set; }

        public DateTime RegisteredOn { get; set; }

        public DateTime? Birthday { get; set; }
        public virtual ICollection<StudentCourse> CourseEnrollments { get; set; }
        public virtual ICollection<Homework> HomeworkSubmissions { get; set; }

    }
}
