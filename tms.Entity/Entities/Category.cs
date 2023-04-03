using System.ComponentModel.DataAnnotations.Schema;

namespace tms.Entity.Entities
{
    public class Category: EntityBase
    {
        
        public string Name_AZ { get; set; }
        public string Name_EN { get; set; }
        public string Name_RU { get; set; }

        // Relations
        public ICollection<Product> Products { get; set; }
    }
}
