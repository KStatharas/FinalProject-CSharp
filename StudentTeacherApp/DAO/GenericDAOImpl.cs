using Microsoft.AspNetCore.Identity;
using NuGet.DependencyResolver;
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

                User? user = _context.User.FirstOrDefault(x => x.Id == id);
                _context.User.Remove(user);
            }

            else if (typeof(T) == typeof(Student))
            {
                Student? student = _context.Student.FirstOrDefault(x => x.Id == id);
                StudentCourse? studentcourse = default(StudentCourse?);
                studentcourse = _context.StudentCourse.FirstOrDefault(x => x.StudentId == id);
                if (studentcourse != null) _context.StudentCourse.Remove(studentcourse);
                _context.Student.Remove(student);

                User? user = _context.User.FirstOrDefault(x => x.Id == id);
                _context.User.Remove(user);
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

                User? user = _context.User.FirstOrDefault(x => x.Id == id);
                _context.User.Remove(user);
            }

            else if (typeof(T) == typeof(User))
            {
                User? user = _context.User.FirstOrDefault(x => x.Id == id);
                switch (user.Type)
                {
                    case "Admin":

                        Delete<Admin>(id);
                        break;

                    case "Teacher":

                        Delete<Teacher>(id);
                        break;

                    case "Student":

                        Delete<Student>(id);
                        break;

                    default:

                        _context.User.Remove(user);
                        break;
                }
            }
            _context.SaveChanges();

        }

        public void Update<T>(T t)

        {

            if (t == null) throw new ArgumentNullException(nameof(t));

            if (typeof(T) == typeof(Teacher))
            {
                Teacher teacher = (Teacher)(object)t;
                var local = _context.Set<Teacher>().Local.FirstOrDefault(entry => entry.Id.Equals(teacher.Id));
                if (local != null)
                {
                    _context.Entry(local).State = Microsoft.EntityFrameworkCore.EntityState.Detached;
                }
                _context.Entry(teacher).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            }
            else if (typeof(T) == typeof(Student))
            {
                Student student = (Student)(object)t;
                var local = _context.Set<Teacher>().Local.FirstOrDefault(entry => entry.Id.Equals(student.Id));
                if (local != null)
                {
                    _context.Entry(local).State = Microsoft.EntityFrameworkCore.EntityState.Detached;
                }
                _context.Entry(student).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            }
            else if (typeof(T) == typeof(Course))
            {
                Course course = (Course)(object)t;
                var local = _context.Set<Course>().Local.FirstOrDefault(entry => entry.Id.Equals(course.Id));
                if (local != null)
                {
                    _context.Entry(local).State = Microsoft.EntityFrameworkCore.EntityState.Detached;
                }
                _context.Entry(course).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            }
            else if (typeof(T) == typeof(StudentCourse))
            {
                StudentCourse studentCourse = (StudentCourse)(object)t;
                var local = _context.Set<StudentCourse>().Local.FirstOrDefault(entry => entry.StudentId.Equals(studentCourse.StudentId));
                if (local != null)
                {
                    _context.Entry(local).State = Microsoft.EntityFrameworkCore.EntityState.Detached;
                }
                _context.Entry(studentCourse).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            }
            else if (typeof(T) == typeof(Admin))
            {
                Admin admin = (Admin)(object)t;
                var local = _context.Set<Admin>().Local.FirstOrDefault(entry => entry.Id.Equals(admin.Id));
                if (local != null)
                {
                    _context.Entry(local).State = Microsoft.EntityFrameworkCore.EntityState.Detached;
                }
                _context.Entry(admin).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            }
            else if (typeof(T) == typeof(User))
            {
                User user = (User)(object)t;
                var local = _context.Set<User>().Local.FirstOrDefault(entry => entry.Id.Equals(user.Id));
                if (local != null)
                {
                    _context.Entry(local).State = Microsoft.EntityFrameworkCore.EntityState.Detached;
                }
                _context.Entry(user).State = Microsoft.EntityFrameworkCore.EntityState.Modified;

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

        public User? GetUsername(string username) => _context.User.FirstOrDefault(x => x.Username == username);

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

        public StudentCourse? GetCourse(int UserId, int CourseId) => _context.StudentCourse.FirstOrDefault(x => x.CourseId == CourseId && x.StudentId == UserId);
        public void DeleteCourse(int UserId, int CourseId)
        {
            //StudentCourse studentCourse = _context.StudentCourse.FirstOrDefault(x => x.CourseId == CourseId && x.StudentId == UserId);
            //studentCourse.Student = null;
            //_context.StudentCourse.Remove(studentCourse);

            _context.StudentCourse.Remove
                ((
                    from x in _context.StudentCourse
                    where x.CourseId == CourseId && x.StudentId == UserId
                    select x
                  
                )?.FirstOrDefault()!);

            _context.SaveChanges();
        }

    }
}
