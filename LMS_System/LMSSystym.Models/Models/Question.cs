using System.ComponentModel.DataAnnotations;

namespace LMS_System.LMSSystym.Models.Models
{
    public class Question
    {
        [Key]
        public Guid QuestionId { get; set; }
        public string? QuesTitle { get; set; }
        public string? QuesName {get; set; }


    }
}
