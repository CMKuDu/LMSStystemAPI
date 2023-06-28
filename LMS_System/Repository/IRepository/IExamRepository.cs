using LMS_System.LMSSystym.Model.DTOs;

namespace LMS_System.Repository.IRepository
{
    public interface IExamRepository
    {
        public Task<List<ExamDTO>> GetAllExam();
        public Task<ExamDTO> GetExamById(int id);
        public Task<int> Post(ExamDTO model);
        public Task Delete(int id);
        public Task Update(ExamDTO model, int id);
        public Task<List<ExamDTO>> GetExamByCourse(int id);
    }
}
