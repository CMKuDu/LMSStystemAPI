using System.ComponentModel.DataAnnotations;

namespace LMS_System.LMSSystym.Models.Models
{
    public class Roles
    {
        [Key]
        public int RolesId { get; set; }
        [Required]
        public string? RoleName { get; set; }
        public string? Descrepsion { get; set; }
    }
}
