using Cental.BusinessLayer.Abstract;
using Cental.DataAccessLayer.Abstract;
using Cental.EntityLayer.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Cental.WebUI.Areas.User.Controllers
{
    [Area("User")]
    public class BookingController(IBookingService _bookingService ,
                                   IBookingDal _bookingDal ) 
                                   : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult FormBooking(Booking booking)
        {
            if (ModelState.IsValid)
            {
                _bookingService.TCreate(booking);
                return RedirectToAction("Index", "Home"); 
            }

            return View("Index", booking);
        }
    }
}
