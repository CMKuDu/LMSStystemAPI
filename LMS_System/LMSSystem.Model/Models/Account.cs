using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LMS_System.LMSSystym.Models.Models
{
    public class Account
    {
        [Key]
        public int AccountId { get; set; }
        [Required]
        public string? Email { get; set; }
        [Required]
        public string? Password { get; set; }
        public string? Avarta { set; get; }
        public bool Active { set; get; }
        public int UserId { set; get; }
        [ForeignKey("UserId")]
        public User? User { set; get; }
        public int RolesId { get; set; }
        [ForeignKey("RolesId")]
        public Roles? Roles { get; set; }
        public int DocumentId { get; set; }
        [ForeignKey("DocumentId")]
        public Document? Document { get; set; }
        public int NotificationId { get; set; }
        [ForeignKey("NotificationId")]
        public Notification? Notification { get; set; }
        

    }
}
