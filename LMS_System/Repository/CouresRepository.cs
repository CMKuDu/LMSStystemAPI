using LMS_System.LMSSystym.Model.Data;
using LMS_System.LMSSystym.Models.Models;
using LMS_System.Repository.IRepository;

namespace LMS_System.Repository
{
    public class CouresRepository : ICouresRepository
    {
        private readonly DataContext _context;
        public CouresRepository(DataContext context)
        {
            _context = context;
        }
        public void Add(Courses account)
        {
            if (account == null)
            {
                throw new ArgumentNullException(nameof(account));
            }
            _context.Courses.Add(account);
        }

        public IEnumerable<Courses> GetAll()
        {
            return _context.Courses.ToList();
        }

        public Courses GetById(int id)
        {
            return _context.Courses.FirstOrDefault(x => x.CoursesId == id);
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges()>= 0);
        }
    }
}
