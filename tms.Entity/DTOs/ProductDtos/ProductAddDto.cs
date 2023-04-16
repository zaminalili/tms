using Microsoft.AspNetCore.Http;
using tms.Entity.DTOs.CategoryDTOs;
using tms.Entity.Entities;

namespace tms.Entity.DTOs.ProductDtos
{
    public class ProductAddDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public string About_AZ { get; set; }
        public string About_EN { get; set; }
        public string About_RU { get; set; }
        public string Code { get; set; }
        public string Brend { get; set; }
        public string Country_AZ { get; set; }
        public string Country_EN { get; set; }
        public string Country_RU { get; set; }
        public int? Price { get; set; }
        public int ViewCount { get; set; }


        public string? Size { get; set; }
        public string? Volume { get; set; }
        public string? Fuel { get; set; }
        public string? HeatingArea { get; set; }
        public string? Power { get; set; }
        public string? Weight { get; set; }
        public string? Pressure { get; set; }
        public string? Diameter { get; set; }
        public string? MaximumTemperature { get; set; }
        public string? Angle { get; set; }
        public Guid CategoryId { get; set; }
        //public Category Category { get; set; }
        //public Guid ImageId { get; set; }
        //public Image Image { get; set; }

        public IFormFile ImageFile { get; set; }
	}
}
