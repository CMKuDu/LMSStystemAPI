using System.ComponentModel.DataAnnotations;

namespace LMS_System.LMSSystym.Models.Models
{
    public class Location
    {
        [Key]
        public int LocationId { get; set; }
        public string? Address { get; set; }
        public string? DetailsAddress { get; set; }
    }
}
