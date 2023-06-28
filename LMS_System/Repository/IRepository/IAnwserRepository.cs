using LMS_System.LMSSystem.Model.DTOs;

namespace LMS_System.Repository.IRepository
{
    public interface IAnwserRepository
    {
        public Task<List<AnwserDTO>> GetAllAnwser();
        public Task<AnwserDTO> GetAnwserByid(int id);
        public Task Update(AnwserDTO model, int id);
        public Task Delete(int id);
        public Task<int> Post(AnwserDTO model);
    }
}
