using StudentTeacherApp.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentTeacherApp.Data.Models
{

    public class Course
    {
        [Key]
        [Column("CourseId")]
        public int Id { get; set; }

        [Column("Description")]
        public String? Description { get; set; }

        [Column("TeacherId")]
        [ForeignKey("Teacher")]
        public int TeacherId { get; set; }

        public Teacher Teacher { get; set; }

        public List<StudentCourse> StudentCourses { get; set; }
    }
}
