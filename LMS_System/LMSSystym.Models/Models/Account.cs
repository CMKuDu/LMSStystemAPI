using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LMS_System.LMSSystym.Models.Models
{
    public class Account

    {
        [Key]
        public Guid AccountId { get; set; }
        [Required]
        public string? Email { get; set; }
        [Required]
        public string? Password { get; set; }
        public string? Avarta { set; get; }
        public bool Active { set; get; }
        public Guid RolesId { get; set; }
        [ForeignKey("RolesId")]
        public Roles? Roles { get; set; }
        public Guid DocumentId { get; set; }
        [ForeignKey("DocumentId")]
        public Document? Document { get; set; }
        public Guid NotificationId { get; set; }
        [ForeignKey("NotificationId")]
        public Notification? Notification { get; set; }

    }
}
