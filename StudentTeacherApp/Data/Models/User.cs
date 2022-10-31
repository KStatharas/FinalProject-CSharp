using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentTeacherApp.Data.Models
{
    public class User
    {
        [Key]
        [Column("UserId")]
        public int Id { get; set; }

        [Column("Firstname")]
        public string? Firstname { get; set; }

        [Column("Lastname")]
        public string? Lastname { get; set; }

        [Column("Type")]
        public string? Type { get; set; }

        [Column("TeacherId")]
        [ForeignKey("Teacher")]
        public int TeacherId { get; set; }

        [ForeignKey("Student")]
        [Column("StudentId")]
        public int StudentId { get; set; }

        [ForeignKey("Admin")]
        [Column("AdminId")]
        public int AdminId { get; set; }

    }
}
