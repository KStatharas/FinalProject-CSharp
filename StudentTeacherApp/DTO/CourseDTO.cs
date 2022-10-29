using StudentTeacherApp.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentTeacherApp.Data.Models
{

    public class CourseDTO
    {
        public int Id { get; set; }

        public String? Description { get; set; }


        public int TeacherId { get; set; }

        public TeacherDTO Teacher { get; set; }

        public List<StudentCourseDTO> ?StudentCourses { get; set; }
    }
}
