using Microsoft.AspNetCore.Identity;

namespace Auction.Domain.TempIService;

public interface IAuthService
{
    Task<SignInResult> Login(string username, string password, bool rememberMe);
    Task<IdentityResult> Register(string username, string password);

    Task Logout();
}
