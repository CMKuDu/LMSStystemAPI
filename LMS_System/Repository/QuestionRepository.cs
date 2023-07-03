using AutoMapper;
using LMS_System.LMSSystym.Model.Data;
using LMS_System.LMSSystym.Model.DTOs;
using LMS_System.LMSSystym.Models.Models;
using LMS_System.Repository.IRepository;
using Microsoft.EntityFrameworkCore;

namespace LMS_System.Repository
{
    public class QuestionRepository : IQuestionRepository
    {
        private readonly DataContext _datacontext;
        private readonly Mapper _mapper;
        public QuestionRepository(DataContext datacontext, Mapper mapper)
        {
            _datacontext = datacontext;
            _mapper = mapper;
        }

        public async Task Delete(int id)
        {
            var qs = await _datacontext.Question.FirstOrDefaultAsync(x => x.QuestionId == id);
            if (qs != null)
            {
                _datacontext.Question.Remove(qs);
                await _datacontext.SaveChangesAsync();
            }
        }

        public async Task<List<QuestionDTO>> GetAllQuestion()
        {
            var qs = await _datacontext.Question.ToListAsync();
            return _mapper.Map<List<QuestionDTO>>(qs);
        }

        public async Task<QuestionDTO> GetQuestionById(int id)
        {
            var qs = await _datacontext.Question.FindAsync(id);
            return _mapper.Map<QuestionDTO>(qs);
        }

        public async Task<int> Post(QuestionDTO model)
        {
            var qs = _mapper.Map<Question>(model);
            _datacontext.Question.Add(qs);
            return await _datacontext.SaveChangesAsync();

        }

        public async Task Update(QuestionDTO model, int id)
        {
            if (id != null)
            {
                var qs = _mapper.Map<Question>(id);
                _datacontext.Question.Update(qs);
                await _datacontext.SaveChangesAsync();

            }

        }
        public async Task<List<QuestionDTO>> GetQuestionByExam(int id)
        {
            var qs = _datacontext.Question
                .Where(x => x.ExamId == id)
                .ToListAsync();
            return _mapper.Map<List<QuestionDTO>>(qs);
        }
    }
}
