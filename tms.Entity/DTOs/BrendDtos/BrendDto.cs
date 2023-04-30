using Microsoft.AspNetCore.Http;

namespace tms.Entity.DTOs.BrendDtos
{
	public class BrendDto
	{
		public string Name { get; set; }
		public IFormFile ImageFile { get; set; }
	}
}
