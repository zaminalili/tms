namespace tms.Entity.DTOs.PriceDtos
{
    public class PriceDto
    {
        public int Unit { get; set; }
        public int Type { get; set; }
        public int Variation { get; set; }
        public Guid CategoryId { get; set; }
    }
}
