using Auction.BLL;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Auction.MVC.Controllers;

public class BetController : Controller
{
    private readonly IBetService _betService;

    public BetController(IBetService betService)
    {
        _betService = betService;
    }
    public async Task<IActionResult> CreateBetAsync(Guid lotId, decimal amount)
    {
        Guid.TryParse(
           HttpContext.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value,
            out Guid userId
            );

        await _betService.CreateBet(userId, lotId, amount);
        return RedirectToAction("Index", "Lot", new { lotId = lotId });
    }
}
