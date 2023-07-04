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
    public class ExamController : ControllerBase
    {
        private readonly IExamRepository _exRepo;
        public ExamController (IExamRepository exRepo)
        {
            _exRepo = exRepo;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllExam()
        {
            await _exRepo.GetAllExam();
            return Ok();
        }
        [HttpGet("{id}"), Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetExamById(int id)
        {
            var ex = await _exRepo.GetExamById(id);
            if (id != null)
            {
                return Ok(new ApiResponse
                {
                    Success = true,
                    Message = "Successfuly",
                    Data = ex,
                });
            }
            else return BadRequest(new ApiResponse
            {
                Success = false,
                Message = "Successfuly",
                Data = null,
            });
        }
        [HttpPut("{ikd}"), Authorize (Roles = "Admin")]
        public async Task<IActionResult>Update(int id, ExamDTO model)
        {
            if(id != model.EmxamId)
            {
                return NotFound();
            }
            await _exRepo.Update(model, id);
            return Ok();
        }
        [HttpDelete("{id}"),Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int id)
        {
            await _exRepo.Delete(id);
            return Ok();
        }
        [HttpPost, Authorize(Roles = "Admin")]
        public async Task<IActionResult> Post(ExamDTO model)
        {
            int doc = await _exRepo.Post(model);
            if (doc != -1)
            {
                return Ok(new ApiResponse
                {
                    Success = true,
                    Message = "Successly",
                    Data = model,
                });

            }
            else return BadRequest(new ApiResponse
            {
                Success = false,
                Message = "Successly is a not",
                Data = null,
            });
        }

    }
}
