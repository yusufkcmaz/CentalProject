using Cental.BusinessLayer.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Cental.WebUI.Areas.Manager.Controllers
{
    [Area("Manager")]
    [Authorize(Roles = "Admin,Manager")]
    public class BookingController(IBookingService _bookingService) : Controller
    {
      
        
            public IActionResult Index()
            {
                var bookings = _bookingService.TGetAll();
                return View(bookings);
            }

            [HttpPost]
            public IActionResult UpdateStatus(int bookingId, string status)
            {
                var booking = _bookingService.TGetById(bookingId);  // Tüm rezervasyonları veritabanından çekiyoruz
                if (booking != null)
                {
                    booking.Status = status;  // Durumu güncelliyoruz
                    _bookingService.TUpdate(booking);  // Veritabanında güncelleme işlemi
                    TempData["SuccessMessage"] = "Rezervasyon durumu başarıyla güncellendi.";
                }
                else
                {
                    TempData["ErrorMessage"] = "Rezervasyon bulunamadı.";
                }

                //return RedirectToAction("Index", "AdminBooking");

                return Json(new { success = true });
            }
        
    }
}
