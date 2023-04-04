using AutoMapper;
using tms.Data.UnitOfWorks.Abstract;
using tms.Entity.DTOs.CategoryDTOs;
using tms.Entity.Entities;
using tms.Service.Services.Abstract;

namespace tms.Service.Services.Concrete
{
    public class CategoryService: ICategoryService
    {
        private readonly IUnitOfWork _unitOfWork; 
        private readonly  IMapper _mapper;
        public CategoryService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this._unitOfWork = unitOfWork;
            this._mapper = mapper;
        }

        public async Task<List<CategoryDto>> GetAllCategoriesAsync()
        {
            var categories = await _unitOfWork.GetRepository<Category>().GetAllAsync(c => !c.IsDeleted);
            var map = _mapper.Map<List<CategoryDto>>(categories);

            return map;
        }

        public async Task<CategoryAddDto> GetCategoryByIdAsync(Guid id)
        {
            var category = await _unitOfWork.GetRepository<Category>().GetById(id);
            var map = _mapper.Map<CategoryAddDto>(category);

            return map;
        }

        public async Task SafeDeleteCategoryAsync(Guid id)
        {
            var category = await _unitOfWork.GetRepository<Category>().GetById(id);

            category.IsDeleted = true;
            category.DeletedBy = "Admin";
            category.DeletedDate = DateTime.Now;

            await _unitOfWork.GetRepository<Category>().UpdateAsync(category);
            await _unitOfWork.SaveAsync();
        }

        public async Task DeleteCategoryAsync(Guid id)
        {
           var category = await _unitOfWork.GetRepository<Category>().GetById(id);

           await _unitOfWork.GetRepository<Category>().DeleteAsync(category);
           await _unitOfWork.SaveAsync();
        }

        public async Task CreateCategoryAsync(CategoryAddDto model)
        {
            var category = new Category
            {
                Name_AZ = model.NameAz,
                Name_EN = model.NameEn,
                Name_RU = model.NameRu,
                CreatedBy = "Admin"
            };

            await _unitOfWork.GetRepository<Category>().AddAsync(category);
            await _unitOfWork.SaveAsync();
        }

        public async Task UpdateCategoryAsync(CategoryAddDto model)
        {
            var category = await _unitOfWork.GetRepository<Category>().GetById(model.Id);

            category.Name_AZ = model.NameAz;
            category.Name_EN = model.NameEn;
            category.Name_RU = model.NameRu;
            category.EditedBy = "Admin";
            category.EditedDate = DateTime.Now;
        }
    }
}
