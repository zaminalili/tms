using Microsoft.Extensions.DependencyInjection;
using AutoMapper;
using System.Reflection;
using tms.Service.Services;
using tms.Service.Services.Abstract;
using tms.Service.Services.Concrete;

namespace tms.Service.Extensions
{
    public static class ServiceLayerExtensions
    {
        public static IServiceCollection LoadServiceLayerExtension(this IServiceCollection services)
        {
            var assembly = Assembly.GetExecutingAssembly();


            services.AddAutoMapper(assembly);
            services.AddScoped<ICategoryService, CategoryService>();

            return services;
        }
    }
}
