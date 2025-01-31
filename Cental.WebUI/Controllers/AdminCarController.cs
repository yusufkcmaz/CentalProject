using Cental.BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace Cental.WebUI.Controllers
{
    public class AdminCarController: Controller
    {
        private readonly ICarService _carService;

        public AdminCarController(ICarService carService)
        {
            _carService = carService;
        }

        public IActionResult Index()
        {
            var values = _carService.TGetCarWithBrands(); //--> Listeleme.
            return View(values);
        }
    }
}
