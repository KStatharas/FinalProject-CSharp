using StudentTeacherApp.Data.Models;

namespace StudentTeacherApp.DAO
{
    public interface IGenericDAO
    {
        public int Add<T>(T t);
        public void Update<T>(T t);
        public void Delete<T>(int id);
        public T Get<T>(int id);
        public List<T> GetAll<T>();

        public User? GetUsername(string username);

        public StudentCourse GetCourse(int UserId, int CourseId);
        public void DeleteCourse(int UserId, int CourseId);

    }
}
