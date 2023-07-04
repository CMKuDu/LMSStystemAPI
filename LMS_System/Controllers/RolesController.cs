using LMS_System.LMSSystym.Model.DTOs;
using LMS_System.Repository.IRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LMS_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolesController : ControllerBase
    {
        private readonly IRoleRepository _roleRepo;
        public RolesController(IRoleRepository roleRepo)
        {
            _roleRepo = roleRepo;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllRole()
        {
            await _roleRepo.GetAllRole();
            return Ok();
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, RoleDTO model)
        {
            if(id != model.RolesId)
            {
                NotFound();
            }
            await _roleRepo.Update(model, id);
            return Ok();
        }
        public async Task<IActionResult> Delete(int id)
        {
            await _roleRepo.DeleteRole(id);
            return Ok();
        }
    }
}
