using StudentTeacherApp.Data.Models;
using StudentTeacherApp.DTO;
using StudentTeacherApp.Models;

namespace StudentTeacherApp.Service
{
    public interface IGenericService
    {

        public int AddEntity<T>(T t);
        public void UpdateEntity<T>(T t);
        public void DeleteEntity<T>(int id);
        public F GetEntity<F,T>(int id);
        public List<F> GetAllEntities<F,T>();

        //public List<UserDTO> GetUserEntities<UserDTO, T>();

        public void UpdateUserEntity(UserDTO userDTO, string firstname, string lastname);

        public UserDTO GetUsernameEntity(string username);

        public StudentCourseDTO GetCourse(int UserId, int CourseId);
        public void DeleteCourse(int UserId, int CourseId);

    }
}
