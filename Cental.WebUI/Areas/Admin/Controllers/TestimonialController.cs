using AutoMapper;
using Cental.BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace Cental.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class TestimonialController (IMapper _mapper , ITestimonialService _testimonialService ) : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
