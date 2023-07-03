using LMS_System.LMSSystem.Model.Models;
using LMS_System.LMSSystym.Models.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace LMS_System.LMSSystym.Model.DTOs
{
    public class QuestionDTO
    {
        public int QuestionId { get; set; }
        public string? QuesTitle { get; set; }
        [ForeignKey("Exam")]
        public int ExamId { get; set; }
        public string? QuesName { get; set; }

        public ICollection<Anwser>? Anwsers { get; set; }
        public virtual Exam? Exam { get; set; }
    }
}
