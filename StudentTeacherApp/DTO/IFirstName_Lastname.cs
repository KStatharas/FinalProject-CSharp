using System.ComponentModel.DataAnnotations;

namespace StudentTeacherApp.DTO
{
    public interface IFirstName_Lastname
    {
        public string? Firstname { get; set; }

        public string? Lastname { get; set; }
    }
}
