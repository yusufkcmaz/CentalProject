using Cental.BusinessLayer.Abstract;
using Cental.DtoLayer.Enams;
using Cental.WebUI.Extansions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Cental.WebUI.ViewComponents.Cars
{
    public class _CarFilterCars(ICarService _carService , ICarBrandService  _carBrandService) :ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            var brands = _carBrandService.TGetAll();




            ViewBag.brands = (from x in brands
                            select new SelectListItem
                            {
                                Text = x.BrandName,
                                Value = x.BrandName

                            }).ToList();
 


            ViewBag.gasTypes = GetEnumValues.GetEnums<GasTypes>();
            ViewBag.gearTypes = GetEnumValues.GetEnums<GearTypes>();

            return View();
        }
    }
}
