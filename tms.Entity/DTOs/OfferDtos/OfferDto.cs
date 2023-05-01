using Microsoft.AspNetCore.Http;

namespace tms.Entity.DTOs.OfferDtos
{
    public class OfferDto
    {
        public string Title_AZ { get; set; }
        public string Title_EN { get; set; }
        public string Title_RU { get; set; }

        public string Description_AZ { get; set; }
        public string Description_EN { get; set; }
        public string Description_RU { get; set; }

        public IFormFile ImageFile { get; set; }
    }
}
