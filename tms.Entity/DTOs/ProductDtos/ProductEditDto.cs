using Microsoft.AspNetCore.Http;
using tms.Entity.Entities;

namespace tms.Entity.DTOs.ProductDtos
{
	public class ProductEditDto
	{
		List<Product> Products { get; set; }
		IFormFile Image { get; set; }
	}
}
