namespace tms.Entity.Entities
{
    public class Category: EntityBase
    {
        public Dictionary<string, string> Name { get; set; }

        // Relations
        public ICollection<Product> Products { get; set; }
    }
}
