using AutoPartsHub.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace AutoPartsHub.Controllers
{
	public class HomeController : Controller
	{
		private readonly ILogger<HomeController> _logger;
        private readonly AutoPartsHubContext _context;
		public HomeController(ILogger<HomeController> logger , AutoPartsHubContext context)
		{
			_logger = logger;
            _context = context;
		}

	
        public async Task<IActionResult> Index()
        {
            var items = await _context.TblItems.Include(x=>x.TblItemImages).ToListAsync();
            return View(items);
        }
        [Route("privacy")]
        public IActionResult Privacy()
		{
			return View();
		}

		[Route("about")]
		public IActionResult About()
		{
			return View();
		}
        [Route("shop")]
        public async Task<IActionResult> Shop()
        {
            var items = await _context.TblItems.Include(t => t.TblItemImages).ToListAsync();
            return View(items);
        }

        //public async Task<IActionResult> Shop()
        //public IActionResult Shop()
        //{
        //    //var items = await _context.GetAllItemsAsync();
        //    //return View(items);
        //    return View();
        //}
        [Route("blog")]
        public IActionResult Blog()
        {
            return View();
        }


        [Route("gallery")]
        public IActionResult Gallery()
        {
            return View();
        }


        [Route("Pages")]
        public IActionResult Pages()
        {
            return View();
        }


        public IActionResult ContactUS()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ContactUS([Bind("ContectUsId,ContectUsName,ContectUsEmail,ContectUsPhoneNo,ContectUsSubject,ContectUsMassage,mDelete")] TblContectU tblContact)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _context.Add(tblContact);
                    await _context.SaveChangesAsync();

                }


                return View();
            }
            catch (Exception exp)
            {

                ViewBag.Message = exp.Message;
                return View(tblContact);
            }

        }



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}
