using LMS_System.LMSSystym.Model.DTOs;

namespace LMS_System.Repository.IRepository
{
    public interface IQuestionRepository
    {
        public Task<List<QuestionDTO>> GetAllQuestion();
        public Task<QuestionDTO> GetQuestionById(int id);
        public Task Update(QuestionDTO model, int id);
        public Task Delete(int id);
        public Task<int> Post(QuestionDTO model);
    }
}
