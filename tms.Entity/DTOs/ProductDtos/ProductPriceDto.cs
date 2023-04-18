using tms.Entity.Entities;

namespace tms.Entity.DTOs.ProductDtos
{
    public class ProductPriceDto
    {
        public string Name { get; set; }
        public string Code { get; set; }
        public int Price { get; set; }
        public Category Category { get; set; }
    }
}
