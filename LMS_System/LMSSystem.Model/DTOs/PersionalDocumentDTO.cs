namespace LMS_System.LMSSystym.Model.DTOs
{
    public class PersionalDocumentDTO
    {
        public int PerDocId { get; set; }
        public string? PerDocName { get; set; }
        public DateTime? PerDocCreateDate { get; set; }
        public DateTime? PerDocLastModifiedDate { get; set; }
    }
}
