using BeautySalon.Data.Models;
using BeautySalon.Models;
using BeautySalon.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using System.Threading.Tasks;

namespace BeautySalon.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IProductService _productService;
        private readonly ICommentService _commentService;
        private readonly SendEmailService _sendEmailService;
        public HomeController(ILogger<HomeController> logger,
            IProductService productService,
            ICommentService commentService,
            SendEmailService sendEmailService)
        {
            _logger = logger;
            _productService = productService;
            _commentService = commentService;
            _sendEmailService = sendEmailService;
        }

        public IActionResult Index()
        {
            ViewBag.Comments = _commentService.GetPositiveComments();
            ViewBag.Products = _productService.ShowProducts();
            return View();
        }

        public async Task<IActionResult> SendMessage([FromForm] SendMailModel userInfo)
        {
            if (ModelState.IsValid)
            {
                await _sendEmailService.SendEmailAsync(userInfo);
            }
            return RedirectToAction("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
