namespace tms.Entity.DTOs.CategoryDTOs
{
    public class CategoryDTO
    {
        public string Name_AZ { get; set; }
        public string CretedBy { get; set; }
        public string? EditedBy { get; set; }
        public string? DeletedBy { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
