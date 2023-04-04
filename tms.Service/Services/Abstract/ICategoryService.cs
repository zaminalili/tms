using tms.Entity.DTOs.CategoryDTOs;
using tms.Entity.Entities;

namespace tms.Service.Services.Abstract
{
    public interface ICategoryService
    {
        Task<List<CategoryDTO>> GetAllCategoriesAsync();
    }
}
