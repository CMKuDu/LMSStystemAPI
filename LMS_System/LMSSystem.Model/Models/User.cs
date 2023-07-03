using LMS_System.LMSSystem.Model.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LMS_System.LMSSystym.Models.Models
{
    [Table("User")]
    public class User
    {
        [Key]
        public int UserId { set; get; }
        [Required]
        [ForeignKey("Roles")]
        public int RolesId { get; set; }
        public virtual Roles? Roles { get; set; }
        public string? UserName { set; get; }
        public string? Email { set; get; }
        public string? Phone { set; get; }
        public string? Specialized { set; get; }
        public string? Password { get; set; }
        public string? PasswordResetToken { get; set; }

        public DateTime? ResetTokenExpries { get; set; }

        public string? VerificationToken { get; set; }

        public DateTime? VerifyAt { get; set; }

        public string? RefreshToken { get; set; }

        public DateTime? RefreshTokenCreated { get; set; }

        public DateTime? RefreshTokenExpries { get; set; }
        public DateTime? CreateAt { get; set; }
        public DateTime? UpdateAt { get; set; }
        public ICollection<User_Class>? User_Class { get; set; }
    }
}
