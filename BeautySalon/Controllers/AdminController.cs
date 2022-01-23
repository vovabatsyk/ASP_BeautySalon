using BeautySalon.Data.Models;
using BeautySalon.Models;
using BeautySalon.Services;
using Microsoft.AspNetCore.Mvc;

namespace BeautySalon.Controllers
{
    public class AdminController : Controller
    {
        private readonly IPostService _postService;
        private readonly IProductService _productService;
        private readonly ICommentService _commentService;

        public AdminController(IPostService postService, IProductService productService, ICommentService commentService)
        {
            _postService = postService;
            _productService = productService;
            _commentService = commentService;
        }

        #region News
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
                _postService.CreateModel(obj);
                return RedirectToAction("Index");
            }

            return View(obj);
        }

        public IActionResult EditPost(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var model = _postService.GetModelById((int)id);

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditPost(PostModel obj)
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
                _postService.UpdateModel(obj);
                return RedirectToAction("Index");
            }

            return View(obj);
        }

        #endregion

        #region Products

        public IActionResult Products()
        {
            var model = _productService.GetAllModels();
            return View(model);
        }

        public IActionResult AddProduct()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddProduct(ProductModel obj)
        {
            if (string.IsNullOrWhiteSpace(obj.Name))
            {
                ModelState.AddModelError("Name", "Назва є обовязковим полем!");
            }

            if (ModelState.IsValid)
            {
                _productService.CreateModel(obj);
                return RedirectToAction("Products");
            }

            return View(obj);
        }

        public IActionResult EditProduct(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var model = _productService.GetModelById((int)id);

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditProduct(ProductModel obj)
        {
            if (string.IsNullOrWhiteSpace(obj.Name))
            {
                ModelState.AddModelError("Name", "Назва є обовязковим полем!");
            }

            if (ModelState.IsValid)
            {
                _productService.UpdateModel(obj);
                return RedirectToAction("Products");
            }

            return View(obj);
        }

        #endregion

        #region Comments
        public IActionResult Comments()
        {
            var model = _commentService.GetAllModels();
            return View(model);
        }

        public IActionResult AddComment()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddComment(CommentModel obj)
        {
            if (ModelState.IsValid)
            {
                _commentService.CreateModel(obj);
                return RedirectToAction("Comments");
            }

            return View(obj);
        }

        public IActionResult EditComment(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var model = _commentService.GetModelById((int)id);

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditComment(CommentModel obj)
        {
            if (ModelState.IsValid)
            {
                _commentService.UpdateModel(obj);
                return RedirectToAction("Comments");
            }

            return View(obj);
        }
        #endregion
    }
}
