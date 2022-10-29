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
                Teacher? teacher = _context.Teacher.FirstOrDefault(x => x.Id == id);
                    _context.Teacher.Remove(teacher);

            }
            else if (typeof(T) == typeof(Student))
            {
                Student? student = _context.Student.FirstOrDefault(x => x.Id == id);
                    _context.Student.Remove(student);
            }
            else if (typeof(T) == typeof(Course))
            {
                Course? course = _context.Course.FirstOrDefault(x => x.Id == id);
                    _context.Course.Remove(course);
            }
            else if (typeof(T) == typeof(StudentCourse))
            {
                StudentCourse? studentcourse = _context.StudentCourse.FirstOrDefault(x => x.StudentId == id);
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
                Teacher? teacher = _context.Teacher.FirstOrDefault(x => x.Id == id);
                return (T)(object)teacher;
            }
            else if (typeof(T) == typeof(Student))
            {
                Student? student = _context.Student.FirstOrDefault(x => x.Id == id);
                return (T)(object)student;
            }
            else if (typeof(T) == typeof(Course))
            {
                Course? course = _context.Course.FirstOrDefault(x => x.Id == id);
                return (T)(object)course;
            }
            else if (typeof(T) == typeof(StudentCourse))
            {
                StudentCourse? studentcourse = _context.StudentCourse.FirstOrDefault(x => x.StudentId == id);
                return (T)(object)studentcourse;
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
