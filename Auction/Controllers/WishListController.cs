using Auction.BLL;
using Auction.MVC.Contracts;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Auction.MVC.Controllers;

public class WishListController : Controller
{
    private readonly IWishListService _wishListService;

    public WishListController(IWishListService wishListService)
    {
        _wishListService = wishListService;
    }
    public async Task<IActionResult> Create(Guid lotId)
    {
        Guid.TryParse(
           HttpContext.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value,
            out Guid userId
            );
        _wishListService.Create(userId, lotId);
        return RedirectToAction("GetMyWishList");
    }

    public async Task<IActionResult> GetMyWishList()
    {
        Guid.TryParse(
           HttpContext.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value,
            out Guid userId
            );
        var result = await _wishListService.GetListByUserId(userId);
        var lots = result.Select(wishList => wishList.Lot);
        return View("AllLots", new LotsViewModel { Lots = lots} );
    }
}
