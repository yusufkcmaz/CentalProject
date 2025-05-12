using Cental.BusinessLayer.Abstract;
using Cental.EntityLayer.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using PagedList.Core;

namespace Cental.WebUI.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("Admin")]
    //INTERFACE -->
    public class AdminCarBrandController(ICarBrandService _carBrandService) : Controller
    {
        //PagedList işlemi
        public IActionResult Index(int page = 1, int pageSize = 3)
        {
            var brands = _carBrandService.TGetAll().AsQueryable();
            var values = new PagedList<CarBrand>(brands, page, pageSize);
            return View(values);
        }

        public IActionResult DeleteCarBrand(int id)
        {
            _carBrandService.TDelete(id);
            return RedirectToAction("Index");
        }
        public IActionResult CreateCarBrand()
        {
            return View();
        }

        [HttpPost]

        public IActionResult CreateCarBrand(CarBrand car)
        {
            if (!ModelState.IsValid)
            {
                return View(car);
            }
            _carBrandService.TCreate(car);
            return RedirectToAction("Index");
        }


        //GUNCELLEME ISLEMI YAPILACAK - MAPING
    }
}
