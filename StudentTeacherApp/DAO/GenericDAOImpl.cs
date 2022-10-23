using Microsoft.AspNetCore.Identity;
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

        public void Add<T>(T t)

        {
            if (typeof(T) is Teacher)
            {
                _context.Teacher.Add((Teacher)(object)t);
            }
            else if (typeof(T) is Student)
            {
                _context.Student.Add((Student)(object)t);
            }
            else if (typeof(T) is Course)
            {
                _context.Course.Add((Course)(object)t);
            }
            else if (typeof(T) is StudentCourse)
            {
                _context.StudentCourse.Add((StudentCourse)(object)t);
            }
            _context.SaveChanges();
        }

        public void Delete<T>(int id)
        {
            if (typeof(T) is Teacher)
            {
                _context.Remove(_context.Teacher.FirstOrDefault(x => x.Id == id));
            }
            else if (typeof(T) is Student)
            {
                _context.Remove(_context.Student.FirstOrDefault(x => x.Id == id));
            }
            else if (typeof(T) is Course)
            {
                _context.Remove(_context.Course.FirstOrDefault(x => x.Id == id));
            }
            else if (typeof(T) is StudentCourse)
            {
                _context.Remove(_context.StudentCourse.FirstOrDefault(x => x.StudentId == id));
            }

            //if (uName == "Teacher")
            //{
            //    _context.Remove(_context.Teacher.FirstOrDefault(x => x.Id == id));
            //}
            //else if (uName == "Student")
            //{
            //    _context.Remove(_context.Student.FirstOrDefault(x => x.Id == id));
            //}
            _context.SaveChanges();




        }

        public void Update<T>(T t)
        {
            if (typeof(T) is Teacher)
            {
                _context.Teacher.Update((Teacher)(object)t);
            }
            else if (typeof(T) is Student)
            {
                _context.Student.Update((Student)(object)t);
            }
            else if (typeof(T) is Course)
            {
                _context.Course.Update((Course)(object)t);
            }
            else if (typeof(T) is StudentCourse)
            {
                _context.StudentCourse.Update((StudentCourse)(object)t);
            }

            //if (uName == "Teacher")
            //{
            //    _context.Teacher.Update((Teacher)user);
            //}
            //else if (uName == "Student")
            //{
            //    _context.Student.Update((Student)user);
            //}
            //else if (uName == "Course")
            //{
            //    _context.Student.Update((Student)user);
            //}
            //else if (uName == "StudentCourse")
            //{

            //}

            _context.SaveChanges();
        }


        public T? Get<T>(int id)
        {

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

            return (T)(IEnumerable<T>)_context.Teacher.FirstOrDefault(x => x.Id == id); ;
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
