using Cental.BusinessLayer.Abstract;
using Cental.DataAccessLayer.Abstract;
using Cental.EntityLayer.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Cental.WebUI.Controllers
{

    public class BookingController(IBookingService _bookingService,
                                 IBookingDal bookingDal, ICarService _carService, UserManager<AppUser> _userManager) : Controller
    {
        public IActionResult Index()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> CreateReservation(Booking booking)
        {


            // Giriş yapan kullanıcıyı al
            var user = await _userManager.GetUserAsync(User);

            // Rezervasyon bilgilerini tamamla
            booking.Status = "Onay bekliyor";
            booking.AppUserId = user.Id;

            // Veritabanına kaydet
            _bookingService.TCreate(booking);

            // Araç bilgilerini getir
            var car = _carService.TGetById(booking.CarId);

            // Bilgilendirme mesajı hazırla
            TempData["BookingSummary"] = $"{car.Brand.BrandName} {car.ModelName} aracı için {booking.PickUpDate:dd.MM.yyyy} {booking.PickUpTime} tarihinde " +
                                         $"{booking.PickUpLO} lokasyonundan alınacak, {booking.DropOffLO} lokasyonuna teslim edilecek bir rezervasyon oluşturuldu.";

            // Anasayfaya yönlendir
            return RedirectToAction("Index", "Defaultuı");
        }


    }


}

