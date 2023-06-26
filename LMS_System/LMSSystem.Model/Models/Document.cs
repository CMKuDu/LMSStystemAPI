using System.ComponentModel.DataAnnotations;

namespace LMS_System.LMSSystym.Models.Models
{
    public class Document
    {
        [Key]
        public int DocumentId { get; set; }
        public string? DocumentTitle { get; set; }
        public string? DocumentContent { get; set; }
        public bool? Active { get; set; }
    }
}
