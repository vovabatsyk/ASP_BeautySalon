using Microsoft.AspNetCore.Mvc;

namespace BeautySalon.Controllers
{
    public class BlogController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
