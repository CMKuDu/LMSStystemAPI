using LMS_System.LMSSystym.Model.DTOs;

namespace LMS_System.Repository.IRepository
{
    public interface INotificationRepository
    {
        public Task<List<NotificationDTO>> GetAllNotification();
        public Task<NotificationDTO> GetNotificationById(int id);
        public Task Update(NotificationDTO model, int id);
        public Task Delete(int id);
        public Task<int> Post(NotificationDTO moodel);
    }
}
