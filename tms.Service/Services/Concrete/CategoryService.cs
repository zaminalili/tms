using AutoMapper;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;
using tms.Data.UnitOfWorks.Abstract;
using tms.Entity.DTOs.CategoryDTOs;
using tms.Entity.Entities;
using tms.Service.Extensions;
using tms.Service.Services.Abstract;

namespace tms.Service.Services.Concrete
{
    public class CategoryService: ICategoryService
    {
        private readonly IUnitOfWork _unitOfWork; 
        private readonly  IMapper _mapper;
        private readonly IHttpContextAccessor httpContextAccessor;
        private readonly string userEmail;
        public CategoryService(IUnitOfWork unitOfWork, IMapper mapper, IHttpContextAccessor httpContextAccessor)
        {
            this._unitOfWork = unitOfWork;
            this._mapper = mapper;
            this.httpContextAccessor = httpContextAccessor;
            this.userEmail = httpContextAccessor.HttpContext.User.GetLoggidInUserEmail();

        }

        public async Task<List<Category>> GetAllCategoriesAsync()
        {
            return await _unitOfWork.GetRepository<Category>().GetAllAsync(c => !c.IsDeleted);
        }

        public async Task<Category> GetCategoryByIdAsync(Guid id)
        {
            return await _unitOfWork.GetRepository<Category>().GetById(id);
        }

        public async Task<List<CategoryDto>> GetAllDeletedCategoriesAsync()
        {
            var categories = await _unitOfWork.GetRepository<Category>().GetAllAsync(c => c.IsDeleted);
            var map = _mapper.Map<List<CategoryDto>>(categories);

            return map;
        }

        public async Task SafeDeleteCategoryAsync(Guid id)
        {
            var category = await _unitOfWork.GetRepository<Category>().GetById(id);

            category.IsDeleted = true;
            category.DeletedBy = userEmail;
            category.DeletedDate = DateTime.Now;

            await _unitOfWork.GetRepository<Category>().UpdateAsync(category);
            await _unitOfWork.SaveAsync();
        }

        public async Task ChangeStatusCategoryAsync(Guid id)
        {
            var category = await _unitOfWork.GetRepository<Category>().GetById(id);

            category.IsDeleted = false;
            category.DeletedBy = userEmail;
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

        public async Task CreateCategoryAsync(Category model)
        {

            model.CreatedBy = userEmail;
         

            await _unitOfWork.GetRepository<Category>().AddAsync(model);
            await _unitOfWork.SaveAsync();
        }

        public async Task UpdateCategoryAsync(Category model)
        {
            var category = await _unitOfWork.GetRepository<Category>().GetById(model.Id);

            category.Name_AZ = model.Name_AZ;
            category.Name_EN = model.Name_EN;
            category.Name_RU = model.Name_RU;

            category.Subname_AZ = model.Subname_AZ;
            category.Subname_EN = model.Subname_EN;
            category.Subname_RU = model.Subname_RU;

            category.SubofSubname_AZ = model.SubofSubname_AZ;
            category.SubofSubname_EN = model.SubofSubname_EN;
            category.SubofSubname_RU = model.SubofSubname_RU;

            category.EditedBy = userEmail;
            category.EditedDate = DateTime.Now;

            await _unitOfWork.GetRepository<Category>().UpdateAsync(category);
            await _unitOfWork.SaveAsync();
        }
    }
}
