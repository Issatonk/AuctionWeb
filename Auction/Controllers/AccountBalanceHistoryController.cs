using Auction.Domain.TempIService;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Auction.MVC.Controllers
{
    public class AccountBalanceHistoryController : Controller
    {
        private readonly IAccountBalanceHistoryService _service;

        public AccountBalanceHistoryController(IAccountBalanceHistoryService service)
        {
            _service = service;
        }
        public async Task<IActionResult> BalanceHistoryAsync()
        {
            var userName = HttpContext.User.Identity.Name;
            var result = await _service.GetBalanceHistoryByUsernameAsync(userName);
            return View(result);
        }
    }
}
