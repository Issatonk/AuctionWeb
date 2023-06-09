using Auction.BLL;
using Auction.Domain.TempIService;
using Microsoft.Extensions.DependencyInjection;

namespace Auction.DI;

public class BLL
{
    public static void Configure(IServiceCollection services)
    {
        services.AddScoped<ILotService, LotService>();
        services.AddScoped<IAuthService, AuthService>();
        services.AddScoped<IBalanceService, BalanceService>();
    }
}
