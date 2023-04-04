using tms.Data.UnitOfWorks.Abstract;
using tms.Entity.Entities;
using tms.Service.Services.Abstract;

namespace tms.Service.Services.Concrete
{
    public class CategoryService: ICategoryService
    {
        private readonly IUnitOfWork unitOfWork; 
        public CategoryService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<List<Category>> GetAllCategoriesAsync()
        {
            return await unitOfWork.GetRepository<Category>().GetAllAsync(c => !c.IsDeleted);
        }
    }
}
