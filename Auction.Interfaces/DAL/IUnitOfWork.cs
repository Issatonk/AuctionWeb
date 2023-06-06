namespace Auction.Interfaces.DAL
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<TEntity> GetRepository<TEntity>() where TEntity : class;

        Task<int> SaveChangesAsync();
    }
}