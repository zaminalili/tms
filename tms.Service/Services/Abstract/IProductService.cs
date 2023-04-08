using tms.Entity.DTOs.CategoryDTOs;
using tms.Entity.DTOs.ProductDtos;
using tms.Entity.Entities;

namespace tms.Service.Services.Abstract
{
    public interface IProductService
    {
        Task<List<ProductDto>> GetAllProductsAsync();
        Task<List<ProductDto>> GetAllDeletedProductsAsync();
        Task<Product> GetProductByIdAsync(Guid id);
        Task SafeDeleteProductAsync(Guid id);
        Task ChangeStatusProductAsync(Guid id);
        Task DeleteProductAsync(Guid id);
        Task CreateCategoryAsync(Product model);
        Task UpdateCategoryAsync(Product model);
    }
}
