using System.ComponentModel.DataAnnotations.Schema;

namespace tms.Entity.Entities
{
    public class Product: EntityBase
    {
        // Columns
        public string Name { get; set; }
        [NotMapped]
        public Dictionary<string, string> About { get; set; }
        public string Code { get; set; }
        public string Brend { get; set; }
        [NotMapped]
        public Dictionary<string, string> Country { get; set; }
        public int? Price { get; set; }
        public int ViewCount { get; set; } = 0;


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


        // Relations
        public Guid CategoryId { get; set; }
        public Category Category { get; set; }

        public Guid ImageId { get; set; }
        public Image Image { get; set; }

    }
}
