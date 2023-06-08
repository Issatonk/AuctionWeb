
using Auction.BLL;
using Auction.Domain;
using Microsoft.Extensions.DependencyInjection;

namespace Auction.DI;

public class BLL
{
    public static void Configure(IServiceCollection services)
    {
        services.AddScoped<ILotService, LotService>();
    }
}
