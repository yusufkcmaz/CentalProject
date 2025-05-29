using AutoMapper;
using Cental.BusinessLayer.Abstract;
using Cental.DtoLayer.CarDtos;
using Cental.DtoLayer.Enams;
using Cental.EntityLayer.Entities;
using Cental.WebUI.Extansions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Cental.WebUI.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("Admin")]
    public class AdminCarController(ICarService _carService, IMapper _mapper, ICarBrandService _brandService) : Controller
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


        [HttpGet]
        public IActionResult UpdateCar(int id)
        {
            // Dropdown verilerini hazırlıyoruz
            GetValuesİnDropDown();

            var car = _carService.TGetById(id);
            if (car == null)
            {
                return NotFound();
            }

            // Dönüştürme işlemi (AutoMapper ile DTO'ya dönüştür)
            var updateCarDto = _mapper.Map<UpdateCarDto>(car);

            // View'a DTO'yu gönderiyoruz
            return View(updateCarDto);
        }



        [HttpPost]
        public IActionResult UpdateCar(UpdateCarDto updateCarDto)
        {
            // Dropdown verilerini tekrar alıyoruz
            GetValuesİnDropDown();

            // Dönüştürme işlemi (AutoMapper ile Entity'ye dönüştür)
            var updatedCar = _mapper.Map<Car>(updateCarDto);

            // Veritabanında güncelleme işlemi
            _carService.TUpdate(updatedCar);

            return RedirectToAction("Index");
        }

    }
}
