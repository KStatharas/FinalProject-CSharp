using Microsoft.EntityFrameworkCore;
using StudentTeacherApp.Data.Models;
using StudentTeacherApp.Models;
using System.ComponentModel.DataAnnotations.Schema;
using StudentTeacherApp.DTO;

namespace StudentTeacherApp.Data
{
    public class ApplicationDbContext : DbContext
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
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<StudentCourse>()
                .HasOne(p => p.Course)
                .WithMany(c => c.StudentCourses)
                .HasForeignKey(fk => fk.CourseId)
                .OnDelete(DeleteBehavior.Restrict);

            //modelBuilder.Entity<Student>()
            //    .HasOne(p => p.User)
            //    .WithOne()
            //    .HasForeignKey<User>(fk => fk.Id);

            //modelBuilder.Entity<Teacher>()
            //    .HasOne(p => p.User)
            //    .WithOne()
            //    .HasForeignKey<User>(fk => fk.Id);

            //modelBuilder.Entity<Admin>()
            //    .HasOne(p => p.User)
            //    .WithOne()
            //    .HasForeignKey<User>(fk => fk.Id);

            modelBuilder.Entity<User>()
                .Property(f => f.Id)
                .ValueGeneratedOnAdd();
        }

        public DbSet<Student> Student { get; set; }
        public DbSet<Teacher> Teacher { get; set; }
        public DbSet<Course> Course { get; set; }
        public DbSet<StudentCourse> StudentCourse { get; set; }
        public DbSet<Admin> Admin { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<StudentTeacherApp.DTO.UserDTO> UserDTO { get; set; }

    }
}