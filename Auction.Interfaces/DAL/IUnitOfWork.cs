namespace Auction.Interfaces.DAL
{
    public interface IUnitOfWork : IDisposable
    {
        public TRepository GetRepository<TRepository, TEntity>()
        where TEntity : class
        where TRepository : IRepository<TEntity>;

        Task<int> SaveChangesAsync();
    }
}