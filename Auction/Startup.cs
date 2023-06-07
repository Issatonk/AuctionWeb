using Auction.Managers.Bets;
using Auction.Managers.Lots;
using Auction.Managers.BalanceReplenishments;
using Auction.Storage;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Managers.Authorization;
using Auction.Managers.Users;
using Auction.Managers.WishLists;
using Auction.Managers.SellLots;
using Auction.Managers.PurchaseHistoris;
using Auction.Managers.Incomes;
using Auction.Managers.SellHistoris;
using Auction.Managers.FileModels;
using Microsoft.AspNetCore.Authentication.Cookies;
using System;
using Auction.DI;

namespace Auction
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
            //services.AddScoped<ILotManager, LotManager>();
            //services.AddScoped<IBetManager, BetManager>();
            //services.AddScoped<IBalanceReplenishmentManager, BalanceReplenishmentManager>();
            //services.AddScoped<IUserManager, UserManager>();
            //services.AddScoped<IWishListManager, WishListManager>();
            //services.AddScoped<IAuthManager, AuthManager>();
            //services.AddScoped<IWishListManager, WishListManager>();
            //services.AddScoped<ISellLotManager, SellLotManager>();
            //services.AddScoped<IPurchaseHistoryManager, PurchaseHistoryManager>();
            //services.AddScoped<IIncomeManager, IncomeManager> ();
            //services.AddScoped<ISellHistoryManager, SellHistoryManager>();
            //services.AddScoped<IFileManager, FileManager>();

            services.AddDbContext<DAL.MSSQL.AuctionContext>(options =>
                options.UseInMemoryDatabase("AuctionDatabase"));

            DI.DAL.Configure(services);
            DI.BLL.Configure(services);

                      
            services.AddSession();
            
            services.AddSession(options =>
            {
                options.Cookie.Name = "Molotochek.ru";
                options.IdleTimeout = TimeSpan.FromSeconds(10);
                options.Cookie.IsEssential = true;
            });
            // установка конфигурации подключения
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(options => //CookieAuthenticationOptions
                {
                    options.LoginPath = new Microsoft.AspNetCore.Http.PathString("/Auth");
                });
            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseSession();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }

}
