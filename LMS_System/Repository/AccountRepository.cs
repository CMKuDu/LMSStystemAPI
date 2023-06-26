using LMS_System.LMSSystym.Model.Data;
using LMS_System.LMSSystym.Models.Models;
using LMS_System.Repository.IRepository;

namespace LMS_System.Repository
{
    public class AccountRepository : IAccountRepository 
    {
        private readonly DataContext _context;
        public AccountRepository(DataContext context)
        {
            _context = context;
        }

        public void Add(Account account)
        {
            if(account == null)
            {
                throw new ArgumentNullException(nameof(account));
            }
            _context.Accounts.Add(account);
        }

        public IEnumerable<Account> GetAll()
        {
            return _context.Accounts.ToList();
        }

        public Account GetById(int id)
        {
            return _context.Accounts.FirstOrDefault(x => x.AccountId == id);
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }
    }
}
