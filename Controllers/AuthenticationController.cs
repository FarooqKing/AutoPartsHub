using Microsoft.AspNetCore.Mvc;

namespace AutoHubFYP.Controllers
{
    public class AuthenticationController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }

        public IActionResult Registration()
        {
            return View();
        }

    }
}
