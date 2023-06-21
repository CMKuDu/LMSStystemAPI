using System.ComponentModel.DataAnnotations;
using System.Drawing;

namespace LMS_System.LMSSystym.Models.Models
{
    public class PersionalDocument
    {
        [Key]
        public Guid PerDocId {  get; set; }
        public string? PerDocName { get; set; }
        public DateTime? PerDocCreateDate { get; set; }
        public DateTime? PerDocLastModifiedDate { get; set; }

    }
}
