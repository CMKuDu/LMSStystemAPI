using System.ComponentModel.DataAnnotations;

namespace LMS_System.LMSSystym.Model.DTOs
{
    public class RoleDTO
    {
        public int RolesId { get; set; }
        [Required]
        public string? RoleName { get; set; }
        public string? Descrepsion { get; set; }
    }
}
