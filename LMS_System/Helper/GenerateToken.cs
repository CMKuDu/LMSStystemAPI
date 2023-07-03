using LMS_System.LMSSystym.Model.DTOs;
using LMS_System.Repository.IRepository;
using Microsoft.IdentityModel.Tokens;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace LMS_System.Helper
{
    public class GenerateToken
    {
        private readonly IConfiguration _configuration;
        private readonly IRoleRepository _roleRepository;
        public GenerateToken(IConfiguration configuration, IRoleRepository roleRepository)
        {
            _configuration = configuration;
            _roleRepository = roleRepository;
        }
        public async Task<string> CreateToken(UserDTO user)
        {
            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.Name),
                new Claim("Role", user.RoleId.ToString()),  
            };
            RoleDTO roleDTO = await _roleRepository.GetRoleById(user.RoleId);
            string roleName = roleDTO.RoleName;
            if(!string.IsNullOrEmpty(roleName))
            {
                claims.Add(new Claim(ClaimTypes.Role, roleName));
            }
            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(
                _configuration.GetSection("AppSettings:Token").Value));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: creds);

            var jwt = new JwtSecurityTokenHandler().WriteToken(token);

            return jwt;

        }
    }
}
