using Microsoft.AspNetCore.Mvc;

namespace Cental.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class LayoutController : Controller
    {
        public IActionResult _Layout()
        {
            return View();
        }
    }
}
