using AutoMapper;
using tms.Entity.DTOs.CategoryDTOs;
using tms.Entity.Entities;

namespace tms.Service.AutoMapper.Categories
{
    public class CategoryProfile: Profile
    {
        public CategoryProfile()
        {
            CreateMap<CategoryDto, Category>().ReverseMap();
            CreateMap<CategoryAddDto, Category>().ReverseMap();
        }
    }
}
