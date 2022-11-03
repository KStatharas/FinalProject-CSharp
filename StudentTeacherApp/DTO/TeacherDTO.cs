using StudentTeacherApp.Data.Models;
using StudentTeacherApp.DTO;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentTeacherApp.Models
{
    public class TeacherDTO : IFirstName_Lastname
    {

        public int Id { get; set; }

        public string? Firstname { get; set; }
        public string? Lastname { get; set; }


        //public int UserId { get; set; }

        public List<Course> ?Courses { get; set; }

        public User? User { get; set; }

    }
}
