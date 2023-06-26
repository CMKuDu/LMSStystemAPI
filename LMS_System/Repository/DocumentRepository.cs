using LMS_System.LMSSystym.Model.Data;
using LMS_System.LMSSystym.Models.Models;
using LMS_System.Repository.IRepository;

namespace LMS_System.Repository
{
    public class DocumentRepository : IDocumentRepository
    {
        private readonly DataContext _context;
        public DocumentRepository(DataContext context)
        {
            _context = context;
        }

        public void Add(Document doc)
        {
            if (doc == null)
            {
                throw new ArgumentNullException(nameof(doc));
            }
            _context.Documents.Add(doc);
        }

        public IEnumerable<Document> GetAll()
        {
           return _context.Documents.ToList();
        }

        public Document GetById(int id)
        {
            return _context.Documents.FirstOrDefault(x => x.DocumentId == id);
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }
    }
}
