using AutoMapper;
using LMS_System.LMSSystym.Model.Data;
using LMS_System.LMSSystym.Model.DTOs;
using LMS_System.LMSSystym.Models.Models;
using LMS_System.Repository.IRepository;
using Microsoft.EntityFrameworkCore;

namespace LMS_System.Repository
{
    public class NotificationRepository : INotificationRepository
    {
        private readonly DataContext _datacontext;
        private readonly IMapper _mapper;
        public NotificationRepository(DataContext context, IMapper mapper)
        {
            _datacontext = context;
            _mapper = mapper;
        }
        public async Task Delete(int id)
        {
            var nt = await _datacontext.Notifications.FirstOrDefaultAsync(x => x.NotificationId == id);
            if(nt != null)
            {
                _datacontext.Notifications.Remove(nt);
                await _datacontext.SaveChangesAsync();
            }
        }

        public async Task<List<NotificationDTO>> GetAllNotification()
        {
            var nt = await _datacontext.Notifications.ToListAsync();
            return _mapper.Map<List<NotificationDTO>>(nt);
        }

        public async Task<NotificationDTO> GetNotificationById(int id)
        {
            var nt = await _datacontext.Notifications.FindAsync();
            return _mapper.Map<NotificationDTO>(nt);

        }

        public async Task<int> Post(NotificationDTO moodel)
        {
            var nt = _mapper.Map<Notification>(moodel);
            _datacontext.Notifications.Add(nt);
            return await _datacontext.SaveChangesAsync();
        }

        public async Task Update(NotificationDTO model, int id)
        {
            if(id != model.NotificationId)
            {
                var nt =  _mapper.Map<Notification>(model);
                _datacontext.Notifications.Update(nt);
                await _datacontext.SaveChangesAsync();
            }
        }
    }
}
