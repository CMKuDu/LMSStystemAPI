using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LMS_System.LMSSystym.Models.Models
{
    public class Courses
    {
        [Key]
        public int CoursesId { get; set; }
        public string? CoursesName { get; set; }
        public string? CoursesDescription { get; set; }
        public string? Content { get; set; }
        public int AccountId { get; set; }
        [ForeignKey("AccountId")]
        public Account? Account { set; get; }


    }
}
