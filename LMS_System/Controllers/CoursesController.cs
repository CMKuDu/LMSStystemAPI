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
    public class CoursesController : ControllerBase
    {
        private readonly ICouresRepository _couresRepo;
        public CoursesController(ICouresRepository couresRepo)
        {
            _couresRepo = couresRepo;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllCourses()
        {
            var cou = await _couresRepo.GetAllCourses();
            return Ok(new ApiResponse
            {
                Success = true,
                Message = "Succsefuly",
                Data = cou,
            });
        }
        [HttpGet("{id}"), Authorize(Roles ="Admin")]
        public async Task<IActionResult> GetCourseById(int id)
        {
            var cou = await _couresRepo.GetCourses(id);
            if(id != null)
            {
                return Ok(new ApiResponse
                {
                    Success = true,
                    Message = "Successfuly",
                    Data = cou,
                });
            }
            return BadRequest(new ApiResponse
            {
                Success = false,
                Message="Get anwser fail",
                Data = null,
            });
        }
        [HttpPut("{id}"), Authorize(Roles = "Admin")]
        public async Task<IActionResult> Update(int id,CoursesDTO model)
        {
           if(id != model.CoursesId)
            {
                return NotFound();
            }
            await _couresRepo.Update(id, model);
            return Ok();
        }
        [HttpDelete("{id}"), Authorize(Roles ="Admin")]
        public async Task<IActionResult> Delete(int id)
        {
            await _couresRepo.Delele(id);
            return Ok();
        }
        [HttpPost,Authorize(Roles = "Admin")]
        public async Task<IActionResult> Post(CoursesDTO model)
        {
            int id = await _couresRepo.PostCourses(model);
            if(id != -1)
            {
                return Ok(new ApiResponse
                {
                    Success= true,
                    Message ="Successfuly",
                    Data = id,
                });
            }
            else
            {
               return    BadRequest(new ApiResponse
                {
                    Success = false,
                    Message = "not Successfuly",
                    Data = null,
                });
            }
        }
    }
}
