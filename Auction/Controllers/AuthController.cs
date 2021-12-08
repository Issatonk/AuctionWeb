using Auction.Storage.Entity;
using Managers.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Web;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Auction.Managers.Users;
using Auction.Storage;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace Auction.Controllers
{
    public class AuthController : Controller
    {
        IAuthManager _manager;
        IUserManager _userManager;
        public AuthController(IAuthManager manager, IUserManager userManager)
        {
            _manager = manager;
            _userManager = userManager;
        }
        [HttpGet]
        public IActionResult Index()
        {
            ViewData["_Layout_type"] = "null";
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index(LoginModel model)
        {
            ViewData["_Layout_type"] = "null";
            if (ModelState.IsValid)
            {
                bool flag = await _manager.Login(model, HttpContext);
                if (flag != false)
                    return RedirectToAction("Index", "Home");
                ViewBag.Error1 = "Некорректные логин и(или) пароль";
            }
            return View(model);
        }


        [HttpGet]
        public IActionResult Registration()
        {
            ViewData["_Layout_type"] = "null";
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Registration(LoginModel model)
        {
            ViewData["_Layout_type"] = "null";
            if (ModelState.IsValid)
            {
                bool flag = await _manager.Registration(model, HttpContext);
                if (flag == true)
                    return RedirectToAction("Index", "Home");
                else
                    ViewBag.Error2 = "Пользователь с таким логином уже существует";
            }
            return View("~/Views/Auth/Index.cshtml");
        }

        public async Task<IActionResult> Logout()
        {
            
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Home");
        }
    }

}
