using StudentTeacherApp.Models;

namespace StudentTeacherApp.Service
{
    public interface IServiceUser
    {

        void InsertUser(User user);
        void UpdateUser(User user);
        User? DeleteUser(long id);
        User? GetStudent(int id);
        List<User> GetAllUsers();

    }
}
