using Microsoft.EntityFrameworkCore;
using StudentTeacherApp.Data.Models;
using StudentTeacherApp.Models;

namespace StudentTeacherApp.Data
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Teacher>()
            //    .HasKey(t => new { t.Id });

            //modelBuilder.Entity<Student>()
            //    .HasKey(t => new { t.Id });
            

            modelBuilder.Entity<Course>()
                .HasOne(p => p.Teacher)
                .WithMany(c => c.Courses)
                .HasForeignKey(fk => fk.TeacherId);

            modelBuilder.Entity<StudentCourse>()
                .HasOne(p => p.Student)
                .WithMany(c => c.StudentCourses)
                .HasForeignKey(fk => fk.StudentId)
                .HasForeignKey(fk1 => fk1.CourseId);

        }

        public DbSet<Student> Student { get; set; }
        public DbSet<Teacher> Teacher { get; set; }
        public DbSet<Course> Course { get; set; }
        public DbSet<StudentCourse> StudentCourse { get; set; }
        public DbSet<StudentTeacherApp.Models.TeacherDTO> TeacherDTO { get; set; }
        public DbSet<StudentTeacherApp.Models.StudentDTO> StudentDTO { get; set; }
        public DbSet<StudentTeacherApp.Data.Models.CourseDTO> CourseDTO { get; set; }
        public DbSet<StudentTeacherApp.Data.Models.StudentCourseDTO> StudentCourseDTO { get; set; }
    }
}
