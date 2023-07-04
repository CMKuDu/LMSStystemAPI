using AutoMapper;
using LMS_System.LMSSystym.Model.Data;
using LMS_System.LMSSystym.Model.DTOs;
using LMS_System.LMSSystym.Models.Models;
using LMS_System.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace LMS_System.Repository
{
    public class DoscumentRepository : IDocumentRepository
    {
        private readonly DataContext _dataContext;
        private readonly IMapper _mapper;
        public DoscumentRepository(DataContext dataContext, IMapper mapper)
        {
            _dataContext = dataContext;
            _mapper = mapper;
        }
        public async Task Delete(int id)
        {
            var dc = await _dataContext.Documents.FirstOrDefaultAsync(x => x.DocumentId == id);
            if (dc != null)
            {
                 _dataContext.Documents.Remove(dc);
                await _dataContext.SaveChangesAsync();

            }
        }

        public async Task<List<DocumentDTO>> GetAllDocs()
        {
            var docs = await _dataContext.Documents.ToListAsync();
            return _mapper.Map<List<DocumentDTO>>(docs);
        }

        public async Task<DocumentDTO> GetDocsByid(int id)
        {
            var docs = await _dataContext.Documents.FindAsync(id);
            return _mapper.Map<DocumentDTO>(docs);

        }

        public async Task<int> PostDocs(DocumentDTO model)
        {
            var docs = _mapper.Map<Document>(model);
            _dataContext.Documents.Add(docs);
            return await _dataContext.SaveChangesAsync();
        }

        public async Task Update(int id, DocumentDTO model)
        {
            if (id == model.DocumentId)
            {
                var docs = _mapper.Map<Document>(model);
                _dataContext.Documents.Update(docs);
                await _dataContext.SaveChangesAsync();
            }   
        }
    }
}
