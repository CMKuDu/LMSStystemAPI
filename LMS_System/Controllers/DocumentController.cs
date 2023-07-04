using LMS_System.LMSSystym.Model.DTOs;
using LMS_System.Prototypes;
using LMS_System.Repository.IRepository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LMS_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DocumentController : ControllerBase
    {
        private readonly IDocumentRepository _docRepo;
        public DocumentController(IDocumentRepository docRepo)
        {
            _docRepo = docRepo;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllDoc()
        {
            var doc = await _docRepo.GetAllDocs();
            return Ok(new ApiResponse
            {
                Success = true,
                Message = "Successfuly",
                Data = doc,
            }); 
        }
        [HttpGet("{id}"), Authorize(Roles ="Admin")]
                public async Task<IActionResult> GetDocById(int id)
        {
            var doc = await _docRepo.GetDocsByid(id);
            if (id != null)
            {
                return Ok(new ApiResponse
                {
                    Success = true,
                    Message = "Successfuly",
                    Data = doc,
                });
            }
            else
            {
                return BadRequest(new ApiResponse
                {
                    Success = false,
                    Message = "Successfuly is a not",
                    Data = null,
                });
            }
        }
        [HttpPut("{id}"), Authorize(Roles = "Admin")]
        public async Task<IActionResult> Update(int id, DocumentDTO model)
        {
            if (id != model.DocumentId)
            {
                NotFound();
            }
            await _docRepo.Update(id, model);
            return Ok();
        }
        [HttpDelete("{id}"), Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int id)
        {
            await _docRepo.Delete(id);
            return Ok();
        }
        public async Task<IActionResult> Post(DocumentDTO model)
        {
            int doc = await _docRepo.PostDocs(model);
            if (doc != -1)
            {
                return Ok(new ApiResponse
                {
                    Success = true,
                    Message = "Successfuly",
                    Data = doc,
                });
            }
            else return BadRequest(new ApiResponse
            {
                Success = false,
                Message = "Successfuly is not",
                Data = null,
            });
        }
    }
}
