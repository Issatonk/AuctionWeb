using Auction.Managers.Bets;
using Auction.Managers.Lots;
using Auction.Managers.BalanceReplenishments;
using Auction.Storage.Entity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Auction.Managers.Users;
using Auction.Managers.WishLists;
using Auction.Managers.PurchaseHistoris;
using Auction.Managers.SellLots;
using Auction.Managers.Incomes;
using Auction.Managers.SellHistoris;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using Auction.Managers.FileModels;
using Microsoft.AspNetCore.Authorization;

namespace Auction.Controllers
{
    public class OldLotController : Controller
    {
        private IWebHostEnvironment _appEnvironment;
        private ILotManager _lotManager;
        private IBetManager _betManager;
        private IBalanceReplenishmentManager _balanceReplenishmentManager;
        private IUserManager _userManager;
        private IWishListManager _wishManager;
        private IPurchaseHistoryManager _purchaseManager;
        private ISellLotManager _sellManager;
        private IIncomeManager _incomeManager;
        private ISellHistoryManager _shmanager;
        private IFileManager _fileManager;
        public OldLotController(ILotManager manager, IBetManager betManager,
            IBalanceReplenishmentManager balanceReplenishmentManager,
            IUserManager userManager, IWishListManager wishManager,
            IPurchaseHistoryManager purchaseManager, ISellLotManager sellManager,
            IIncomeManager incomeManager, ISellHistoryManager shmanager, IWebHostEnvironment appEnvironment,
            IFileManager fileManager)
        {
            _lotManager = manager;
            _betManager = betManager;
            _balanceReplenishmentManager = balanceReplenishmentManager;
            _userManager = userManager;
            _wishManager = wishManager;
            _purchaseManager = purchaseManager;
            _sellManager = sellManager;
            _incomeManager = incomeManager;
            _shmanager = shmanager;
            _fileManager = fileManager;
            _appEnvironment = appEnvironment;
        }

        //[Route("Lot/{guid:Guid}")]
        //[Authorize]
        //public IActionResult Index(Guid guid)
        //{
        //    Guid userId = _userManager.GetIdByName(User.Identity.Name);
        //    ViewBag.Balance = _userManager.GetBalance(userId);
        //    ViewBag.Name = User.Identity.Name;
        //    var lot = _lotManager.GetLot(guid);
        //    ViewBag.Owner = _userManager.GetById(lot.OwnerID).Name;
        //    ViewBag.AuthId = userId;
        //    ViewBag.Miniatures = _fileManager.GetByLotId(guid).ToList();
        //    if (_wishManager.GetWishLotUser(guid, userId) != null)
        //    {
        //        ViewBag.IsWish = true;
        //    }
        //    else
        //    {
        //        ViewBag.IsWish = false;
        //    }
        //    var bets = _betManager.GetByLot(lot.Id);
        //    if (bets == null)
        //        ViewBag.betExists = false;
        //    else ViewBag.betExists = true;

        //    return View(lot);
        //}
        [Route("PLot/{guid:Guid}")]
        public IActionResult IndexPurchase(Guid guid)
        {
            ViewBag.Name = User.Identity.Name;
            ViewBag.balance = _userManager.GetBalance(_userManager.GetIdByName(User.Identity.Name));
            var lot = _lotManager.GetLot(guid);
            ViewBag.Miniatures = _fileManager.GetByLotId(guid).ToList();
            ViewBag.Owner = _userManager.GetById(lot.OwnerID).Name;
            ViewBag.AuthId = _userManager.GetIdByName(User.Identity.Name);
            var bets = _betManager.GetByLot(lot.Id);
            if (bets == null)
                ViewBag.betExists = false;
            else ViewBag.betExists = true;

            return View(lot);
        }
        [Route("SLot/{guid:Guid}")]
        public IActionResult IndexSell(Guid guid)
        {
            ViewBag.Name = User.Identity.Name;
            ViewBag.balance = _userManager.GetBalance(_userManager.GetIdByName(User.Identity.Name));
            var lot = _lotManager.GetLot(guid);
            ViewBag.Owner = _userManager.GetById(lot.OwnerID).Name;
            ViewBag.AuthId = _userManager.GetIdByName(User.Identity.Name);
            var bets = _betManager.GetByLot(lot.Id);
            ViewBag.Miniatures = _fileManager.GetByLotId(guid).ToList();
            ViewBag.Buyer = _userManager.GetById(bets.ManId).Name;

            return View(lot);
        }

        //[Route("Lots/{category}")]
        //[Authorize]
        //public IActionResult AllLots(string category, SortState sortOrder = SortState.NoSort)
        //{
        //    ViewBag.login = User.Identity.Name;
        //    ViewBag.Name = User.Identity.Name;
        //    ViewBag.balance = _userManager.GetBalance(_userManager.GetIdByName(User.Identity.Name));

