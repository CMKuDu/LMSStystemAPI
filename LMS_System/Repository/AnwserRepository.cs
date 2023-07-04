using AutoMapper;
using LMS_System.LMSSystem.Model.DTOs;
using LMS_System.LMSSystem.Model.Models;
using LMS_System.LMSSystym.Model.Data;
using LMS_System.Repository.IRepository;
using Microsoft.EntityFrameworkCore;

namespace LMS_System.Repository
{
    public class AnwserRepository : IAnwserRepository
    {
        private readonly DataContext _datacontext;
        private readonly IMapper _mapper;
        public AnwserRepository(DataContext datacontext, IMapper mapper)
        {
            _datacontext = datacontext;
            _mapper = mapper;
        }

        public async Task Delete(int id)
        {
            var ans = await _datacontext.Anwsers.FirstOrDefaultAsync(x => x.AnwserId == id);
            if (ans != null)
            {
                _datacontext.Anwsers.Remove(ans);
                await _datacontext.SaveChangesAsync();
            }
        }

        public async Task<List<AnwserDTO>> GetAllAnwser()
        {
            var ans = await _datacontext.Anwsers.ToListAsync();
            return _mapper.Map<List<AnwserDTO>>(ans);
        }

        public async Task<AnwserDTO> GetAnwserByid(int id)
        {
            var ans = await _datacontext.Anwsers.FindAsync(id);
            return _mapper.Map<AnwserDTO>(ans);
        }

        public async Task<int> Post(AnwserDTO model)
        {
            var ans = _mapper.Map<Anwser>(model);
                 _datacontext.Anwsers.Add(ans);
            return await _datacontext.SaveChangesAsync();
        }

        public async Task Update(AnwserDTO model, int id)
        {
            if(id == model.AnwserId)
            {
                var ans = _mapper.Map<Anwser>(model);
                _datacontext.Anwsers.Update(ans);
                await _datacontext.SaveChangesAsync();
            }
        }
    }
}
