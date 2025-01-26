using Microsoft.AspNetCore.Mvc;

namespace Cental.WebUI.Controllers
{
    public class DefaultuıController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
