using System.ComponentModel.DataAnnotations.Schema;

namespace StudentTeacherApp.DTO
{
    public class AdminDTO
    {
        public int Id { get; set; }

        public string? Firstname { get; set; }

        public string? Lastname { get; set; }
    }
}
