using Auction.Storage.Entity;
using System;
using System.Linq;
using Auction.Storage;
using Auction;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;

namespace Managers.Authorization
{

    public class AuthManager : IAuthManager
    {

        private OldAuctionContext _context;

        public AuthManager(OldAuctionContext context)
        {
            _context = context;
        }
        public async Task<bool> Login(LoginModel model, HttpContext http)
        {
            /*var login = _context.Users.Where(us => us.Name == slogin).ToList();
            if (login.Count == 0) return "Логин не верный";
            if (login[0].Name == null)
                return "Введите login";
            if (login[0].Password == null)
                return "Введите password";
            User users = login[0];
            if (users.Password != password)
                return "Пароль не верен";
            AuthMemory.Login = users.Name;

            return "OK";*/
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Name == model.Login);
            if (user == null)
                return false;
            if (user.Password != model.Password)
                return false;
            await Authenticate(model.Login, http); // аутентификация
            return true;
        }
        public async Task<bool> Registration(LoginModel model, HttpContext http)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Name == model.Login);
            if (user == null)
            {
                _context.Users.Add(new User { Name = model.Login, Password = model.Password });
                await _context.SaveChangesAsync();
                await Authenticate(model.Login, http); // аутентификация
                return true;
            }
            return false;
        }
        public async Task Authenticate(string userLogin, HttpContext http)
        {
            // создаем один claim
            var claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, userLogin)
            };
            // создаем объект ClaimsIdentity
            ClaimsIdentity id = new ClaimsIdentity(claims, "ApplicationCookie", ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);
            // установка аутентификационных куки
            await http.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(id));
        }

    }

}
