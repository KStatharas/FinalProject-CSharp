﻿using Microsoft.EntityFrameworkCore;
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
                .HasForeignKey(fk => fk.StudentId);

            modelBuilder.Entity<StudentCourse>()
                .HasOne(p => p.Course)
                .WithMany(c => c.StudentCourses)
                .HasForeignKey(fk => fk.CourseId);
        }

        public DbSet<Student> Student { get; set; }
        public DbSet<Teacher> Teacher { get; set; }
        public DbSet<Course> Course { get; set; }
        public DbSet<StudentCourse> StudentCourse { get; set; }

    }
}
