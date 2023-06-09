using Auction.Domain.TempIService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Auction.MVC.Controllers;

public class BalanceController : Controller
{
    private readonly IBalanceService _balanceService;

    public BalanceController(IBalanceService balanceService)
    {
        _balanceService = balanceService;
    }

    [HttpGet]
    [Authorize]
    public IActionResult AddBalance()
    {
        return View();
    }
    [HttpPost]
    [ValidateAntiForgeryToken]
    [Authorize]
    public async Task<IActionResult> AddBalance(decimal amount)
    {
        var username = User.Identity.Name;

        await _balanceService.UpdateBalance(username, amount);
        return RedirectToAction("Index", "Home"); 
    }
}
