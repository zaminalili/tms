using AutoMapper;
using tms.Data.UnitOfWorks.Abstract;
using tms.Entity.DTOs.CategoryDTOs;
using tms.Entity.DTOs.ProductDtos;
using tms.Entity.Entities;
using tms.Service.Services.Abstract;

namespace tms.Service.Services.Concrete
{
    public class ProductService : IProductService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public ProductService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public Task ChangeStatusProductAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task CreateCategoryAsync(Product model)
        {
            throw new NotImplementedException();
        }

        public Task DeleteProductAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<List<ProductDto>> GetAllDeletedProductsAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<List<ProductDto>> GetAllProductsAsync()
        {
            var products = await unitOfWork.GetRepository<Product>().GetAllAsync(p => !p.IsDeleted, p => p.Category, p => p.Image);
            var map = mapper.Map<List<ProductDto>>(products);

            return map;
        }

        public Task<Product> GetProductByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task SafeDeleteProductAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateCategoryAsync(Product model)
        {
            throw new NotImplementedException();
        }
    }
}
