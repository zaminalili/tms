using System.ComponentModel.DataAnnotations.Schema;

namespace tms.Entity.Entities
{
    public class Offer: EntityBase
    {
        
        public string Title_AZ { get; set; }
        public string Title_EN { get; set; }
        public string Title_RU { get; set; }
        
        public string Description_AZ { get; set; }
        public string Description_EN { get; set; }
        public string Description_RU { get; set; }

        public Guid ImageId { get; set; }
        public Image Image { get; set; }

    }
}
