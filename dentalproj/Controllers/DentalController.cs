using Microsoft.AspNetCore.Mvc;

namespace dentalproj.Controllers
{
    public class DentalController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }
    }
}
