using Cental.BusinessLayer.Abstract;
using Cental.DataAccessLayer.Abstract;
using Cental.EntityLayer.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Cental.WebUI.Controllers
{

    public class BookingController(IBookingService _bookingService,
                                 IBookingDal bookingDal, ICarService _carService): Controller
    {
        public IActionResult Index()
        {
            return View();
        }


        [HttpPost]
        public IActionResult CreateReservation(Booking booking)
        {
           
            _bookingService.TCreate(booking);

            var car = _carService.TGetById(booking.CarId);

            TempData["BookingSummary"] = $"{car.Brand.BrandName} {car.ModelName} aracı için {booking.PickUpDate:dd.MM.yyyy} {booking.PickUpTime} tarihinde " +
                                 $"{booking.PickUpLO} lokasyonundan alınacak, {booking.DropOffLO} lokasyonuna teslim edilecek bir rezervasyon oluşturuldu.";


            //TempData["BookingSummary"] = $"Araç ID: {booking.CarId}, Tarih: {booking.PickUpDate:dd.MM.yyyy}, Saat: {booking.PickUpTime}, Teslim Alış: {booking.PickUpLO}, Teslim Etme: {booking.DropOffLO}";


            return RedirectToAction("Index","Defaultuı");
        }
    }
}
