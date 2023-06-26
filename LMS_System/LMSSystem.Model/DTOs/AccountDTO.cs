using System.ComponentModel.DataAnnotations;

namespace LMS_System.LMSSystym.Model.DTOs
{
    public class AccountDTO
    {
        public int AccountId { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public string? Avarta { set; get; }
        public bool Active { set; get; }
        
    }
}
