using tms.Entity.DTOs.CategoryDTOs;
using tms.Entity.DTOs.ProductDtos;
using tms.Entity.Entities;

namespace tms.Service.Services.Abstract
{
    public interface IProductService
    {
        Task<List<ProductDto>> GetAllProductsAsync();
        Task<List<ProductDto>> GetAllDeletedProductsAsync();
        Task<ProductAddDto> GetProductByIdAsync(Guid id);
        Task SafeDeleteProductAsync(Guid id);
        Task ChangeStatusProductAsync(Guid id);
        Task DeleteProductAsync(Guid id);
        Task CreateProductAsync(ProductAddDto model, Guid imageId);
        Task UpdateProductAsync(ProductAddDto model, Guid imageId);
    }
}
