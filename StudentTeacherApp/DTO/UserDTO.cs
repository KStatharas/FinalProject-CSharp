using StudentTeacherApp.Data.Models;
using StudentTeacherApp.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentTeacherApp.DTO
{
    public class UserDTO 
    {


     
        public int Id { get; set; }

        public string? Username { get; set; }

        public string? Password { get; set; }

        public string? Type { get; set; }

        [NotMapped]
        public IFirstName_Lastname ?FirstLast { get; set; }

    }
}
