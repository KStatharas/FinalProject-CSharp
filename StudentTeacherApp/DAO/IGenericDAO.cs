using StudentTeacherApp.Data.Models;

namespace StudentTeacherApp.DAO
{
    public interface IGenericDAO<T>
    {
        public void Add(IUser user, string uName);
        public void Update(IUser user, string uName);
        public void Delete(int id, string uName);
        public IUser Get(int id, string uName);
        public List<IUser> GetAll(string uName);
    }
}
