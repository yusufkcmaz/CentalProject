using Cental.BusinessLayer.Abstract;
using Cental.DataAccessLayer.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Cental.WebUI.ViewComponents.DefaultUI
{
    public class _BookingComponent(CentalContext _centalContext):ViewComponent
    {
        public IViewComponentResult Invoke()

        {
           var cars = _centalContext.Cars.ToList();
            ViewBag.Cars = new SelectList(cars,"CarId" , "CarBrandId") ;
            return View();

        }


    }
}
