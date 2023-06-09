using Auction.DAL.MSSQL;
using Auction.DAL.MSSQL.Entity;
using Auction.DAL.MSSQL.Repositories;
using Auction.Interfaces.DAL;
using Microsoft.Extensions.DependencyInjection;

namespace Auction.DI;

public class DAL
{
    public static void Configure(IServiceCollection services)
    {

        services.AddScoped<IRepository<Lot>, LotRepository>();
        services.AddScoped<IRepository<AccountBalanceHistory>, AccountBalanceHistoryRepository>();

        services.AddScoped<IUnitOfWork, UnitOfWork>();

        services.AddScoped<DataSeeder>();
        var serviceProvider = services.BuildServiceProvider();
        var seeder = serviceProvider.GetRequiredService<DataSeeder>();
        seeder.Seed();

    }
}
