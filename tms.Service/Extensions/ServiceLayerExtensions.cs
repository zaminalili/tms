using Microsoft.Extensions.DependencyInjection;
using AutoMapper;
using System.Reflection;
using tms.Service.Services;
using tms.Service.Services.Abstract;
using tms.Service.Services.Concrete;
using Microsoft.AspNetCore.Http;
using tms.Service.Helpers;

namespace tms.Service.Extensions
{
    public static class ServiceLayerExtensions
    {
        public static IServiceCollection LoadServiceLayerExtension(this IServiceCollection services)
        {
            var assembly = Assembly.GetExecutingAssembly();


            services.AddAutoMapper(assembly);
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IProductService, ProductService>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped<IImageHelper, ImageHelper>();
            services.AddScoped<IImageService, ImageService>();
            services.AddScoped<IAboutService, AboutService>();

            return services;
        }
    }
}
