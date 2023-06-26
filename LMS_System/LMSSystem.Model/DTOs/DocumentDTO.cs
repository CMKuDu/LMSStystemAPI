namespace LMS_System.LMSSystym.Model.DTOs
{
    public class DocumentDTO
    {
        public int DocumentId { get; set; }
        public string? DocumentTitle { get; set; }
        public string? DocumentContent { get; set; }
        public bool? Active { get; set; }
    }
}
