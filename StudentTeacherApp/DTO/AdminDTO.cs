using StudentTeacherApp.Data.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentTeacherApp.DTO
{
    public class AdminDTO : IFirstName_Lastname
    {
        public int Id { get; set; }

        public string? Firstname { get; set; }

        public string? Lastname { get; set; }

        public User? User { get; set; }

    }
}
