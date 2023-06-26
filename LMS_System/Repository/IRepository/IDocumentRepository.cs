using LMS_System.LMSSystym.Models.Models;

namespace LMS_System.Repository.IRepository
{
    public interface IDocumentRepository
    {
        bool SaveChanges();
        IEnumerable<Document> GetAll();
        Document GetById(int id);
        void Add(Document account);
    }
}
