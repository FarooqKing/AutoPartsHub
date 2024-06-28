using AutoPartsHub.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace AutoPartsHub.Controllers
{
	public class HomeController : Controller
	{
		private readonly ILogger<HomeController> _logger;

		public HomeController(ILogger<HomeController> logger)
		{
			_logger = logger;
		}

		public IActionResult Index()
		{
			return View();
		}
        [Route("privacy")]
     
		[Route("about")]
		public IActionResult About()
		{
			return View();
		}


        [Route("shop")]
        public IActionResult Shop()
        {
            return View();
        }


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


        [Route("ContectUS")]
        public IActionResult ContectUS()
        {
            return View();
        }



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}
