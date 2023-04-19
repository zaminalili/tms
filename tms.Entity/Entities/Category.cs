using System.ComponentModel.DataAnnotations.Schema;

namespace tms.Entity.Entities
{
    public class Category: EntityBase
    {
        
        public string Name_AZ { get; set; }
        public string Name_EN { get; set; }
        public string Name_RU { get; set; }
        public string? Subname_AZ { get; set; }
        public string? Subname_EN { get; set; }
        public string? Subname_RU { get; set; }
        public string? SubofSubname_AZ { get; set; }
        public string? SubofSubname_EN { get; set; }
        public string? SubofSubname_RU { get; set; }

        // Relations
        public ICollection<Product> Products { get; set; }
    }
}
