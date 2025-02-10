using AutoMapper;
using Cental.BusinessLayer.Abstract;
using Cental.DtoLayer.CarDtos;
using Cental.DtoLayer.Enams;
using Cental.EntityLayer.Entities;
using Cental.WebUI.Extansions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Cental.WebUI.Controllers
{
    [Authorize(Roles = "Admin")]

    public class AdminCarController(ICarService _carService, IMapper _mapper , ICarBrandService _brandService) : Controller
    {
        //private readonly ICarService _carService;

        //public AdminCarController()
        //{
        //    _carService = _carService;
        //}

        private void GetValuesİnDropDown() //-> Kısayol Method Kullanımı.
        {
            ViewBag.GasTypes = GetEnumValues.GetEnums<GasTypes>();
            ViewBag.GearTypes = GetEnumValues.GetEnums<GearTypes>();
            ViewBag.brands = (from x in _brandService.TGetAll()
                              select new SelectListItem
                              {
                                  Text = x.BrandName,
                                  Value = x.CarBrandId.ToString()
                              }).ToList();  
        }

        public IActionResult Index()//--> Listeleme.
        {
            var values = _carService.TGetAll(); 
            return View(values);
        }

        [HttpGet] // --> Enum verileri çekme işlemi. // Extansions web uı.
        
        public IActionResult CreateCar()
        {
            GetValuesİnDropDown();
            return View();  
        }

        [HttpPost]

        public IActionResult CreateCar(CreateCarDto createCarDto)
        {
            GetValuesİnDropDown();
            var newCar = _mapper.Map<Car>(createCarDto);
            _carService.TCreate(newCar);

            return RedirectToAction("Index");
        }
    }
}
