using tms.Entity.DTOs.CategoryDTOs;
using tms.Entity.Entities;

namespace tms.Service.Services.Abstract
{
    public interface ICategoryService
    {
        Task<List<Category>> GetAllCategoriesAsync();
        Task<List<CategoryDto>> GetAllDeletedCategoriesAsync();
        Task<Category> GetCategoryByIdAsync(Guid id);
        Task SafeDeleteCategoryAsync(Guid id);
        Task ChangeStatusCategoryAsync(Guid id);
        Task DeleteCategoryAsync(Guid id);
        Task CreateCategoryAsync(Category model);
        Task UpdateCategoryAsync(Category model);

    }
}
