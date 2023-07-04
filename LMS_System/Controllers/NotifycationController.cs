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
    public class NotifycationController : ControllerBase
    {
        private readonly INotificationRepository _noRepo;
        public NotifycationController(INotificationRepository noRepo)
        {
            _noRepo = noRepo;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            await _noRepo.GetAllNotification();
            return Ok();
        }
        [HttpGet("{id}"), Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetNotificationById(int id)
        {
            var nt = await _noRepo.GetNotificationById(id);
            if (id != null)
            {
                return Ok(new ApiResponse
                {
                    Success = true,
                    Message = "Successfuly",
                    Data = nt,
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
        public async Task<IActionResult> Update(int id,NotificationDTO model)
        {
            if(id != model.NotificationId)
            {
                return NotFound();
            }
            await _noRepo.Update(model, id);
            return Ok();
        }
        [HttpDelete("{id}"),Authorize (Roles = "Admin")]
        public async Task<IActionResult> Dele(int id)
        {
            await _noRepo.Delete(id);
            return Ok();
        }
        [HttpPost]
        public async Task<IActionResult>Post(NotificationDTO model)
        {
            int noId = await _noRepo.Post(model);
            if(noId != -1)
            {
                return Ok(new ApiResponse
                {
                    Success = true,
                    Message = "Successfuly",
                    Data = model
                });
            }
            return BadRequest(new ApiResponse
            {
                Success = false,
                Message = "Successfuly",
                Data = null
            });
        }
    }
}
