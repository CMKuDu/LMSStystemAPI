using LMS_System.LMSSystym.Model.DTOs;

namespace LMS_System.Repository.IRepository
{
    public interface IRoleRepository
    {
        public Task<List<RoleDTO>> GetAllRole();
        public Task<RoleDTO> GetRoleById(int roleId);
        public Task Update(RoleDTO model, int id);
        public Task DeleteRole(int id);
        public Task<int> Post(RoleDTO model);
    }
}
