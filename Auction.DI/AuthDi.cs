using Auction.DAL.MSSQL;
using Auction.DAL.MSSQL.Entity;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auction.DI;

public class AuthDi
{
    public static void Configure(IServiceCollection services)
    {
        services.Configure<IdentityOptions>(options =>
        {
            options.Password.RequireDigit = false;
            options.Password.RequiredLength = 4;
            options.Password.RequireNonAlphanumeric = false;
            options.Password.RequireLowercase = false;
            options.Password.RequireUppercase = false;
        });
        services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
        .AddCookie(options =>
        {
            options.Cookie.HttpOnly = true;
            options.ExpireTimeSpan = TimeSpan.FromMinutes(30);
            options.LoginPath = "/Auth/Login";
            options.LogoutPath = "/Auth/Logout";
            options.AccessDeniedPath = "/Auth/AccessDenied";
        });
        services.AddIdentity<User, IdentityRole<Guid>>()
            .AddEntityFrameworkStores<AuctionContext>()
            .AddDefaultTokenProviders();

        services.AddScoped<UserManager<User>>();

    }
}

public class ClaimsMiddleware
{
    private readonly RequestDelegate _next;

    public ClaimsMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext context)
    {
        // Обработка Claims и добавление их в контекст запроса
        var user = context.User;
        if (user.Identity.IsAuthenticated)
        {
            var claims = user.Claims.ToList();
            context.Items["UserClaims"] = claims;
        }

        await _next(context);
    }
}
