using LMS_System.LMSSystym.Models.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LMS_System.LMSSystem.Model.Models
{
    public class Anwser
    {
        [Key]
        public int AnwserId { get; set; }
        public string? AnwserName { get; set; }
        public string? AnwserDescription { get; set; }
        public int QuesId {get; set; }
        [ForeignKey("QuesId")]
        public Question QuestId { get; set; }
    }
}
