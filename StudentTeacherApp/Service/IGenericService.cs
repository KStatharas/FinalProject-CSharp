using StudentTeacherApp.Models;

namespace StudentTeacherApp.Service
{
    public interface IGenericService
    {

        public void AddEntity<T>(T t);
        public void UpdateEntity<T>(T t);
        public void DeleteEntity<T>(int id);
        public T GetEntity<T>(int id);
        public List<T> GetAllEntities<T>();

    }
}
