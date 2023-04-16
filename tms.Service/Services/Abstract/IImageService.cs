using tms.Entity.Entities;

namespace tms.Service.Services.Abstract
{
    public interface IImageService
    {
        Task<Guid> AddImageAsync(Image image);
    }
}
