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

        public int Add<T>(T t)

        {
            if (t == null) throw new ArgumentNullException(nameof(t));

            int id = 0;

            if (typeof(T) == typeof(Teacher))
            {
                var inserted = (Teacher)(object)t;
                _context.Teacher.Add(inserted);
                _context.SaveChanges();
                id = inserted.Id;
            }
            else if (typeof(T) == typeof(Student))
            {
                var inserted = (Student)(object)t;
                _context.Student.Add(inserted);
                _context.SaveChanges();
                id = inserted.Id;
            }
            else if (typeof(T) == typeof(Course))
            {
                var inserted = (Course)(object)t;
                _context.Course.Add(inserted);
                _context.SaveChanges();
                id = inserted.Id;
            }
            else if (typeof(T) == typeof(StudentCourse))
            {
                var inserted = (StudentCourse)(object)t;
                _context.StudentCourse.Add(inserted);
                _context.SaveChanges();
                id = inserted.StudentId;
            }
            else if (typeof(T) == typeof(Admin))
            {

                var inserted = (Admin)(object)t;
                _context.Admin.Add(inserted);
                _context.SaveChanges();
                id = inserted.Id;
            }
            else if (typeof(T) == typeof(User))
            {

                var inserted = (User)(object)t;
                _context.User.Add(inserted);
                _context.SaveChanges();
                id = inserted.Id;
            }
            

            return id;
        }

        public void Delete<T>(int id)
        {

            if (typeof(T) == typeof(Teacher))
            {
                Teacher? teacher = _context.Teacher.FirstOrDefault(x => x.Id == id);

                Course? course = default(Course?);
                StudentCourse? studentcourse = default(StudentCourse?);

                course = _context.Course.FirstOrDefault(x => x.TeacherId == id);

                if (course != default(Course)){
                    studentcourse = _context.StudentCourse.FirstOrDefault(x => x.CourseId == course.Id);

                    if (studentcourse != default(StudentCourse)) _context.StudentCourse.Remove(studentcourse);
                    _context.Course.Remove(course);
                }

                _context.Teacher.Remove(teacher);

            }
            else if (typeof(T) == typeof(Student))
            {
                Student? student = _context.Student.FirstOrDefault(x => x.Id == id);
                StudentCourse? studentcourse = default(StudentCourse?);
                studentcourse = _context.StudentCourse.FirstOrDefault(x => x.StudentId == id);
                if (studentcourse != null) _context.StudentCourse.Remove(studentcourse);
                _context.Student.Remove(student);
            }
            else if (typeof(T) == typeof(Course))
            {
                Course? course = _context.Course.FirstOrDefault(x => x.Id == id);
                StudentCourse? studentcourse = default(StudentCourse?);
                studentcourse = _context.StudentCourse.FirstOrDefault(x => x.CourseId == id);
                if (studentcourse != null) _context.StudentCourse.Remove(studentcourse);

                _context.Course.Remove(course);
            }
            else if (typeof(T) == typeof(StudentCourse))
            {
                StudentCourse? studentcourse = _context.StudentCourse.FirstOrDefault(x => x.StudentId == id);
                 _context.StudentCourse.Remove(studentcourse);
            }
            else if (typeof(T) == typeof(Admin))
            {
                Admin? admin = _context.Admin.FirstOrDefault(x => x.Id == id);
                _context.Admin.Remove(admin);
            }
            else if (typeof(T) == typeof(User))
            {
                User? user = _context.User.FirstOrDefault(x => x.Id == id);
                switch (user.Type)
                {
                    case "Admin":

                        Admin? admin = _context.Admin.FirstOrDefault(x => x.Id == id);
                        _context.Admin.Remove(admin);
                        break;

                    case "Teacher":

                        Delete<Teacher>(id);
                        break;

                    case "Student":

                        Delete<Student>(id);
                        break;

                    default:
                        break;
                }
                _context.User.Remove(user);

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
            else if (typeof(T) == typeof(Admin))
            {
                _context.Admin.Update((Admin)(object)t);
            }
            else if (typeof(T) == typeof(User))
            {
                _context.User.Update((User)(object)t);
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
            else if (typeof(T) == typeof(Admin))
            {
                Admin? admin = _context.Admin.FirstOrDefault(x => x.Id == id);
                return (T)(object)admin;
            }
            else if (typeof(T) == typeof(User))
            {
                User? user = _context.User.FirstOrDefault(x => x.Id == id);
                return (T)(object)user;
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
            else if (typeof(T) == typeof(Admin))
            {
                return new List<T>((IEnumerable<T>)_context.Admin.ToList());
            }
            else if (typeof(T) == typeof(User))
            {
                return new List<T>((IEnumerable<T>)_context.User.ToList());
            }

            return null;
        }

    }
}
