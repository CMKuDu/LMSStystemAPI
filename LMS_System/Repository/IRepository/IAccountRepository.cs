using LMS_System.LMSSystym.Model.DTOs;
using LMS_System.LMSSystym.Models.Models;

namespace LMS_System.Repository.IRepository
{
    public interface IAccountRepository
    {
        public Task<List<AccountDTO>> GetAllAccount();
        public Task<AccountDTO> GetByid(int id);
        public Task<int> Post(AccountDTO model);
        public Task Update(int id, AccountDTO model);
        public Task Delete(int id);

    }
}
