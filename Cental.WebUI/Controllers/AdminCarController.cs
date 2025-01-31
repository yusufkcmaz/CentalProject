using AutoMapper;
using Cental.BusinessLayer.Abstract;
using Cental.DtoLayer.CarDtos;
using Cental.DtoLayer.Enams;
using Cental.WebUI.Extansions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Cental.WebUI.Controllers
{
    public class AdminCarController: Controller
    {
        private readonly ICarService _carService;

        public AdminCarController(ICarService carService ,IMapper _mapper)
        {
            _carService = carService;
        }

        public IActionResult Index()
        {
            var values = _carService.TGetCarWithBrands(); //--> Listeleme.
            return View(values);
        }

        [HttpGet] // --> Enum verileri çekme işlemi. // Extansions web uı.
        
        public IActionResult CreateCar()
        {
            ViewBag.gasTypes = GetEnumValues.GetEnums<GasTypes>();
            ViewBag.gasTypes = GetEnumValues.GetEnums<GearTypes>();
            
            return View();  

        }

        [HttpPost]

        public IActionResult CreateCar(CreateCarDto createCarDto)
        {

            return View();
        }
    }
}
