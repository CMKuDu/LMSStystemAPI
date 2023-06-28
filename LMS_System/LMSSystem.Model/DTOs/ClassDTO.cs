using System.ComponentModel.DataAnnotations;

namespace LMS_System.LMSSystem.Model.DTOs
{
    public class ClassDTO
    {
        public int ClassId { get; set; }
        public string? NameClass { get; set; }
        public string? DescriptionClass { get; set; }
    }
}
