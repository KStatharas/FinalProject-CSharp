using System.ComponentModel.DataAnnotations;

namespace StudentTeacherApp.DTO
{
    public interface IFirstName_Lastname
    {
        [Display(Name = "First Name")]
        public string? Firstname { get; set; }
        [Display(Name = "Last Name")]
        public string? Lastname { get; set; }
    }
}
