using Auction.DAL.MSSQL.Entity;
using Auction.Interfaces.DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Auction.DAL.MSSQL.Repositories;

public class UserRepository : IRepository<User>
{
    private readonly DbSet<User> _userDbSet;

    public UserRepository(AuctionContext context)
    {
        _userDbSet = context.Users;
    }
    public async Task<User> Create(User entity)
    {
        return (await _userDbSet.AddAsync(entity)).Entity;
    }

    public async Task<User> Delete(User entity)
    {
        var removeEntity = await _userDbSet.FindAsync(entity);
        _userDbSet.Remove(removeEntity);
        return removeEntity;
    }

    public async Task<User> Update(User entity)
    {
        var updateEntity = await _userDbSet.FirstOrDefaultAsync(x => x.Id == entity.Id);
        if(updateEntity != null)
        {
            updateEntity.Name = entity.Name;
            updateEntity.Balance = entity.Balance;
            updateEntity.Password = entity.Password;
        }
        return _userDbSet.Update(updateEntity).Entity;
    }
    public Task<User?> GetFirstOrDefault(Expression<Func<User, bool>> filter, Func<IQueryable<User>, IOrderedQueryable<User>>? sorts = null, Func<IQueryable<User>, IIncludableQueryable<User, object>>? include = null, bool disableTracking = false)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<User>> GetMany(Expression<Func<User, bool>>? filtres = null, Func<IQueryable<User>, IOrderedQueryable<User>>? sorts = null, Func<IQueryable<User>, IIncludableQueryable<User, object>>? include = null, int pageIndex = 0, int pageSize = 20, bool disableTracking = false)
    {
        throw new NotImplementedException();
    }
}