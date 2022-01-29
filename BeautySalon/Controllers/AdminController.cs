using BeautySalon.Data.Models;
using BeautySalon.Models;
using BeautySalon.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BeautySalon.Controllers
{
    public class AdminController : Controller
    {
        private readonly IPostService _postService;
        private readonly IProductService _productService;
        private readonly ICommentService _commentService;

        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;

        public AdminController(IPostService postService,
                                IProductService productService,
                                ICommentService commentService,
                                SignInManager<ApplicationUser> signInManager,
                                UserManager<ApplicationUser> userManager)
        {
            _postService = postService;
            _productService = productService;
            _commentService = commentService;
            _signInManager = signInManager;
            _userManager = userManager;
        }

        #region News
        public IActionResult Index()
        {
            if (!_signInManager.IsSignedIn(User))
            {
                return LocalRedirect("~/Identity/Account/Login");
            }
            var model = _postService.GetAllModels();
            return View(model);
        }

        public IActionResult AddPost()
        {
            if (!_signInManager.IsSignedIn(User))
            {
                return LocalRedirect("~/Identity/Account/Login");
            }
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

            if (string.IsNullOrWhiteSpace(obj.Link))
            {
                ModelState.AddModelError("Link", "Посилання є обовязковим полем!");
            }

            if (ModelState.IsValid)
            {
                _postService.CreateModel(obj);
                TempData["success"] = "Новина додана успішно!";
                return RedirectToAction("Index");
            }

            return View(obj);
        }

        public IActionResult EditPost(int? id)
        {
            if (!_signInManager.IsSignedIn(User))
            {
                return LocalRedirect("~/Identity/Account/Login");
            }
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
                TempData["success"] = $"Новину оновлено успішно!";
                return RedirectToAction("Index");
            }

            return View(obj);
        }

        public IActionResult DeletePost(int? id)
        {
            if (!_signInManager.IsSignedIn(User))
            {
                return LocalRedirect("~/Identity/Account/Login");
            }
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var model = _postService.GetModelById((int)id);

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(PostModel obj)
        {
            if (obj == null)
            {
                return NotFound();
            }
            var post = _postService.GetModelById(obj.Id);
            if (post == null)
            {
                return NotFound();
            }
            else
            {
                _postService.DeleteModel(obj);
                TempData["success"] = $"Новина видалена успішно!";
                return RedirectToAction("Index");
            }
        }

        #endregion

        #region Products

        public IActionResult Products()
        {
            if (!_signInManager.IsSignedIn(User))
            {
                return LocalRedirect("~/Identity/Account/Login");
            }
            var model = _productService.GetAllModels();
            return View(model);
        }

        public IActionResult AddProduct()
        {
            if (!_signInManager.IsSignedIn(User))
            {
                return LocalRedirect("~/Identity/Account/Login");
            }
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
                TempData["success"] = $"Послуга додана успішно!";
                return RedirectToAction("Products");
            }

            return View(obj);
        }

        public IActionResult EditProduct(int? id)
        {
            if (!_signInManager.IsSignedIn(User))
            {
                return LocalRedirect("~/Identity/Account/Login");
            }
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
                TempData["success"] = $"Послугу оновлено успішно!";
                return RedirectToAction("Products");
            }

            return View(obj);
        }

        public IActionResult DeleteProduct(int? id)
        {
            if (!_signInManager.IsSignedIn(User))
            {
                return LocalRedirect("~/Identity/Account/Login");
            }
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var model = _productService.GetModelById((int)id);

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteProduct(ProductModel obj)
        {
            if (obj == null)
            {
                return NotFound();
            }
            var product = _productService.GetModelById(obj.Id);
            if (product == null)
            {
                return NotFound();
            }
            else
            {
                _productService.DeleteModel(obj);
                TempData["success"] = $"Послуга видалена успішно!";
                return RedirectToAction("Products");
            }
        }

        #endregion

        #region Comments
        public IActionResult Comments()
        {
            if (!_signInManager.IsSignedIn(User))
            {
                return LocalRedirect("~/Identity/Account/Login");
            }
            var model = _commentService.GetAllModels();
            return View(model);
        }

        public IActionResult AddComment()
        {
            if (!_signInManager.IsSignedIn(User))
            {
                return LocalRedirect("~/Identity/Account/Login");
            }
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddComment(CommentModel obj)
        {
            if (string.IsNullOrWhiteSpace(obj.Title))
            {
                ModelState.AddModelError("Title", "Заголовок є обовязковим полем!");
            }
            if (string.IsNullOrWhiteSpace(obj.Text))
            {
                ModelState.AddModelError("Text", "Текст є обовязковим полем!");
            }
            if (string.IsNullOrWhiteSpace(obj.UserName))
            {
                ModelState.AddModelError("UserName", "Імя є обовязковим полем!");
            }
            if (string.IsNullOrWhiteSpace(obj.UserCity))
            {
                ModelState.AddModelError("UserCity", "Місто є обовязковим полем!");
            }
            if (ModelState.IsValid)
            {
                _commentService.CreateModel(obj);
                TempData["success"] = $"Відгук доданий успішно!";
                return RedirectToAction("Comments");
            }

            return View(obj);
        }

        public IActionResult EditComment(int? id)
        {
            if (!_signInManager.IsSignedIn(User))
            {
                return LocalRedirect("~/Identity/Account/Login");
            }
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
            if (string.IsNullOrWhiteSpace(obj.Title))
            {
                ModelState.AddModelError("Title", "Заголовок є обовязковим полем!");
            }
            if (string.IsNullOrWhiteSpace(obj.Text))
            {
                ModelState.AddModelError("Text", "Текст є обовязковим полем!");
            }
            if (string.IsNullOrWhiteSpace(obj.UserName))
            {
                ModelState.AddModelError("UserName", "Імя є обовязковим полем!");
            }
            if (string.IsNullOrWhiteSpace(obj.UserCity))
            {
                ModelState.AddModelError("UserCity", "Місто є обовязковим полем!");
            }
            if (ModelState.IsValid)
            {
                _commentService.UpdateModel(obj);
                TempData["success"] = $"Відгук оновлено успішно!";
                return RedirectToAction("Comments");
            }

            return View(obj);
        }

        public IActionResult DeleteComment(int? id)
        {
            if (!_signInManager.IsSignedIn(User))
            {
                return LocalRedirect("~/Identity/Account/Login");
            }
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var model = _commentService.GetModelById((int)id);

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteComment(CommentModel obj)
        {
            if (obj == null)
            {
                return NotFound();
            }
            var comment = _commentService.GetModelById(obj.Id);
            if (comment == null)
            {
                return NotFound();
            }
            else
            {
                _commentService.DeleteModel(obj);
                TempData["success"] = $"Відгук видалено успішно!";
                return RedirectToAction("Comments");
            }
        }
        #endregion
    }
}
