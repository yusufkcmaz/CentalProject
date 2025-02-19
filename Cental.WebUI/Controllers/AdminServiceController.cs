using Cental.BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace Cental.WebUI.Controllers
{
    public class AdminServiceController(IServiceService _serviceService) : Controller
    {
        public IActionResult Index()
        {
            var service = _serviceService.TGetAll().ToList();
            return View(service);
        }
    }
}
