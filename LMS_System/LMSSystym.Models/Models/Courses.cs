using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LMS_System.LMSSystym.Models.Models
{
    public class Courses
    {
        [Key]
        public Guid CoursesId { get; set; }
        public string? CoursesName { get; set; }
        public string? CoursesDescription { get; set; }
        public Guid SubjectId { set; get; }
        [ForeignKey("SubjectId")]
        public Subject? Subject { set; get; }
        public Guid AccountId { get; set; }
        [ForeignKey("AccountId")]
        public Account? Account { set; get; }


    }
}
