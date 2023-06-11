using Auction.DAL.MSSQL.Entity;
using Auction.Domain.TempIService;
using Auction.Interfaces.DAL;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace Auction.BLL;

public class BetService : IBetService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IBalanceService _balanceService;

    public BetService(IUnitOfWork unitOfWork, IBalanceService balanceService)
    {
        _unitOfWork = unitOfWork;
        _balanceService = balanceService;
    }

    public async Task<IEnumerable<Bet>> GetBetsByLotId(Guid lotId)
    {
        var betRepository = _unitOfWork.GetRepository<Bet>();

        Expression<Func<Bet, bool>> filter = x => x.LotId == lotId;


        var result = await betRepository.GetMany(filtres: filter);

        return result;
    }

    public async Task<Bet> CreateBet(Guid userId,Guid lotId, decimal amount)
    {
        var betRepository = _unitOfWork.GetRepository<Bet>();
        var lotRepository = _unitOfWork.GetRepository<Lot>();
        var userRepository = _unitOfWork.GetRepository<User>();
        
        
        Expression<Func<User, bool>> getUser = user => user.Id == userId;
        Expression<Func<Lot, bool>> lotById = x => x.Id == lotId;

        Func<IQueryable<Lot>, IIncludableQueryable<Lot, object>> includeHighestBidder = query =>
        {
            return query.Include(x => x.HighestBidder);
        };
        var user = await userRepository.GetFirstOrDefault(getUser);
        var lot =  await lotRepository.GetFirstOrDefault(filter: lotById, include: includeHighestBidder, disableTracking: false);
        
        if(lot==null || lot.HighestBid >= amount)
        {
            throw new ArgumentOutOfRangeException(nameof(amount), "Сумма меньше текущей стоимости");
        }


        await _balanceService.UpdateBalance(lot.HighestBidder.UserName, lot.HighestBid * 0.99m);
        lot.HighestBid = amount;
        lot.HighestBidder = user;
        var result = await betRepository.Create(new Bet
        {
            LotId = lotId,
            Price = amount,
            Time = DateTime.Now,
            UserId = userId
        });
        await _unitOfWork.SaveChangesAsync();
        ///////////
        await _balanceService.UpdateBalance(user.UserName, -amount);
        //////////
        

        return result;
    }
}

public interface IBetService
{
    Task<IEnumerable<Bet>> GetBetsByLotId(Guid lotId);
    Task<Bet> CreateBet(Guid userId, Guid lotId, decimal amount);
}

public class WishListService : IWishListService
{
    private readonly IUnitOfWork _unitOfWork;

    public WishListService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    public async Task<WishList> Create(Guid userId, Guid lotId)
    {
        var wishlistRepository = _unitOfWork.GetRepository<WishList>();
        var result = await wishlistRepository.Create(
            new WishList
            {
                LotId = lotId,
                OwnerId = userId
            });
        await _unitOfWork.SaveChangesAsync();
        
        return result;
    }

    public async Task<IEnumerable<WishList>> GetListByUserId(Guid userId)
    {
        var wishListRepository = _unitOfWork.GetRepository<WishList>();
        Expression<Func<WishList, bool>> getByUserId = wish => wish.OwnerId == userId;
        Func<IQueryable<WishList>, IIncludableQueryable<WishList, object>> includeLots = query =>
        {
            return query.Include(x => x.Lot);
        };
        var result = await wishListRepository.GetMany(getByUserId, include: includeLots);
        return result;
    }
}

public interface IWishListService
{
    Task<WishList> Create(Guid userId, Guid lotId);
    Task<IEnumerable<WishList>> GetListByUserId(Guid userId);
}