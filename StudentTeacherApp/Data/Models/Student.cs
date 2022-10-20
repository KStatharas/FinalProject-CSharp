using StudentTeacherApp.Data.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentTeacherApp.Models
{
    public class Student : IUser
    {
        [Key]
        [Column("StudentId")]

        public int Id { get; set; }

        [Column("Firstname")]
        public string? Firstname { get; set; }

        [Column("Lastname")]
        public string? Lastname { get; set; }

        public List<StudentCourse> StudentCourses { get; set; }
    }
}
