namespace tms.Entity.Entities
{
    public class Image: EntityBase
    {
        public string FileName { get; set; }
        public string FileType { get; set; }

        // Relations
        public ICollection<Product> Products { get; set; }
        public ICollection<Offer> Offers { get; set; }
    }
}
