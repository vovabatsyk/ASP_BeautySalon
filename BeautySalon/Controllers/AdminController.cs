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
                _postService.CreateOrUpdateModel(obj);
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
                _productService.CreateOrUpdateModel(obj);
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
                _commentService.CreateOrUpdateModel(obj);
                return RedirectToAction("Comments");
            }

            return View(obj);
        }

        #endregion
    }
}
