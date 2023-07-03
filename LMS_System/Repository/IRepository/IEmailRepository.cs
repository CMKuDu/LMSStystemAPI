using LMS_System.LMSSystem.Model.DTOs;

namespace LMS_System.Repository.IRepository
{
    public interface IEmailRepository
    {
        Task SendEmailAsync(EmailDTO request, string filepath = null!);
    }
}
