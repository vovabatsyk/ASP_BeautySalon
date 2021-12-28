using Microsoft.AspNetCore.Mvc;

namespace BeautySalon.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AddPost()
        {
            return View();
        }
    }
}
