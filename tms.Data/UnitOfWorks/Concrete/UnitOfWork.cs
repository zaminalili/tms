using tms.Data.Context;
using tms.Data.Repositories.Concrete;
using tms.Data.UnitOfWorks.Abstract;

namespace tms.Data.UnitOfWorks.Concrete
{
    public class UnitOfWork: IUnitOfWork
    {
        private AppDbContext dbContext;
        public UnitOfWork(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public ValueTask DisposeAsync()
        {
            return dbContext.DisposeAsync();
        }

        public int Save()
        {
            return dbContext.SaveChanges();
        }

        public Task<int> SaveAsync()
        {
            return dbContext.SaveChangesAsync();
        }

        Repository<T> IUnitOfWork.GetRepository<T>()
        {
            return new Repository<T>(dbContext);
        }
    }
}
