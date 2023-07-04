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
    public class QuestionController : ControllerBase
    {
        private readonly IQuestionRepository _quesRepo;
        public QuestionController(IQuestionRepository quesRepo)
        {
            _quesRepo = quesRepo;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            await _quesRepo.GetAllQuestion();
            return Ok();
        }
        [HttpGet("{id}"), Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetById(int id)
        {
            var qus = await _quesRepo.GetQuestionById(id);
            if (id != null)
            {
                return Ok(new ApiResponse
                {
                    Success = true,
                    Message = "Successfuly",
                    Data = qus,
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
        [HttpPut("{id}"), Authorize (Roles = "Admin")]
        public async Task<IActionResult> Update(int id, QuestionDTO model)
        {
            if(id != model.QuestionId)
            {
                return NotFound();
            }
            await _quesRepo.Update(model, id);
            return Ok();

        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _quesRepo.Delete(id);
            return Ok();
        }
        [HttpPost, Authorize (Roles = "Admin")]
        public async Task<IActionResult> Post(QuestionDTO model)
        {
            int id = await _quesRepo.Post(model);
            if(id != -1)
            {
                return Ok(new ApiResponse
                {
                    Success = true,
                    Message = "Create answer success",
                    Data = id
                });
            }
            else
            {
                // Đã xảy ra lỗi khi tạo câu trả lời, trả về mã lỗi BadRequest (400) hoặc có thể xem xét các mã lỗi khác tùy trường hợp
                return BadRequest(new ApiResponse
                {
                    Success = false,
                    Message = "Error creating answer",
                    Data = null
                });
            }
        }
        
    }
}
