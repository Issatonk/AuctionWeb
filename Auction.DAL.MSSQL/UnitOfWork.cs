using Auction.Interfaces.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auction.DAL.MSSQL;

public class UnitOfWork : IUnitOfWork
{
    private readonly AuctionContext _context;
    private readonly Dictionary<Type, object> _repositories;

    public UnitOfWork(AuctionContext context)
    {
        _context = context;
        _repositories = new Dictionary<Type, object>();
    }

    public TRepository GetRepository<TRepository, TEntity>() 
        where TEntity :class 
        where TRepository : IRepository<TEntity>
    {
        var repositoryType = typeof(TRepository);

        if (_repositories.ContainsKey(repositoryType))
            return (TRepository)_repositories[repositoryType];

        var repository = (TRepository)Activator.CreateInstance(repositoryType, _context);
        _repositories.Add(repositoryType, repository);
        return repository;
    }

    public async Task<int> SaveChangesAsync()
    {
        return await _context.SaveChangesAsync();
    }

    public void Dispose()
    {
        _context.Dispose();
        GC.SuppressFinalize(this);
    }
}
