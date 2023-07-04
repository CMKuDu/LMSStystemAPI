using AutoMapper;
using LMS_System.LMSSystym.Model.Data;
using LMS_System.LMSSystym.Model.DTOs;
using LMS_System.LMSSystym.Models.Models;
using LMS_System.Repository.IRepository;
using Microsoft.EntityFrameworkCore;

namespace LMS_System.Repository
{
    public class ExamRepository : IExamRepository
    {
        private readonly DataContext _datecontext;

        private readonly IMapper _mapper;
        public ExamRepository(DataContext datacontext, IMapper mapper)
        {
            _datecontext = datacontext;
            _mapper = mapper;
        }
        public async Task Delete(int id)
        {
            var ex = await _datecontext.Exam.FirstOrDefaultAsync(x => x.EmxamId == id);
            if (ex != null)
            {
                _datecontext.Exam.Remove(ex);
                await _datecontext.SaveChangesAsync();
            }
        }

        public async Task<List<ExamDTO>> GetAllExam()
        {
            var ex = await _datecontext.Exam.ToListAsync();
            return _mapper.Map<List<ExamDTO>>(ex);
        }

        public async Task<ExamDTO> GetExamById(int id)
        {
            var ex = await _datecontext.Exam.FindAsync(id);
            return _mapper.Map<ExamDTO>(ex);

        }

        public async Task<int> Post(ExamDTO model)
        {
            var ex = _mapper.Map<Exam>(model);
            _datecontext.Exam.Add(ex);
            return await _datecontext.SaveChangesAsync();
        }

        public async Task Update(ExamDTO model, int id)
        {
            if (id == model.EmxamId)
            {
                var ex = _mapper.Map<Exam>(model);
                _datecontext.Exam.Update(ex);
                await _datecontext.SaveChangesAsync();
            }
        }
        public async Task<List<ExamDTO>>GetExamByCourse(int id)
        {
            var ex = await _datecontext.Exam
                .Where(x => x.EmxamId == id)
                .ToListAsync();

            return _mapper.Map<List<ExamDTO>>(ex);
        }



    }
}
