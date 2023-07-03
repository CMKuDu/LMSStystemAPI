using LMS_System.LMSSystem.Model.DTOs;
using LMS_System.Repository.IRepository;
using Microsoft.AspNetCore.Identity;

namespace LMS_System.Repository
{
    public class EmailRepository : IEmailRepository
    {
        public Task SendEmailAsync(EmailDTO request, string filepath = null!)
        {
            throw new NotImplementedException();
        }
    }
}
