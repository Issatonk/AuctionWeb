using Auction.Domain;
using Auction.Managers.Lots;
using Auction.MVC.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
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
    [Route("Lot/{lotId:Guid}")]
    public async Task<IActionResult> IndexAsync(Guid lotId)
    {
        var lot = await _lotService.GetAsync(lotId);
        var singleLotViewModel = new SingleLotViewModel
        {
            Id = lot.Id,
            OwnerId = lot.Owner.Id,
            OwnerName = lot.Owner.Name,
            Name = lot.Name,
            Description = lot.Description,
            CurrentPrice = lot.CurrentPrice,
            FinalDate = lot.FinalDate,
            Category = lot.Category,
            PathPhoto = lot.PathPhoto,
            IsSold = lot.IsSold
        };
        return View(singleLotViewModel);
    }


    public async Task<IActionResult> AllLotsAsync(string category)
    { 
        LotsViewModel viewModel = new LotsViewModel();
        viewModel.Lots = await _lotService.GetPaged(new Domain.FilterHelper(), new Domain.SortingHelper());
        return View(viewModel);
    }
}
