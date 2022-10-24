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
                if (t == null) throw new ArgumentNullException(nameof(t));

                if (typeof(T) == typeof(Teacher))
                {
                    _context.Teacher.Add((Teacher)(object)t);
                }
                else if (typeof(T) == typeof(Student))
                {
                    Student student = (Student)(object)t;
                    _context.Student.Add(student);
                }
                else if (typeof(T) == typeof(Course))
                {
                    _context.Course.Add((Course)(object)t);
                }
                else if (typeof(T) == typeof(StudentCourse))
                {
                    _context.StudentCourse.Add((StudentCourse)(object)t);
                }
                _context.SaveChanges();
           
        }

        public void Delete<T>(int id)
        {

            if (typeof(T) == typeof(Teacher))
            {
                var teacher = _context.Teacher.FirstOrDefault(x => x.Id == id);
                if (teacher is null) throw new ArgumentNullException(nameof(teacher));
                    _context.Teacher.Remove(teacher);

            }
            else if (typeof(T) == typeof(Student))
            {
                var student = _context.Student.FirstOrDefault(x => x.Id == id);
                if (student is null) throw new ArgumentNullException(nameof(student));
                    _context.Student.Remove(student);
            }
            else if (typeof(T) == typeof(Course))
            {
                var course = _context.Course.FirstOrDefault(x => x.Id == id);
                if (course is null) throw new ArgumentNullException(nameof(course));
                    _context.Course.Remove(course);
            }
            else if (typeof(T) == typeof(StudentCourse))
            {
                var studentcourse = _context.StudentCourse.FirstOrDefault(x => x.StudentId == id);
                if (studentcourse is null) throw new ArgumentNullException(nameof(studentcourse));
                    _context.StudentCourse.Remove(studentcourse);
            }

            _context.SaveChanges();




        }

        public void Update<T>(T t)

        {

            if (t == null) throw new ArgumentNullException(nameof(t));

            if (typeof(T) == typeof(Teacher))
            {
                _context.Teacher.Update((Teacher)(object)t);
            }
            else if (typeof(T) == typeof(Student))
            {
                _context.Student.Update((Student)(object)t);
            }
            else if (typeof(T) == typeof(Course))
            {
                _context.Course.Update((Course)(object)t);
            }
            else if (typeof(T) == typeof(StudentCourse))
            {
                _context.StudentCourse.Update((StudentCourse)(object)t);
            }

            _context.SaveChanges();
        }


        public T Get<T>(int id)
        {

            if (typeof(T) == typeof(Teacher))
            {
                var teacher = _context.Teacher.FirstOrDefault(x => x.Id == id);
                if (teacher is null) throw new ArgumentNullException(nameof(teacher));
                return (T)(IEnumerable<T>)teacher;
            }
            else if (typeof(T) == typeof(Student))
            {
                var student = _context.Student.FirstOrDefault(x => x.Id == id);
                if (student is null) throw new ArgumentNullException(nameof(student));
                return (T)(IEnumerable<T>)student;
            }
            else if (typeof(T) == typeof(Course))
            {
                var course = _context.Course.FirstOrDefault(x => x.Id == id);
                if (course is null) throw new ArgumentNullException(nameof(course));
                return (T)(IEnumerable<T>)course;
            }
            else if (typeof(T) == typeof(StudentCourse))
            {
                var studentcourse = _context.StudentCourse.FirstOrDefault(x => x.StudentId == id);
                if (studentcourse is null) throw new ArgumentNullException(nameof(studentcourse));
                return (T)(IEnumerable<T>)studentcourse;
            }

            return default(T);
        }

        public List<T> GetAll<T>()
        {

            if (typeof(T) == typeof(Teacher))
            {
                return new List<T>((IEnumerable<T>)_context.Teacher.ToList());
            }
            else if (typeof(T) == typeof(Student))
            {
                return new List<T>((IEnumerable<T>)_context.Student.ToList());
            }
            else if (typeof(T) == typeof(Course))
            {
                return new List<T>((IEnumerable<T>)_context.Course.ToList());
            }
            else if (typeof(T) == typeof(StudentCourse))
            {
                return new List<T>((IEnumerable<T>)_context.StudentCourse.ToList());
            }

            return null;
        }

    }
}
