using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LMS_System.LMSSystym.Models.Models
{
    public class User
    {
        [Key]
        public Guid UserId { set; get; }
        public string? UserName { set; get; }
        public string? Email { set; get; }
        public string? Phone { set; get; }
        public string? Specialized { set; get; }

        public Guid AccountId { set; get; }
        [ForeignKey("AccountId")]
        public Account? Account { set; get; }
        public Guid LocationId { set; get; }
        [ForeignKey("LocationId")]
        public Location? Location { set; get; }


    }
}
