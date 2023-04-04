using AutoMapper;
using tms.Data.UnitOfWorks.Abstract;
using tms.Entity.DTOs.CategoryDTOs;
using tms.Entity.Entities;
using tms.Service.Services.Abstract;

namespace tms.Service.Services.Concrete
{
    public class CategoryService: ICategoryService
    {
        private readonly IUnitOfWork unitOfWork; 
        private readonly  IMapper mapper;
        public CategoryService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public async Task<List<CategoryDTO>> GetAllCategoriesAsync()
        {
            var categories = await unitOfWork.GetRepository<Category>().GetAllAsync(c => !c.IsDeleted);
            var map = mapper.Map<List<CategoryDTO>>(categories);

            return map;
        }
    }
}
