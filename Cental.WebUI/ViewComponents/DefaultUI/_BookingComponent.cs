using Cental.BusinessLayer.Abstract;
using Cental.DataAccessLayer.Context;
using Cental.EntityLayer.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Cental.WebUI.ViewComponents.DefaultUI
{
    public class _BookingComponent(ICarService _carService, IBookingService _bookingService) : ViewComponent
    {
        public IViewComponentResult Invoke()

        {
            var car = _carService.TGetAll();
            ViewBag.CarList = car.Select(x => new SelectListItem
            {
                Text = x.Brand.BrandName + " " + x.ModelName,
                Value = x.CarId.ToString()
            }).ToList();
            return View(new Booking());

        }


    }
}
