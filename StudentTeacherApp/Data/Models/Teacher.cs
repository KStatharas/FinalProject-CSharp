using StudentTeacherApp.Data.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentTeacherApp.Models
{
    public class Teacher : IUser
    {
        [Key]
        [Column("TeacherId")]
        public int Id { get; set; }
        [Column("Firstname")]
        public string? Firstname { get; set; }
        [Column("Lastname")]
        public string? Lastname { get; set; }

        public List<Course> Courses { get; set; }
    }
}
