using Microsoft.AspNetCore.Mvc;

namespace Cental.WebUI.ViewComponents.LayoutUI
{
    public class _DefaultTopbarComponent : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
