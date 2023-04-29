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
        Task<List<ProductPriceDto>> GetProductPricesAsync(int minValue = 0, int? maxValue = null, Guid? categoryId = null);
        Task UpdateProductPriceAsync(int Unit, float Type, float Variation, Guid CategoryId);
        Task ChangePriceViewAsync();
        Task<bool> GetPriceViewStatus();
        Task<ProductListDto> GetProductsByPagingAsync(Guid? categoryId, int currentPage = 1, int pageSize = 24, bool isAscending = false);
        Task<ProductListDto> SearchAsync(string keyword, Guid? categoryId, int currentPage = 1, int pageSize = 18, bool isAscending = false);
        Task<Product> GetProductAsync(Guid id);
        Task<ProductListDto> GetProductsByCategoryNameAsync(string categoryName, Guid? categoryId, int currentPage = 1, int pageSize = 18, bool isAscending = false);
    }
}
