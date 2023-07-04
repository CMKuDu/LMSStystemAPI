using AutoMapper;
using LMS_System.Helper;
using LMS_System.LMSSystem.Model.DTOs;
using LMS_System.LMSSystem.Model.Models;
using LMS_System.LMSSystym.Models.Models;
using LMS_System.Prototypes;
using LMS_System.Repository.IRepository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Drawing.Printing;

namespace LMS_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnwserController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IAnwserRepository _anRepo;
        private IConfiguration _configuration;
        private ILogger<UsersController> _logger;
        public AnwserController(IMapper mapper, IAnwserRepository anRepo, IConfiguration configuration, ILogger<UsersController> logger)
        {
            _mapper = mapper;
            _anRepo = anRepo;
            _configuration = configuration;
            _logger = logger;
        }
        [HttpGet, Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetAllAnswer()
        {
            // Gọi phương thức GetAllAnswers từ UserRepository (_userRepo)
            var answers = await _anRepo.GetAllAnwser();

            // Trả về danh sách câu trả lời trong body của response
            return Ok(new ApiResponse
            {
                Success = true,
                Message = "Get all answers success",
                Data = answers
            });
        }
        [HttpGet("GetAnswerById/{answerId}"), Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetAnswerById(int id)
        {
            // Gọi phương thức GetAnswerById từ UserRepository (_userRepo)
            var answer = await _anRepo.GetAnwserByid(id);

            if (answer != null)
            {
                // Trả về câu trả lời tương ứng trong body của response
                return Ok(new ApiResponse
                {
                    Success = true,
                    Message = "Get answer by ID success",
                    Data = answer
                });
            }
            else
            {
                // Không tìm thấy câu trả lời, trả về mã lỗi NotFound (404)
                return NotFound(new ApiResponse
                {
                    Success = false,
                    Message = "Answer not found",
                    Data = null
                });
            }
        }
        [HttpPut("UpdateAnswer/{answerId}"), Authorize(Roles = "Admin")]
        public async Task<IActionResult> UpdateAnswer(int id, AnwserDTO model)
        {
            // Gọi phương thức UpdateAnswer từ UserRepository (_userRepo)
            if (id != model.AnwserId)
            {
                return NotFound();
            }
            await _anRepo.Update(model, id);
            return Ok();
        }
        [HttpDelete("DeleteAnswer/{answerId}"), Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteAnswer(int id)
        {
            // Gọi phương thức DeleteAnswer từ UserRepository (_userRepo)
            await _anRepo.Delete(id);
            return Ok();
        }
        [HttpPost("CreateAnswer"),Authorize (Roles = "Admin")]
        public async Task<IActionResult> CreateAnswer(AnwserDTO model)
        {
            // Gọi phương thức CreateAnswer từ UserRepository (_userRepo)
            int newAnswerId = await _anRepo.Post(model);

            if (newAnswerId != -1)
            {
                // Tạo câu trả lời thành công, trả về mã thành công (200) và thông tin câu trả lời vừa tạo trong body của response
                return Ok(new ApiResponse
                {
                    Success = true,
                    Message = "Create answer success",
                    Data = newAnswerId
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
