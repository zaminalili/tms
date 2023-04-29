using AutoMapper;
using Microsoft.AspNetCore.Http;
using tms.Data.UnitOfWorks.Abstract;
using tms.Entity.DTOs.CategoryDTOs;
using tms.Entity.DTOs.ProductDtos;
using tms.Entity.Entities;
using tms.Service.Extensions;
using tms.Service.Services.Abstract;
using static System.Net.Mime.MediaTypeNames;

namespace tms.Service.Services.Concrete
{
    public class ProductService : IProductService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        private readonly IHttpContextAccessor httpContextAccessor;
        private readonly string userEmail;

        public ProductService(IUnitOfWork unitOfWork, IMapper mapper, IHttpContextAccessor httpContextAccessor)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
            this.httpContextAccessor = httpContextAccessor;
            this.userEmail = httpContextAccessor.HttpContext.User.GetLoggidInUserEmail();
        }

        public async Task ChangeStatusProductAsync(Guid id)
        {
            var product = await unitOfWork.GetRepository<Product>().GetById(id);

            product.IsDeleted = false;

            await unitOfWork.GetRepository<Product>().UpdateAsync(product);
            await unitOfWork.SaveAsync();

        }

        public async Task CreateProductAsync(ProductAddDto model, Guid imageId)
        {
            var product = new Product
            {
                Name = model.Name,
                About_AZ = model.About_AZ,
                About_EN = model.About_EN,
                About_RU = model.About_RU,
                Code = model.Code,
                Brend = model.Brend,
                Country_AZ = model.Country_AZ,
                Country_EN = model.Country_EN,
                Country_RU = model.Country_RU,
                Price = model.Price,
                ViewCount = model.ViewCount,
                Size = model.Size,
                Volume = model.Volume,
                Fuel = model.Fuel,
                HeatingArea = model.HeatingArea,
                Power = model.Power,
                Weight = model.Weight,
                Pressure = model.Pressure,
                Diameter = model.Diameter,
                MaximumTemperature = model.MaximumTemperature,
                Angle = model.Angle,
                CategoryId = model.CategoryId,
                ImageId = imageId,
                CreatedBy = userEmail
            };

            await unitOfWork.GetRepository<Product>().AddAsync(product);
            await unitOfWork.SaveAsync();
        }

        public async Task DeleteProductAsync(Guid id)
        {
            var product = await unitOfWork.GetRepository<Product>().GetById(id);

            await unitOfWork.GetRepository<Product>().DeleteAsync(product);
            await unitOfWork.SaveAsync();
        }

        public async Task<List<ProductDto>> GetAllDeletedProductsAsync()
        {
            var products = await unitOfWork.GetRepository<Product>().GetAllAsync(p => p.IsDeleted, p => p.Category, p => p.Image);
            var map = mapper.Map<List<ProductDto>>(products);

            return map;
        }

        public async Task<List<ProductDto>> GetAllProductsAsync()
        {
            var products = await unitOfWork.GetRepository<Product>().GetAllAsync(p => !p.IsDeleted, p => p.Category, p => p.Image);
            var map = mapper.Map<List<ProductDto>>(products);

            return map;
        }

        public async Task<ProductAddDto> GetProductByIdAsync(Guid id)
        {
            var product = await unitOfWork.GetRepository<Product>().GetById(id);
            //var product = await unitOfWork.GetRepository<Product>().GetAsync(x => !x.IsDeleted, x => x.Category);
			var map = mapper.Map<ProductAddDto>(product);

            return map;
        }

        public async Task<Product> GetProductAsync(Guid id)
        {
            return await unitOfWork.GetRepository<Product>().GetAsync(p => p.Id == id && !p.IsDeleted, p => p.Category, p => p.Image);
        }

        public async Task SafeDeleteProductAsync(Guid id)
        {
            var product = await unitOfWork.GetRepository<Product>().GetById(id);

            product.IsDeleted = true;
            product.DeletedBy = userEmail;
            product.DeletedDate = DateTime.Now;

            await unitOfWork.GetRepository<Product>().UpdateAsync(product);
            await unitOfWork.SaveAsync();
        }

        public async Task UpdateProductAsync(ProductAddDto model, Guid imageId)
        {
            var product = await unitOfWork.GetRepository<Product>().GetById(model.Id);

            imageId = imageId != Guid.Parse("00000000-0000-0000-0000-000000000000") ? imageId : product.ImageId;

            product.Name = model.Name;
            product.About_AZ = model.About_AZ;
            product.About_EN = model.About_EN;
            product.About_RU = model.About_RU;
            product.Code = model.Code;
            product.Brend = model.Brend;
            product.Country_AZ = model.Country_AZ;
            product.Country_EN = model.Country_EN;
            product.Country_RU = model.Country_RU;
            product.Price = model.Price;
            product.ViewCount = model.ViewCount;
            product.Size = model.Size;
            product.Volume = model.Volume;
            product.Fuel = model.Fuel;
            product.HeatingArea = model.HeatingArea;
            product.Power = model.Power;
            product.Weight = model.Weight;
            product.Pressure = model.Pressure;
            product.Diameter = model.Diameter;
            product.MaximumTemperature = model.MaximumTemperature;
            product.Angle = model.Angle;
            product.CategoryId = model.CategoryId;
            product.ImageId = imageId;
            product.CreatedBy = userEmail;
           

            await unitOfWork.GetRepository<Product>().UpdateAsync(product);
            await unitOfWork.SaveAsync();
        }

        public async Task<List<ProductPriceDto>> GetProductPricesAsync(int minValue = 0, int? maxValue = null, Guid? categoryId = null)
        {
            if(maxValue != null && categoryId != null)
            {
                var products = await unitOfWork.GetRepository<Product>().GetAllAsync(p => !p.IsDeleted && (p.Price > minValue && p.Price <= maxValue) && p.CategoryId == categoryId, p => p.Category);
                var map = mapper.Map<List<ProductPriceDto>>(products);
                return map;
            }
            else if(maxValue == null && categoryId != null)
            {
                var products = await unitOfWork.GetRepository<Product>().GetAllAsync(p => !p.IsDeleted && p.CategoryId == categoryId, p => p.Category);
                var map = mapper.Map<List<ProductPriceDto>>(products);
                return map;
            }
            else if(maxValue != null && categoryId == null) 
            { 
                var products = await unitOfWork.GetRepository<Product>().GetAllAsync(p => !p.IsDeleted && (p.Price > minValue && p.Price <= maxValue), p => p.Category);
                var map = mapper.Map<List<ProductPriceDto>>(products);
                return map;

            }
            else
            {
                var products = await unitOfWork.GetRepository<Product>().GetAllAsync(p => !p.IsDeleted && p.Price >= minValue, p => p.Category);
                var map = mapper.Map<List<ProductPriceDto>>(products);
                return map;
            }

        }

        public async Task UpdateProductPriceAsync(int Unit, float Type, float Variation, Guid CategoryId)
        {
            var products = await unitOfWork.GetRepository<Product>().GetAllAsync(p => !p.IsDeleted && p.CategoryId == CategoryId);

            if(Unit > 0)
            {
                foreach (var item in products)
                {
                    if (Type == 0)
                    {
                        if (Variation == 0)
                        {
                            item.Price = item.Price + (item.Price * Unit / 100);
                        }
                        else
                        {
                            item.Price = item.Price - (item.Price * Unit / 100);
                        }
                    }
                    else if (Type == 1)
                    {
                        if (Variation == 0)
                        {
                            item.Price = item.Price + Unit;
                        }
                        else
                        {
                            item.Price = item.Price - Unit;
                        }
                    }
                    else if (Type == 2)
                    {
                        if (Variation == 0)
                        {
                            item.Price = item.Price * Unit;
                        }
                        else
                        {
                            item.Price = item.Price / Unit;
                        }
                    }

                    await unitOfWork.GetRepository<Product>().UpdateAsync(item);
                    await unitOfWork.SaveAsync();
                }
            }

            
        }

        public async Task ChangePriceViewAsync()
        {
            var priceView = await unitOfWork.GetRepository<PriceView>().GetAsync(p => !p.IsDeleted);

            if (priceView.IsPriceViewActive == true)
                priceView.IsPriceViewActive = false;
            else
                priceView.IsPriceViewActive = true;

            await unitOfWork.GetRepository<PriceView>().UpdateAsync(priceView);
            await unitOfWork.SaveAsync();
        }

        public async Task<bool> GetPriceViewStatus()
        {
            var priceView = await unitOfWork.GetRepository<PriceView>().GetAsync(p => !p.IsDeleted);
            //var priceView = await unitOfWork.GetRepository<PriceView>().GetById(;

            return priceView.IsPriceViewActive;
        }

        public async Task<ProductListDto> GetProductsByPagingAsync(Guid? categoryId, int currentPage = 1, int pageSize = 18, bool isAscending = false)
        {
            pageSize = pageSize > 20 ? 20 : pageSize;

            var products = categoryId == null
                ? await unitOfWork.GetRepository<Product>().GetAllAsync(a => !a.IsDeleted, a => a.Image)
                : await unitOfWork.GetRepository<Product>().GetAllAsync(a => a.CategoryId == categoryId && !a.IsDeleted, a => a.Image);

            //var mappedProducts = mapper.Map<List<ProductDto>>(products);

            var sortedProducts = isAscending
                ? products.OrderBy(x => x.CreatedDate).Skip((currentPage - 1) * pageSize).Take(pageSize).ToList()
                : products.OrderByDescending(x => x.CreatedDate).Skip((currentPage - 1) * pageSize).Take(pageSize).ToList();

            

            return new ProductListDto
            {
                Products = sortedProducts,
                CategoryId = categoryId == null ? null : categoryId.Value,
                CurrentPage = currentPage,
                PageSize = pageSize,
                TotalCount = products.Count,
                IsAscending = isAscending
            };
        }

        public async Task<ProductListDto> SearchAsync(string keyword, Guid? categoryId, int currentPage = 1, int pageSize = 18, bool isAscending = false)
        {
            pageSize = pageSize > 20 ? 20 : pageSize;

            var products = categoryId == null
                ? await unitOfWork.GetRepository<Product>().GetAllAsync(a => !a.IsDeleted && (a.Name == keyword || a.Category.Name_AZ == keyword || a.Category.Name_EN == keyword || a.Category.Name_RU == keyword), a => a.Image)
                : await unitOfWork.GetRepository<Product>().GetAllAsync(a => a.CategoryId == categoryId && !a.IsDeleted && (a.Name == keyword || a.Category.Name_AZ == keyword || a.Category.Name_EN == keyword || a.Category.Name_RU == keyword), a => a.Image);

            //var mappedProducts = mapper.Map<List<ProductDto>>(products);

            var sortedProducts = isAscending
                ? products.OrderBy(x => x.CreatedDate).Skip((currentPage - 1) * pageSize).Take(pageSize).ToList()
                : products.OrderByDescending(x => x.CreatedDate).Skip((currentPage - 1) * pageSize).Take(pageSize).ToList();



            return new ProductListDto
            {
                Products = sortedProducts,
                CategoryId = categoryId == null ? null : categoryId.Value,
                CurrentPage = currentPage,
                PageSize = pageSize,
                TotalCount = products.Count,
                IsAscending = isAscending
            };
        }

        public async Task<ProductListDto> GetProductsByCategoryNameAsync(string categoryName, Guid? categoryId, int currentPage = 1, int pageSize = 18, bool isAscending = false)
        {
             

            pageSize = pageSize > 20 ? 20 : pageSize;

            var products = await unitOfWork.GetRepository<Product>()
                .GetAllAsync(p => !p.IsDeleted &&
                    (p.Category.Name_EN == categoryName || p.Category.Subname_EN == categoryName || p.Category.SubofSubname_EN == categoryName),
                    p => p.Category, p => p.Image
                );

            //var mappedProducts = mapper.Map<List<ProductDto>>(products);

            var sortedProducts = isAscending
                ? products.OrderBy(x => x.CreatedDate).Skip((currentPage - 1) * pageSize).Take(pageSize).ToList()
                : products.OrderByDescending(x => x.CreatedDate).Skip((currentPage - 1) * pageSize).Take(pageSize).ToList();



            return new ProductListDto
            {
                Products = sortedProducts,
                CategoryId = categoryId == null ? null : categoryId.Value,
                CurrentPage = currentPage,
                PageSize = pageSize,
                TotalCount = products.Count,
                IsAscending = isAscending
            };
        }
    }
}
