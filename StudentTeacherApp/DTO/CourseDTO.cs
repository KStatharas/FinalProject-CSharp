using StudentTeacherApp.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentTeacherApp.Data.Models
{

    public class CourseDTO
    {
        [Key]
        [Column("CourseId")]
        public int Id { get; set; }

        [Column("Description")]
        public String? Description { get; set; }

        [Column("TeacherId")]
        [ForeignKey("Teacher")]
        public int TeacherId { get; set; }

        public TeacherDTO Teacher { get; set; }

        public List<StudentCourseDTO> StudentCourses { get; set; }
    }
}
