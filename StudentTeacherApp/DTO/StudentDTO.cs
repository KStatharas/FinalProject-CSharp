using StudentTeacherApp.Data.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentTeacherApp.Models
{
    public class StudentDTO
    {
     
        public int Id { get; set; }

        public string? Firstname { get; set; }

        public string? Lastname { get; set; }

        public List<StudentCourse> ?StudentCourses { get; set; }

        public User? User { get; set; }

    }
}
