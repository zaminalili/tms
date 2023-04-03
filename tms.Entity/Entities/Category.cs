using System.ComponentModel.DataAnnotations.Schema;

namespace tms.Entity.Entities
{
    public class Category: EntityBase
    {
        [NotMapped]
        public Dictionary<string, string> Name { get; set; }

        // Relations
        public ICollection<Product> Products { get; set; }
    }
}
