using tms.Entity.Entities;

namespace tms.Service.Services.Abstract
{
	public interface IOfferService
	{
		Task<List<Offer>> GetAllOfferAsync();
		Task<Offer> GetOfferAsync(Guid id);
		Task AddOfferAsync(Offer offer);
		Task DeleteOfferAsync(Guid id);
	}
}