        //    ViewBag.PriceAsc = SortState.PriceAsc;
        //    ViewBag.PriceDes = SortState.PriceDes;
        //    ViewBag.DateAsc = SortState.DateAsc;
        //    ViewBag.DateDes = SortState.DateDes;
        //    ViewBag.category = category;

        //    AddSellTime();
        //    List<Lot> lots = _lotManager.GetAll().ToList();
        //    if (category != "All") 
        //    {
        //        lots = _lotManager.GetByCategory(category).ToList(); 
        //    }
        //    if (category == "MyLots") 
        //    {
        //        lots = _lotManager.GetMyLots(_userManager.GetIdByName(User.Identity.Name)).ToList();
        //    }

        //    lots = sortOrder switch
        //    {
        //        SortState.NoSort => lots,
        //        SortState.PriceAsc => lots.OrderBy(lot => lot.CurrentPrice).ToList(),
        //        SortState.PriceDes => lots.OrderByDescending(lot => lot.CurrentPrice).ToList(),
        //        SortState.DateAsc => lots.OrderBy(lot => lot.FinalDate).ToList(),
        //        SortState.DateDes => lots.OrderByDescending(lot => lot.FinalDate).ToList(),
        //        _=>lots
        //    };
        //    return View(lots);
        //}
       

        
      
