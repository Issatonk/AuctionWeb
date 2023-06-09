using Auction.DAL.MSSQL.Entity;
using Auction.Domain.TempIService;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace Auction.BLL;

public class BalanceService : IBalanceService
{
    private readonly UserManager<User> _userManager;
    private readonly SignInManager<User> _signInManager;

    public BalanceService(UserManager<User> userManager, SignInManager<User> signInManager)
    {
        _userManager = userManager;
        _signInManager = signInManager;
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
                var newBalanceClaim = new Claim("Balance", balance.ToString());

                var result = await _userManager.ReplaceClaimAsync(user, balanceClaim, newBalanceClaim);
                await _signInManager.RefreshSignInAsync(user);
                return result.Succeeded;
            }
        }

        return false;
    }



}


