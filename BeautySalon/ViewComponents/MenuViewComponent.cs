using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BeautySalon.ViewComponents
{
    public class MenuViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return await Task.Factory.StartNew(() =>
            {
                return View();
            });
        }
    }
}
