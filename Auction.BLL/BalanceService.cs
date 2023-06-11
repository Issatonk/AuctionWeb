using Auction.DAL.MSSQL.Entity;
using Auction.Domain.TempIService;
using Auction.Interfaces.DAL;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Query;
using System.Data.Entity;
using System.Linq.Expressions;
using System.Security.Claims;

namespace Auction.BLL;

public class BalanceService : IBalanceService
{
    private readonly UserManager<User> _userManager;
    private readonly SignInManager<User> _signInManager;
    private readonly IUnitOfWork _unitOfWork;

    public BalanceService(UserManager<User> userManager, SignInManager<User> signInManager, IUnitOfWork unitOfWork)
    {
        _userManager = userManager;
        _signInManager = signInManager;
        _unitOfWork = unitOfWork;
    }
    public async Task<Balance> GetBalanceByUserId(Guid userId)
    {
        var balanceRepository = _unitOfWork.GetRepository<Balance>();
        Expression<Func<Balance, bool>> filter = balance => balance.UserId == userId;


        var result = await balanceRepository.GetFirstOrDefault(filter: filter);

        if (result == null)
        {
            throw new Exception();
        }

        return result;
    }
    public async Task<bool> UpdateBalance(string username, decimal amount)
    {

        var user = await _userManager.FindByNameAsync(username);
        if (user != null)
        {
            var balanceClaim = (await _userManager.GetClaimsAsync(user)).FirstOrDefault(c => c.Type == "Balance");
            if (balanceClaim != null && decimal.TryParse(balanceClaim.Value, out decimal balance))
            {
                balance += amount;

                var historyRepository = _unitOfWork.GetRepository<AccountBalanceHistory>();
                var createResult = await historyRepository.Create(new AccountBalanceHistory
                {
                    UserId = user.Id,
                    Amount = amount,
                    Date = DateTime.Now,
                    Description = "Пополнение баланса",
                    User = user
                });
                var balanceRepository = _unitOfWork.GetRepository<Balance>();
                Expression<Func<Balance, bool>> userById = x => x.UserId == user.Id;
                var userBalance = await balanceRepository.GetFirstOrDefault(filter: userById, disableTracking: false);
                userBalance.Amount = balance;
                if (createResult.Id != 0) 
                { 
                    await _unitOfWork.SaveChangesAsync();
                }
                var newBalanceClaim = new Claim("Balance", balance.ToString());

                var result = await _userManager.ReplaceClaimAsync(user, balanceClaim, newBalanceClaim);
                await _signInManager.RefreshSignInAsync(user);
                return result.Succeeded;
            }
        }

        return false;
    }



}