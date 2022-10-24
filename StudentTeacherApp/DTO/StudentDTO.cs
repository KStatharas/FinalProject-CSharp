using StudentTeacherApp.Data.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentTeacherApp.Models
{
    public class StudentDTO
    {
        public int Id { get; set; }
        
        [Required]
        [MinLength(5),MaxLength(60)]
        public string? Firstname { get; set; }

        [Required]
        [MinLength(5), MaxLength(60)]
        public string? Lastname { get; set; }

        public List<StudentCourseDTO> ?StudentCourses { get; set; }
    }
}
