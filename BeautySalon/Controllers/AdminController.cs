using BeautySalon.Models;
using BeautySalon.Services;
using Microsoft.AspNetCore.Mvc;

namespace BeautySalon.Controllers
{
    public class AdminController : Controller
    {
        private readonly IPostService _postService;

        public AdminController(IPostService postService)
        {
            _postService = postService;
        }
        public IActionResult Index()
        {
            var model = _postService.GetAllModels();
            return View(model);
        }

        public IActionResult AddPost()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddPost(PostModel obj)
        {
            if (string.IsNullOrWhiteSpace(obj.Title))
            {
                ModelState.AddModelError("Title", "Заголовок є обовязковим полем!");
            }

            if (string.IsNullOrWhiteSpace(obj.Description))
            {
                ModelState.AddModelError("Description", "Опис є обовязковим полем!");
            }

            if (ModelState.IsValid)
            {
                _postService.CreateOrUpdateModel(obj);
                return RedirectToAction("Index");
            }

            return View(obj);
        }
    }
}
