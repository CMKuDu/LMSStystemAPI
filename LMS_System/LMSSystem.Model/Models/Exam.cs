﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LMS_System.LMSSystym.Models.Models
{
    public class Exam
    {
        [Key]
        public int EmxamId { get; set; }
        public string? EmxamName { get; set; }
        [ForeignKey("Course")]
        public int CourseId { get; set; }
        public int QuestionId { get; set; }
        [ForeignKey("QuestionId")]
        public Question? Question { get; set; }
        public string? Answer {get; set; }
        public virtual ICollection<Question>? Questions { get; set; }
    }
}
