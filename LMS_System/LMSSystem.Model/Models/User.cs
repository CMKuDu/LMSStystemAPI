using LMS_System.LMSSystem.Model.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LMS_System.LMSSystym.Models.Models
{
    public class User
    {
        [Key]
        public int UserId { set; get; }
        public string? UserName { set; get; }
        public string? Email { set; get; }
        public string? Phone { set; get; }
        public string? Specialized { set; get; }
        public int LocationId { set; get; }
        [ForeignKey("LocationId")]
        public Location? Location { set; get; }
        public ICollection<User_Class>? User_Class { get; set; }


    }
}
