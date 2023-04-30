using tms.Entity.Entities;

namespace tms.Service.Services.Abstract
{
	public interface IBrendService
	{
		Task<List<Brend>> GetAllBrendsAsync();
		Task<Brend> GetBrendAsync(Guid id);
		Task AddBrendAsync(Brend brend);
		Task DeleteBrendAsync(Guid id);
	}
}
