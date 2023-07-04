using AutoMapper;
using LMS_System.LMSSystym.Model.Data;
using LMS_System.LMSSystym.Model.DTOs;
using LMS_System.LMSSystym.Models.Models;
using LMS_System.Repository.IRepository;
using Microsoft.EntityFrameworkCore;

namespace LMS_System.Repository
{
    public class RoleRepository : IRoleRepository
    {
        private readonly DataContext _datacontext;
        private readonly IMapper _mapper;
        public RoleRepository(DataContext datacontext, IMapper mapper)
        {
            _datacontext = datacontext;
            _mapper = mapper;
        }

        public async Task DeleteRole(int id)
        {
            var rl = await _datacontext.Roles.FirstOrDefaultAsync(x => x.RolesId == id);

            if (rl != null)
            {
                _datacontext.Roles.Remove(rl);
                await _datacontext.SaveChangesAsync();
            }
            
        }

        public async Task<List<RoleDTO>> GetAllRole()
        {
            var rl = await _datacontext.Roles.ToListAsync();
            return _mapper.Map<List<RoleDTO>>(rl);
        }

        public async Task<RoleDTO> GetRoleById(int roleId)
        {
            var rl = await _datacontext.Roles.FindAsync(roleId);
            return _mapper.Map<RoleDTO>(rl);
        }

        public async Task<int> Post(RoleDTO model)
        {
            var rl = _mapper.Map<Roles>(model);
            _datacontext.Roles.Add(rl);
            await _datacontext.SaveChangesAsync();
            return rl.RolesId;
        }

        public async Task Update(RoleDTO model, int id)
        {
            if(id == model.RolesId)
            {
                var rl = _mapper.Map<Roles>(model);
                _datacontext.Roles.Update(rl);
                await _datacontext.SaveChangesAsync();
            }
        }
        public async Task<RoleDTO> GetRoleNameFormRoleId(int id)
        {
            var rl = await _datacontext.Roles.FindAsync(id);
            return _mapper.Map<RoleDTO>(rl);
        }
    }
}
