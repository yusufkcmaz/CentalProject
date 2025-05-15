using Cental.BusinessLayer.Abstract;
using Cental.DataAccessLayer.Abstract;
using Cental.DataAccessLayer.Context;
using Cental.EntityLayer.Entities;
using Humanizer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Cental.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]

    [Authorize(Roles = "Admin")]
    [Authorize]
    public class DashboardController : Controller
    {
        private readonly ICarDal _carDal;
        private readonly ICarService _carService;
        private readonly ICarBrandService _carBrandService;
        private readonly ITestimonialService _testimonialService;
        private readonly IBookingService _bookingService;
        private readonly UserManager<AppUser> _userManager;
      
        public DashboardController(
       ICarDal carDal,
       ICarService carService,
       ICarBrandService carBrandService,
       ITestimonialService testimonialService,
       IBookingService bookingService,
       UserManager<AppUser> userManager)

        {
            _carDal = carDal;
            _carService = carService;
            _carBrandService = carBrandService;
            _testimonialService = testimonialService;
            _bookingService = bookingService;
            _userManager = userManager;
        }



        public IActionResult Index()
        {
            ViewBag.Car = _carService.TGetAll().Count(); //Tüm araçlar
            ViewBag.Km = _carService.TGetAll().Sum(x => x.KM); // tüm km değeri
            ViewBag.Brand = _carBrandService.TGetAll().Count();// tüm markalar
            ViewBag.command= _testimonialService.TGetAll().Count();//toplam yorum
            var expensive = _carService.GetMostExpensiveCar();//araca göre en pahalı marka
            ViewBag.expensive = $"{expensive.ModelName} - {expensive.Price} ₺";
            ViewBag.booking = _bookingService.TGetAll().Count();  //toplam rezervasyon
            ViewBag.user = _userManager.Users.Count();//kullanıcı
            ViewBag.OfBookings = _bookingService.TGetAll().Count(x => x.Status == "İptal Edildi");  //Aktif rezervasyonlar



            return View();
        }
    }
}
