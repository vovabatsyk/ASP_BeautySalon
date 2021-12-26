using BeautySalon.Models;
using BeautySalon.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Diagnostics;

namespace BeautySalon.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IProductService _productService;
        private readonly ICommentService _commentService;
        public HomeController(ILogger<HomeController> logger, IProductService productService, ICommentService commentService)
        {
            _logger = logger;
            _productService = productService;
            _commentService = commentService;
        }

        public IActionResult Index()
        {
            var products = _productService.GetDiscountProducts();
            ViewBag.Comments = _commentService.GetPositiveComments();
            return View(products);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
