﻿using tms.Entity.DTOs.CategoryDTOs;
using tms.Entity.Entities;

namespace tms.Service.Services.Abstract
{
    public interface ICategoryService
    {
        Task<List<CategoryDto>> GetAllCategoriesAsync();
        Task<List<CategoryDto>> GetAllDeletedCategoriesAsync();
        Task<CategoryAddDto> GetCategoryByIdAsync(Guid id);
        Task SafeDeleteCategoryAsync(Guid id);
        Task ChangeStatusCategoryAsync(Guid id);
        Task DeleteCategoryAsync(Guid id);
        Task CreateCategoryAsync(CategoryAddDto model);
        Task UpdateCategoryAsync(CategoryAddDto model);

    }
}
