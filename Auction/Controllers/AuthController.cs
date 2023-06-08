using Auction.Storage.Entity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Auction.Domain.TempIService;
using System.Linq;

namespace Auction.Controllers;

public class AuthController : Controller
{
    private readonly IAuthService _authService;

    public AuthController(IAuthService authService)
    {
        _authService = authService;
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
        var result = await _authService.Login(model.Login, model.Password, false);
        if(!result.Succeeded)
            return View(model);

        return RedirectToAction("AllLots", "Lot");
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
        var result = await _authService.Register(model.Login, model.Password);
        if (!result.Succeeded) 
            return View(model);

        return RedirectToAction("AllLots", "Lot");
    }

    public async Task<IActionResult> Logout()
    {
        
        await _authService.Logout();
        return RedirectToAction("Index", "Home");
    }
}
