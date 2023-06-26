using LMS_System.LMSSystym.Models.Models;

namespace LMS_System.Repository.IRepository
{
    public interface ICouresRepository
    {
        bool SaveChanges();
        IEnumerable<Courses> GetAll();
        Courses GetById(int id);
        void Add(Courses account);
    }
}
