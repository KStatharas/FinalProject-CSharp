﻿using Microsoft.AspNetCore.Identity;
using StudentTeacherApp.Data;
using StudentTeacherApp.Data.Models;
using StudentTeacherApp.Models;
using StudentTeacherApp.Service;

namespace StudentTeacherApp.DAO
{
    public class GenericDAOImpl : IGenericDAO
    {
        private ApplicationDbContext _context;

        public GenericDAOImpl(ApplicationDbContext context)
        {
            _context = context;
        }

        public void Add(IUser user, string uName)

        {
            if(uName == "Teacher")
            {
                _context.Teacher.Add((Teacher)user);
            }
            else if (uName == "Student")
            {
                _context.Student.Add((Student)user);
            }
            _context.SaveChanges();
        }

        public void Delete(int id, string uName)
        {

            if (uName == "Teacher")
            {
                _context.Remove(_context.Teacher.FirstOrDefault(x => x.Id == id));
            }
            else if (uName == "Student")
            {
                _context.Remove(_context.Student.FirstOrDefault(x => x.Id == id));
            }
            _context.SaveChanges();

        }

        public void Update(IUser user, string uName)
        {
            if (uName == "Teacher")
            {
                _context.Teacher.Update((Teacher)user);
            }
            else if (uName == "Student")
            {
                _context.Student.Update((Student)user);
            }
            else if (uName == "Course")
            {
                _context.Student.Update((Student)user);
            }
            else if (uName == "StudentCourse")
            {

            }

            _context.SaveChanges();
        }


        public T? Get<T>(int id) {

            if (typeof(T) is Teacher)
            {
                return (T)(IEnumerable<T>)_context.Teacher.FirstOrDefault(x => x.Id == id);
            }
            else if (typeof(T) is Student)
            {
                return (T)(IEnumerable<T>)_context.Student.FirstOrDefault(x => x.Id == id);
            }
            else if (typeof(T) is Course)
            {
                return (T)(IEnumerable<T>)_context.Course.FirstOrDefault(x => x.Id == id);
            }
            else if (typeof(T) is StudentCourse)
            {
                return (T)(IEnumerable<T>)_context.StudentCourse.FirstOrDefault(x => x.CourseId == id);
            }
            return null;
        }

        public List<T> GetAll<T>()
        { 

            if (typeof(T) is Teacher)
            {
                return new List<T>((IEnumerable<T>)_context.Teacher.ToList());
            }
            else if (typeof(T) is Student)
            {
                return new List<T>((IEnumerable<T>)_context.Student.ToList());
            }
            else if (typeof(T) is Course)
            {
                return new List<T>((IEnumerable<T>)_context.Course.ToList());
            }
            else if (typeof(T) is StudentCourse)
            {
                return new List<T>((IEnumerable<T>)_context.StudentCourse.ToList());
            }

                return null;
        }

    }


}
