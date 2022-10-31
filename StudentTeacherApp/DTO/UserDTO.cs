using System.ComponentModel.DataAnnotations.Schema;

namespace StudentTeacherApp.DTO
{
    public class UserDTO
    {
    
        public int Id { get; set; }

        public string? Firstname { get; set; }

        public string? Lastname { get; set; }

        public string? Type { get; set; }

        public int ?TeacherId { get; set; }

        public int ?StudentId { get; set; }

        public int ?AdminId { get; set; }
    }
}
