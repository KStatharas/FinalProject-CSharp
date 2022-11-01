using StudentTeacherApp.Data.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentTeacherApp.Models
{
    public class Teacher
    {
        [Key]
        [Column("TeacherId")]
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

        public List<Course> Courses { get; set; }

        public User? User { get; set; }
    }
}
