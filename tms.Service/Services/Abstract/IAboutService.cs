using tms.Entity.Entities;

namespace tms.Service.Services.Abstract
{
    public interface IAboutService
    {
        Task<List<About>> GetAboutsAsync();
        Task<About> GetAboutAsync(Guid id);
        Task UpdateAboutAsync(About model);

    }
}
