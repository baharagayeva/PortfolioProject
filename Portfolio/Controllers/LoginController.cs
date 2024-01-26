using Microsoft.AspNetCore.Mvc;

namespace Portfolio.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
