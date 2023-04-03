using tms.Data.Repositories.Concrete;
using tms.Entity.Entities;

namespace tms.Data.UnitOfWorks.Abstract
{
    public interface IUnitOfWork: IAsyncDisposable
    {
        Repository<T> GetRepository<T>() where T : class, IEntityBase, new();
        Task<int> SaveAsync();
        int Save();
    }
}
