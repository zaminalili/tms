namespace tms.Entity.Entities
{
    public class EntityBase: IEntityBase
    {
        public Guid Id { get; set; }
        public string CreatedBy { get; set; }
        public string? EditedBy { get; set; }
        public string? DeletedBy { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public DateTime? EditedDate { get; set; }
        public DateTime? DeletedDate { get; set; }
        public bool IsDeleted { get; set; } = false;
    }
}
