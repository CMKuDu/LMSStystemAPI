using AutoMapper;
using LMS_System.LMSSystym.Model.DTOs;
using LMS_System.LMSSystym.Models.Models;
using LMS_System.Repository.IRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LMS_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DocumentController : ControllerBase
    {
        private readonly IDocumentRepository _docRepo;
        private readonly IMapper _mapper;
        public DocumentController (IMapper mapper, IDocumentRepository documentRepository)
        {
            _mapper = mapper;
            _docRepo = documentRepository;
        }
        [HttpGet]
        public ActionResult<IEnumerable<DocumentDTO>> GetAll()
        {
            var doc = _docRepo.GetAll();
            return Ok(_mapper.Map<DocumentDTO>(doc));
        }
        [HttpGet("{id}")]
        public ActionResult<DocumentDTO> GetById(int id)
        {
            var doc = _docRepo.GetById(id);
            if(doc !=null)
            {
                return Ok(_mapper.Map<DocumentDTO>(doc));
            }
            return NotFound();
            
        }
        [HttpPost]
        public ActionResult<DocumentDTO> Add(DocumentDTO docDTO)
        {
            var acc = _mapper.Map<Document>(docDTO);
            _docRepo.Add(acc);
            _docRepo.SaveChanges();

            var accDTO = _mapper.Map<DocumentDTO>(acc);
            return CreatedAtRoute(nameof(GetById), new { Id = accDTO.DocumentId }, accDTO);
        }
    }
}
