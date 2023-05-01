using tms.Data.UnitOfWorks.Abstract;
using tms.Entity.Entities;
using tms.Service.Services.Abstract;

namespace tms.Service.Services.Concrete
{
	public class OfferService: IOfferService
	{
		private readonly IUnitOfWork unitOfWork;
        public OfferService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<List<Offer>> GetAllOfferAsync()
        {
            return await unitOfWork.GetRepository<Offer>().GetAllAsync(o => !o.IsDeleted, o => o.Image);
        }

        public async Task<Offer> GetOfferAsync(Guid id)
        {
            return await unitOfWork.GetRepository<Offer>().GetById(id);
        }

        public async Task AddOfferAsync(Offer offer)
        {
            await unitOfWork.GetRepository<Offer>().AddAsync(offer);
            await unitOfWork.SaveAsync();
        }

        public async Task DeleteOfferAsync(Guid id)
        {
            var offer = await unitOfWork.GetRepository<Offer>().GetById(id);

            await unitOfWork.GetRepository<Offer>().DeleteAsync(offer);
            await unitOfWork.SaveAsync();
        }
    }
}
