using BeautySalon.Services;
using Microsoft.AspNetCore.Mvc;

namespace BeautySalon.Controllers
{
    public class BlogController : Controller
    {
        private readonly IPostService _service;
        public BlogController(IPostService service)
        {
            _service = service;
        }
        public IActionResult Index()
        {
            var model = _service.GetAllModels();
            return View(model);
        }
    }
}
