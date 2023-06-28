using LMS_System.LMSSystym.Models.Models;
using System.ComponentModel.DataAnnotations;

namespace LMS_System.LMSSystem.Model.Models
{
    public class User_Class
    {
        [Key]
        public int UserId { get; set; }
        [Key]
        public int ClassId { get; set; }
        public virtual User? User { get; set; }
        public virtual Class? Class { get; set; }
    }
}
