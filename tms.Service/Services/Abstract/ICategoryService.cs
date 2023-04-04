using tms.Entity.Entities;

namespace tms.Service.Services.Abstract
{
    public interface ICategoryService
    {
        Task<List<Category>> GetAllCategoriesAsync();
    }
}
