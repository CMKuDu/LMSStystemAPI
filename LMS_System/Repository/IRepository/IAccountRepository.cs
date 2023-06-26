using LMS_System.LMSSystym.Model.DTOs;
using LMS_System.LMSSystym.Models.Models;

namespace LMS_System.Repository.IRepository
{
    public interface IAccountRepository
    {
        bool SaveChanges();
        IEnumerable<Account> GetAll();
        Account GetById(int id);
        void Add(Account account);
    }
}
