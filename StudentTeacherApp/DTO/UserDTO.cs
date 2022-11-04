using StudentTeacherApp.Data.Models;
using StudentTeacherApp.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentTeacherApp.DTO
{
    public class UserDTO 
    {


     
        public int Id { get; set; }

        [Required(ErrorMessage = "Username is required.")]
        [MinLength(3)]
        [MaxLength(55)]

        public string? Username { get; set; }

        [Required(ErrorMessage = "Password is required.")]
        [MinLength(3)]
        [MaxLength(55)]
        public string? Password { get; set; }

        [Required(ErrorMessage = "Type is required.")]
        [Display(Name = "Role")]
        public string? Type { get; set; }

        [NotMapped]
        public IFirstName_Lastname ?FirstLast { get; set; }

    }
}
