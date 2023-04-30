using tms.Data.UnitOfWorks.Abstract;
using tms.Entity.Entities;
using tms.Service.Services.Abstract;

namespace tms.Service.Services.Concrete
{
    public class AboutService: IAboutService
    {
        private readonly IUnitOfWork unitOfWork;
        public AboutService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<List<About>> GetAboutsAsync()
        {
            return await unitOfWork.GetRepository<About>().GetAllAsync();
        }

        public async Task<About> GetAboutAsync(Guid id)
        {
            return await unitOfWork.GetRepository<About>().GetById(id);
        }

        public async Task UpdateAboutAsync(About model)
        {
            var about = await unitOfWork.GetRepository<About>().GetById(model.Id);

            if (about != null)
            {
                about.Description_AZ = model.Description_AZ;
                about.Description_EN = model.Description_EN;
                about.Description_RU = model.Description_RU;
            }

            await unitOfWork.GetRepository<About>().UpdateAsync(about);
            await unitOfWork.SaveAsync();
        }
    }
}
