using Auction.Interfaces.DAL;
using Microsoft.Extensions.DependencyInjection;
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
    private readonly IServiceProvider _serviceProvider;

    public UnitOfWork(AuctionContext context, IServiceProvider serviceProvider)
    {
        _context = context;
        _repositories = new Dictionary<Type, object>();
        _serviceProvider = serviceProvider;
    }

    public IRepository<TEntity> GetRepository<TEntity>() where TEntity : class
    {
        var entityType = typeof(TEntity);

        if (_repositories.ContainsKey(entityType))
        {
            return (IRepository<TEntity>)_repositories[entityType];
        }

        var repositoryInstance = _serviceProvider.GetService<IRepository<TEntity>>();
        _repositories.Add(entityType, repositoryInstance);

        return repositoryInstance;
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
