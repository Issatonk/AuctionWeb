using Auction.DAL.MSSQL.Entity;
using Auction.Domain.TempIService;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace Auction.BLL;

public class AuthService : IAuthService
{
    private readonly UserManager<User> _userManager;
    private readonly SignInManager<User> _signInManager;

    public AuthService(UserManager<User> userManager, SignInManager<User> signInManager)
    {
        _userManager = userManager;
        _signInManager = signInManager;
    }

    public async Task<SignInResult> Login(string username, string password, bool rememberMe)
    {
        var result = await _signInManager.PasswordSignInAsync(username, password, rememberMe, lockoutOnFailure: false);

        if (result.Succeeded)
        {
            var user = await _userManager.FindByNameAsync(username);

            // Проверяем, что пользователь найден
            if (user != null)
            {
                // Добавляем информацию о балансе в Claims
                var claims = new List<Claim>
            {
                new Claim("Balance", user.Balance.ToString())
            };

                await _userManager.AddClaimsAsync(user, claims);
            }
        }

        return result;
    }

    public async Task<IdentityResult> Register(string username, string password)
    {
        var user = new User { UserName = username };
        user.Balance = new Balance
        {
            Amount = 0
        };

        var existingUser = await _userManager.FindByNameAsync(username);

        var result = await _userManager.CreateAsync(user, password);
        if (result.Succeeded)
        {
            

            var claims = new List<Claim>
            {
                new Claim("Balance", user.Balance.Amount.ToString())
            };
            
            await _userManager.AddClaimsAsync(user, claims);
            await _signInManager.SignInAsync(user, isPersistent: false);
        }

        return result;
    }


    public async Task Logout()
    {
        await _signInManager.SignOutAsync();
    }
}
