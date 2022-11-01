using StudentTeacherApp.Data.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentTeacherApp.Models
{
    public class Student
    {
        [Key]
        [Column("StudentId")]
        [ForeignKey("User")]
        [DatabaseGenerated((DatabaseGeneratedOption.None))]
        public int Id { get; set; }

        [Column("Firstname")]
        public string? Firstname { get; set; }

        [Column("Lastname")]
        public string? Lastname { get; set; }

        //[Column("UserId")]
        //[ForeignKey("User")]
        //public int UserId { get; set; }

        public List<StudentCourse> StudentCourses { get; set; }

        public User? User { get; set; }
    }
}
