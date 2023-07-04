using AutoMapper;
using LMS_System.Helper;
using LMS_System.LMSSystem.Model.DTOs;
using LMS_System.LMSSystym.Model.Data;
using LMS_System.LMSSystym.Model.DTOs;
using LMS_System.LMSSystym.Models.Models;
using LMS_System.Prototypes;
using LMS_System.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using System.Data.Entity;

namespace LMS_System.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly DataContext _datacontext;
        private readonly IMapper _mapper;
        private readonly IEmailRepository _emailRepository;
        public UserRepository(DataContext context, IMapper mapper, IEmailRepository emailRepository)
        {
            _datacontext = context;
            _mapper = mapper;
            _emailRepository = emailRepository;
        }

        public async Task<bool> CheckUserName(string username)
        {
            var rs = await _datacontext.Users.CountAsync(x => x.UserName == username) > 0;
            Console.Write(rs);
            return rs;
        }

        public async Task Delete(int id)
        {
            var us = _datacontext.Users.FirstOrDefault(x => x.UserId == id);
            if (us != null)
            {
                _mapper.Map<UserDTO>(us);
                await _datacontext.SaveChangesAsync();
            }
        }

        public async Task<int> ForgotPassword(string email)
        {
            var us = await _datacontext.Users.FirstOrDefaultAsync(x => x.Email == email);
            if (us == null)
            {
                return -1;
            }
            us.PasswordResetToken = jwtHandler.CreateRandomToken();
            us.RefreshTokenCreated = DateTime.Now.AddDays(1);
            await _datacontext.SaveChangesAsync();
            var sendmail = new EmailDTO
            {
                To = email,
                Subject = "Reset password link",
                Body = "<a target=" + "_blank" + " href=" + "http://localhost:7254/api/Users/reset-password/" + us.PasswordResetToken + ">CLICK HERE</a>"
            };
            await _emailRepository.SendEmailAsync(sendmail);
            return -1;
        }

        public async Task<List<UserDTO>> GetAllUser()
        {
            var us = await _datacontext.Users.ToListAsync();
            return _mapper.Map<List<UserDTO>>(us);
        }

        public async Task<List<UserDTO>> GetAllUserByRoleId(int id)
        {
            var us = await _datacontext.Users
                .Where(x => x.RolesId == id)
                .ToListAsync();
            return _mapper.Map<List<UserDTO>>(us);
        }

        public async Task<UserDTO> GetUserByIt(int id)
        {
            var us = await _datacontext.Users.FindAsync(id);
            return _mapper.Map<UserDTO>(us);
        }

        public async Task<UserDTO> GetUserByRefreshToken(string refreshToken)
        {
            var us = await _datacontext.Users.FirstOrDefaultAsync(x => x.RefreshToken == refreshToken);
            if (us == null)
            {
                return null;
            }
            return _mapper.Map<UserDTO>(us);
        }

        public async Task<UserDTO> Login(string userName, string password)
        {
            var us = await _datacontext.Users.SingleOrDefaultAsync(x => x.UserName == userName);
            if (us == null)
            {
                return null;
            }
            if (password == null)
            {
                return null;
            }
            return _mapper.Map<UserDTO>(us);
        }

        public async Task<int> Post(UserDTO model)
        {
            var us = _mapper.Map<User>(model);
            if (await _datacontext.Users.CountAsync(x => x.Email == model.Email) > 0)
            {
                return -1;
            } 
            if (await _datacontext.Users.CountAsync(x => x.UserName == model.Username) > 0)
            {
                return -1;
            }
            var passwordHash = HashMD5.GetMD5Hash(model.Password);
            us.Password = passwordHash;
            us.IsActive = true;
            us.RolesId = 1;
            us.VerificationToken = jwtHandler.CreateRandomToken();
             _datacontext.Add(us);
            await _datacontext.SaveChangesAsync();
            return us.UserId;

        }

        public async Task<int> ResetPassword(string token, string password)
        {
            var u = await _datacontext.Users.FirstOrDefaultAsync(x => x.UserName == "dau");
            var us = await _datacontext.Users.FirstOrDefaultAsync(u => u.PasswordResetToken == token);
            if (us == null || us.RefreshTokenExpries < DateTime.Now)
            {
                return -1;
            }
            string passwordHash = HashMD5.GetMD5Hash(password);

            us.Password = passwordHash;
            us.PasswordResetToken = token;
            us.ResetTokenExpries = null;

            await _datacontext.SaveChangesAsync();
            return 1;
        }

        public async Task SetRefreshToken(int userId, RefreshToken newRefreshToken)
        {
            var us = await _datacontext.Users.FindAsync(userId);
            if (userId != null)
            {
                us.RefreshToken = newRefreshToken.Token;
                us.RefreshTokenCreated = newRefreshToken.Created;
                us.RefreshTokenExpries = newRefreshToken.Expires;
                await _datacontext.SaveChangesAsync();
            }
        }

        public async Task UpdateUserAsync(UserDTO model, int id)
        {
            if (id == model.UserID)
            {
                var us = _mapper.Map<User>(model);
                _datacontext.Users!.Update(us);
                await _datacontext.SaveChangesAsync();
            }
        }

        public async Task<int> VerifyEmail(string token)
        {
            var us = await _datacontext.Users.FirstOrDefaultAsync(x => x.VerificationToken == token);
            if (us == null)
            {
                return -1;
            }
            us.VerifyAt = DateTime.UtcNow;
            try
            {
                await _datacontext.SaveChangesAsync();
                return 1;
            }
            catch (DbUpdateException)
            {
                return -1;
            }
        }
    }
}
