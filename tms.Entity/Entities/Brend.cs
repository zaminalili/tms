namespace tms.Entity.Entities
{
    public class Brend: EntityBase
    {
        public string Name { get; set; }
        public Guid ImageId { get; set; }
        public Image Image { get; set; }
    }
}
