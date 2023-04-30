using tms.Data.UnitOfWorks.Abstract;
using tms.Entity.Entities;
using tms.Service.Services.Abstract;

namespace tms.Service.Services.Concrete
{
	public class BrendService: IBrendService
	{
		private readonly IUnitOfWork unitOfWork;
        public BrendService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<List<Brend>> GetAllBrendsAsync()
        {
            return await unitOfWork.GetRepository<Brend>().GetAllAsync(b => !b.IsDeleted, b => b.Image);
        }

        public async Task<Brend> GetBrendAsync(Guid id)
        {
            return await unitOfWork.GetRepository<Brend>().GetById(id);
        }

        public async Task AddBrendAsync(Brend brend)
        {
            await unitOfWork.GetRepository<Brend>().AddAsync(brend);
            await unitOfWork.SaveAsync();
        }

        public async Task DeleteBrendAsync(Guid id)
        {
            var brend = await unitOfWork.GetRepository<Brend>().GetById(id);

            await unitOfWork.GetRepository<Brend>().DeleteAsync(brend);
            await unitOfWork.SaveAsync();
        }
    }
}
