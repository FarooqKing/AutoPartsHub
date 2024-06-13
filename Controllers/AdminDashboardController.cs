using Microsoft.AspNetCore.Mvc;

namespace AutoHubFYP.Controllers
{
    public class AdminDashboardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
