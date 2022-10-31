using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentTeacherApp.Data.Models
{
    public class Admin
    {
        [Key]
        [Column("AdminId")]

        public int Id { get; set; }

        [Column("Firstname")]
        public string? Firstname { get; set; }

        [Column("Lastname")]
        public string? Lastname { get; set; }

    }
}
