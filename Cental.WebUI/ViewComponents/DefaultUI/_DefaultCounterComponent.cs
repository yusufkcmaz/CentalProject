using Cental.BusinessLayer.Abstract;
using Cental.BusinessLayer.Concrete;
using Cental.DataAccessLayer.Abstract;
using Cental.DataAccessLayer.Concrete;
using Cental.DataAccessLayer.Repositories;
using Cental.EntityLayer.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Runtime.Intrinsics.X86;

namespace Cental.WebUI.ViewComponents.DefaultUI
{
    public class _DefaultCounterComponent(ICarDal _carDal , ICarService _carService , ICarBrandService _carBrandService ):ViewComponent
    {
       
        public IViewComponentResult Invoke ()
        {
            ViewBag.Car = _carService.TGetAll().Count();
            ViewBag.Km = _carService.TGetAll().Sum(x => x.KM);
            ViewBag.Brand = _carBrandService.TGetAll ().Count();
            return View();
        }
    }
}
