using System.ComponentModel.DataAnnotations.Schema;

namespace tms.Entity.Entities
{
    public class Offer: EntityBase
    {
        [NotMapped]
        public Dictionary<string, string> Title { get; set; }
        [NotMapped]
        public Dictionary<string, string> Description { get; set; }

        public Guid ImageId { get; set; }
        public Image Image { get; set; }

    }
}
