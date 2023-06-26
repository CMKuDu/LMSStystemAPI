using System.ComponentModel.DataAnnotations;

namespace LMS_System.LMSSystym.Model.DTOs
{
    public class NotificationDTO
    {
        public int NotificationId { get; set; }
        public bool Active { get; set; }
        public string? Title { get; set; }
        public string? Content { get; set; }
    }
}
