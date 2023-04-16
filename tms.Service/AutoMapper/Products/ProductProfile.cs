using AutoMapper;
using tms.Entity.DTOs.ProductDtos;
using tms.Entity.Entities;

namespace tms.Service.AutoMapper.Products
{
    public class ProductProfile: Profile
    {
        public ProductProfile()
        {
            CreateMap<ProductDto, Product>().ReverseMap();
            CreateMap<ProductAddDto, Product>().ReverseMap();
		}
    }
}
