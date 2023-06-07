using Auction.BLL;
using Auction.Managers.Lots;
using Auction.MVC.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Auction.MVC.Controllers;

public class LotController : Controller
{
    private readonly ILotService _lotService;

    public LotController(ILotService lotService)
    {
        _lotService = lotService;
    }
    public IActionResult Index()
    {
        return View();
    }
    
    public async Task<IActionResult> AllLotsAsync(string category)
    { 
        LotsViewModel viewModel = new LotsViewModel();
        viewModel.Lots = await _lotService.GetPaged(new Domain.FilterHelper(), new Domain.SortingHelper());
        return View(viewModel);
    }
}
