namespace tms.Entity.Entities
{
    public class Offer: EntityBase
    {
        public Dictionary<string, string> Title { get; set; }
        public Dictionary<string, string> Description { get; set; }

        public Guid ImageId { get; set; }
        public Image Image { get; set; }

    }
}
