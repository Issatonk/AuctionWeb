using Auction.Domain.TempIService;
using Auction.MVC.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Auction.MVC.Controllers;

public class LotController : Controller
{
    private readonly ILotService _lotService;

    public LotController(ILotService lotService)
    {
        _lotService = lotService;
    }
    [Route("Lot/{lotId:Guid}")]
    public async Task<IActionResult> IndexAsync(Guid lotId)
    {
        var lot = await _lotService.GetAsync(lotId);
        var singleLotViewModel = new SingleLotViewModel
        {
            Id = lot.Id,
            OwnerId = lot.Owner.Id,
            OwnerName = lot.Owner.UserName,
            Name = lot.Name,
            Description = lot.Description,
            StartPrice = lot.StartPrice,
            CurrentPrice = lot.HighestBid,
            FinalDate = lot.FinalDate,
            Category = lot.Category,
            PathPhoto = lot.PathPhoto,
            IsSold = lot.IsSold
        };
        return View(singleLotViewModel);
    }

    [Authorize]
    public async Task<IActionResult> AllLotsAsync(string category)
    { 
        LotsViewModel viewModel = new LotsViewModel();
        viewModel.Lots = await _lotService.GetPaged(new Domain.FilterHelper(), new Domain.SortingHelper());
        return View(viewModel);
    }
    [Authorize]
    public async Task<IActionResult> MyLotsAsync()
    {
        LotsViewModel viewModel = new LotsViewModel();
        Guid.TryParse(
               HttpContext.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value,
                out Guid userId
                );
        viewModel.Lots = await _lotService.GetPaged(new Domain.FilterHelper() { UserId = userId}, new Domain.SortingHelper());
        return View("AllLots", viewModel);
    }
}
