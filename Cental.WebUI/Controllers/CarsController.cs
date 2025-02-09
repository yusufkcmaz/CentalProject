using Cental.BusinessLayer.Abstract;
using Cental.DataAccessLayer.Context;
using Cental.DtoLayer.Enams;
using Cental.EntityLayer.Entities;
using Cental.WebUI.Extansions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Identity.Client;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Cental.WebUI.Controllers
  //Filtreleme İşlemleri
{
    [AllowAnonymous]
    public class CarsController(ICarService _carService, ICarBrandService _carBrandService, CentalContext _context) : Controller
    {
        public IActionResult Index()

        {
            if (TempData["filterCars"] != null)
            {
                var data = TempData["filterCars"].ToString();
                if (data != null)
                {

                    var filterCars = JsonSerializer.Deserialize<List<Car>>(data, new JsonSerializerOptions
                    {
                        ReferenceHandler = ReferenceHandler.IgnoreCycles
                    });

                    return View(filterCars);

                }

               
            }

            var values = _carService.TGetAll();
            return View(values);


        }


        [HttpPost]

        public IActionResult FilterCars(string brand, string gear, int year, string gas)
        {
            IQueryable<Car> values = _context.Cars.AsQueryable();


            if (!string.IsNullOrEmpty(brand))
            {
                values = values.Where(x => x.Brand.BrandName == brand);
            }
            //
            if (!string.IsNullOrEmpty(gear))
            {
                values = values.Where(x => x.GearType == gear);
            }

            if (!string.IsNullOrEmpty(gas))
            {
                values = values.Where(x => x.GasType == gas);
            }

            if (year>0)
            {
                values = values.Where(x => x.Year == year);
            }

            var filterList =values.ToList();

            TempData["filterCars"] = JsonSerializer.Serialize(filterList, new JsonSerializerOptions
            {
                ReferenceHandler = ReferenceHandler.IgnoreCycles
            });


            return RedirectToAction("Index");





        }


    }
}

