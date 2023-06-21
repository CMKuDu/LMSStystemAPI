using System.ComponentModel.DataAnnotations;

namespace LMS_System.LMSSystym.Models.Models
{
    public class Notification
    {
        [Key]
        public Guid NotificationId { get; set; }
        public bool Active { get; set; }
        public string? Title { get; set; }
        [Range(0, int.MaxValue)]
        public string? Content { get; set; }
    }
}
