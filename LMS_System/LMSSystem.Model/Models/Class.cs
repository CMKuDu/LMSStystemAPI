using System.ComponentModel.DataAnnotations;

namespace LMS_System.LMSSystem.Model.Models
{
    public class Class
    {
        [Key]
        public int ClassId { get; set; }
        [Required]
        public string? NameClass { get; set; }
        public string? DescriptionClass { get; set;}
    }
}