        [Route("WishList")]
        [Authorize]
        public IActionResult WishList()
        {
            ViewBag.Balance = _userManager.GetBalance(_userManager.GetIdByName(User.Identity.Name));
            ViewBag.Name = User.Identity.Name;
            var lots = _wishManager.GetWishListByOwner(_userManager.GetIdByName(User.Identity.Name)).ToList();
            List<Lot> lotts = new List<Lot>();
            foreach (var item in lots)
            {
                lotts.Add(_wishManager.GetLotByWish(item));
            }
            return View(lotts);
        }
        [HttpGet]
        [Authorize]
        public IActionResult AddLot()
        {
            ViewBag.Balance = _userManager.GetBalance(_userManager.GetIdByName(User.Identity.Name));
            ViewBag.Name = User.Identity.Name;
            return View();
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Add(Lot lot,IFormFile mainPhoto, IFormFileCollection uploads)
        {
            if (lot.Name == null) lot.Name = "NoName";
            lot.OwnerID = _userManager.GetIdByName(User.Identity.Name);
            if(lot.Description == null)
            {
                lot.Description = "Пустое описание";
            }
            //lot.Category = "Хаты";
            lot.Id = Guid.NewGuid();
            if (uploads.Count != 0 || mainPhoto!=null) 
            {
                Console.WriteLine(lot.Id);
                Directory.CreateDirectory(@"../Auction/wwwroot/photo/" + lot.Id);
                List<FileModel> listFileModel = new List<FileModel>();
                if(mainPhoto != null)
                {
                    string path = "/photo/" + lot.Id + "/" + mainPhoto.FileName;
                    using (var fileStream = new FileStream(_appEnvironment.WebRootPath + path, FileMode.Create))
                    {
                        await mainPhoto.CopyToAsync(fileStream);
                    }
                    lot.PathPhoto = path;
                    
                }
                if (uploads.Count != 0)
                {
                    for (int i = 0; i < uploads.Count; i++)
                    {
                        string path = "/photo/" + lot.Id + "/" + uploads[i].FileName;
                        using (var fileStream = new FileStream(_appEnvironment.WebRootPath + path, FileMode.Create))
                        {
                             await uploads[i].CopyToAsync(fileStream);
                        }
                        listFileModel.Add(new FileModel() { lotId = lot.Id, Path = path });
                    }
                }
                await _fileManager.AddFiles(listFileModel);
                

            }
             await _lotManager.Add(lot);
            return Redirect("/Lots/All");
        }
       

        [HttpPost]
        public IActionResult MakeBet(double bet, Guid LotsId)
        {
            if (bet > _userManager.GetBalance(_userManager.GetIdByName(User.Identity.Name)))
            {
                return Redirect("/Lots/All");
            }
            if (bet < _lotManager.GetLot(LotsId).CurrentPrice)
            {
                return Redirect("/Lots/All");
            }
            Console.WriteLine(LotsId);
            var test = _betManager.GetByLot(LotsId);
            if (test != null) 
            { 
                if (bet <= test.Price) return Redirect("/Lots/All");
            }
            _userManager.MakeDeposit(_userManager.GetIdByName(User.Identity.Name), -bet);
            if (test != null)
            {
                _userManager.MakeDeposit(test.ManId, bet);
            }
            if (test == null)
                if (_lotManager.GetLot(LotsId).CurrentPrice >= bet)
                    return Redirect("/Lots/All");
            if (test != null) 
            { 
                User plus = _betManager.GetByBet(test.Id);
                if (plus != null)
                {
                    _userManager.MakeDeposit(plus.Id, test.Price);
                } 
            }
            Console.WriteLine(bet);
            Console.WriteLine(LotsId);
            Bet bet1 = new Bet();
            bet1.ManId = _userManager.GetIdByName(User.Identity.Name);
            bet1.Price = bet;
            _lotManager.UpdateLot(LotsId, bet);
            Console.WriteLine("ТУРУРУ "+LotsId);
            bet1.LotsId = LotsId;
            _betManager.MakeBet(bet1);

            return Redirect("/Lots/All");
        }
        [Authorize]
        [Route("MakeDeposit")]
        public IActionResult MakeDeposit()
        {
            ViewBag.Balance = _userManager.GetBalance(_userManager.GetIdByName(User.Identity.Name));
            ViewBag.Name = User.Identity.Name;
            Console.WriteLine("\tПополнить счёт работает");
            return View();
        }

        [Authorize]
        [Route("BalanceHistory")]
        public IActionResult BalanceHistory()
        {
            ViewBag.Balance = _userManager.GetBalance(_userManager.GetIdByName(User.Identity.Name));
            ViewBag.Name = User.Identity.Name;
            var x = _balanceReplenishmentManager.GetByUser(_userManager.GetIdByName(User.Identity.Name));
            return View(x);
        }
        [Authorize]
        public IActionResult Purchase()
        {
            ViewBag.Balance = _userManager.GetBalance(_userManager.GetIdByName(User.Identity.Name));
            ViewBag.Name = User.Identity.Name;
            var lots = _purchaseManager.GetByUser(_userManager.GetIdByName(User.Identity.Name)).ToList();
            List<Lot> lotts = new List<Lot>();
            foreach (var item in lots)
            {
                lotts.Add(_purchaseManager.GetLotByPurchase(item));
            }
            return View(lotts);
        }
        [Authorize]
        public IActionResult SellHist()
        {
            ViewBag.Balance = _userManager.GetBalance(_userManager.GetIdByName(User.Identity.Name));
            ViewBag.Name = User.Identity.Name;
            var lots = _shmanager.GetByUser(_userManager.GetIdByName(User.Identity.Name)).ToList();
            List<Lot> lotts = new List<Lot>();
            foreach (var item in lots)
            {
                lotts.Add(_shmanager.GetLotBySellH(item));
            }
            return View(lotts);
        }
        [Authorize]
        public IActionResult Income()
        {
            ViewBag.Balance = _userManager.GetBalance(_userManager.GetIdByName(User.Identity.Name));
            ViewBag.Name = User.Identity.Name;
            var x = _incomeManager.GetAll();
            return View(x);
        }

        public IActionResult MakeDeposit2(BalanceReplenishment bal)
        {
            bal.UserId = _userManager.GetIdByName(User.Identity.Name);
            Console.WriteLine("\tsum "+ bal.Amount);
            _balanceReplenishmentManager.Add(bal);
            return Redirect("/Lots/All");
        }

        public IActionResult AddWishList(Guid LotsId)
        {
            //_lotManager.GetLot(LotsId);
           
            Console.WriteLine("awl "+LotsId);
            _wishManager.Add(_userManager.GetIdByName(User.Identity.Name), LotsId, 100);
            return Redirect("/Lots/All");
        }

        public IActionResult Selllot(Guid lotId)
        {

            AddSell(lotId);
            return Redirect("/Lots/All");
        }

        public void AddSell(Guid lotId)
        {
            var bet = _betManager.GetByLot(lotId);
            var lot = _lotManager.GetLot(lotId);
            if (bet != null)
            {
                _sellManager.Add(new SellLot() { LotId = lotId });
                _wishManager.Remove(lotId);
                _shmanager.Add(new SellHistory() { LotId = lotId, OwnerId = lot.OwnerID });
                _purchaseManager.Add(new PurchaseHistory() { LotId = lotId, OwnerId = bet.ManId });
                _userManager.MakeDeposit(lot.OwnerID, bet.Price);
                _incomeManager.Add(lot.CurrentPrice / 100);
            }
        }

        public void AddSellTime()
        {
            List<Lot> lots = _lotManager.GetAll().ToList();
            for (int i = 0; i < lots.Count; i++)
            {
                if (lots[i].FinalDate < DateTime.Now)
                {
                    AddSell(lots[i].Id);
                }
            }
        }
    }
}
