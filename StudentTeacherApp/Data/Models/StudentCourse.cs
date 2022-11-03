using Microsoft.EntityFrameworkCore.Metadata.Internal;
using StudentTeacherApp.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentTeacherApp.Data.Models
{
    public class StudentCourse
    {
        [Key, Column("CourseId")]
        [ForeignKey("Course")]
        public int CourseId { get; set; }

        [Key, Column("StudentId")]
        [ForeignKey("Student")]
        public int StudentId { get; set; }

        public Student Student { get; set; }
        public Course Course { get; set; }
    }
}
