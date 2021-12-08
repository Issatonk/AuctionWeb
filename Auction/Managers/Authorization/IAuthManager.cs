using Auction.Storage.Entity;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Managers.Authorization
{
    public interface IAuthManager
    {
        Task<bool> Login(LoginModel model, HttpContext http);
        Task<bool> Registration(LoginModel login, HttpContext http);
        Task Authenticate(string login, HttpContext httpContext);
    }
}
