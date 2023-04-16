using Microsoft.AspNetCore.Http;
using tms.Entity.Entities;

namespace tms.Service.Helpers
{
    public interface IImageHelper
    {
        Task<Image> UploadAsync(IFormFile file);
    }
}
