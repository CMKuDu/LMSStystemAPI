using LMS_System.LMSSystym.Model.DTOs;
using LMS_System.LMSSystym.Models.Models;

namespace LMS_System.Repository.IRepository
{
    public interface IDocumentRepository
    {
        public Task<List<DocumentDTO>> GetAllDocs();
        public Task<DocumentDTO> GetDocsByid(int id);
        public Task Update(int id, DocumentDTO model);
        public Task Delete(int id);
        public Task<int> PostDocs(DocumentDTO model);
    }
}
