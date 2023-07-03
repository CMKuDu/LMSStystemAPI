using LMS_System.LMSSystem.Model.DTOs;
using LMS_System.LMSSystym.Model.DTOs;

namespace LMS_System.Repository.IRepository
{
    public interface IUserRepository
    {
        public Task<List<UserDTO>> GetAllUser();
        public Task<List<UserDTO>> GetAllUserByRoleId(int id);
        public Task<UserDTO> GetUserByIt(int id);
        public Task Update(UserDTO model, int id);
        public Task<int> Post(UserDTO model);
        public Task<UserDTO> Login(string userName, string password);
        Task<bool> CheckUserName(string username);
        Task<int> VerifyEmail(string token);
        Task<int> ForgotPassword(string email);
        Task<int> ResetPassword(string token, string password);
        Task<UserDTO> GetUserByRefreshToken(string refreshToken);
        Task SetRefreshToken(int userId, RefreshToken newRefreshToken);
        public Task Delete(int id);
    }
}
