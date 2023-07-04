using AutoMapper;
using LMS_System.LMSSystym.Model.Data;
using LMS_System.LMSSystym.Model.DTOs;
using LMS_System.LMSSystym.Models.Models;
using LMS_System.Repository.IRepository;
using Microsoft.EntityFrameworkCore;

namespace LMS_System.Repository
{
    public class AccountRepository : IAccountRepository
    {
        private readonly DataContext _dataContext;
        private readonly IMapper _mapper;
        public AccountRepository(DataContext context, IMapper map)
        {
            _dataContext = context;
            _mapper = map;
        }

        public async Task Delete(int id)
        {
            var acc = await _dataContext.Accounts.SingleOrDefaultAsync(x => x.AccountId == id);
            if (acc != null)
            {
                _dataContext.Accounts.Remove(acc);
                await _dataContext.SaveChangesAsync();
            }
        }

        public async Task<List<AccountDTO>> GetAllAccount()
        {
            var acc = await _dataContext.Accounts.ToListAsync();
            return _mapper.Map<List<AccountDTO>>(acc);
        }

        public async Task<AccountDTO> GetByid(int id)
        {
            var acc = await _dataContext.Accounts.FindAsync(id);
            return _mapper.Map<AccountDTO>(acc);
        }

        public async Task<int> Post(AccountDTO model)
        {
            var acc = _mapper.Map<Account>(model);
            _dataContext.Accounts.Add(acc);
            return acc.AccountId;
        }

        public async Task Update(int id, AccountDTO model)
        {
            if(id == model.AccountId)
            {
                var acc = _mapper.Map<Account>(model);
                _dataContext.Accounts.Update(acc);
                await _dataContext.SaveChangesAsync();
            }
        }
    }
}
