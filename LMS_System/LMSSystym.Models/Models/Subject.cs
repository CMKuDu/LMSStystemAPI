using System.ComponentModel.DataAnnotations;

namespace LMS_System.LMSSystym.Models.Models
{
    public class Subject
    {
        [Key]
        public Guid SubjectId { set; get; }
        public string? SubjectName { set; get; }
        public string? SubjectDescription { set; get; }
        public string? SubjectContent { set; get; }
    }
}
