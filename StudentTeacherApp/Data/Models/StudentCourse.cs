using Microsoft.EntityFrameworkCore.Metadata.Internal;
using StudentTeacherApp.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentTeacherApp.Data.Models
{
    public class StudentCourse
    {
        [Key]
        [ForeignKey("Course")]
        [Column("CourseId")]
        public int CourseId { get; set; }

        [Key]
        [ForeignKey("Student")]
        [Column("StudentId")]
        public int StudentId { get; set; }

        public Student Student { get; set; }
        public Course Course { get; set; }
    }
}
