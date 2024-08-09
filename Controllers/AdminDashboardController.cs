using AutoPartsHub.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AutoPartsHub.Controllers
{

    [CustomAuthorization]
    [Authorize(Roles = "Admin")]
    public class AdminDashboardController : Controller
    {
		private readonly AutoPartsHubContext _context;
        public AdminDashboardController(AutoPartsHubContext context)
        {
            _context = context;
        }
		public async Task<IActionResult> Index()
        {
            CheckoutViewModel checkout = new CheckoutViewModel();
            checkout.OrderDetail = await _context.TblOrderDetails.Include(x=>x.OrderMain).ToListAsync(); 
            return View(checkout);
        }
    }
}
