using AutoMapper;
using Cental.BusinessLayer.Abstract;
using Cental.DtoLayer.TestimonialDtos;
using Cental.EntityLayer.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Cental.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminTestimonialController(IMapper _mapper, ITestimonialService _testimonialService) : Controller
    {
        public IActionResult Index()
        {
            var testimonials = _testimonialService.TGetAll();
            var testimonialDto = _mapper.Map<List<ResultTestimonialDto>>(testimonials);
            return View(testimonialDto);
        }

       
        public IActionResult DeleteTestimonial(int id)
        {
            var testimonial = _testimonialService.TGetById(id);
            if (testimonial != null)
            {
                _testimonialService.TDelete(id);
            }

            return RedirectToAction("Index");

        }



        [HttpGet]
        public IActionResult UpdateTestimonial(int id)
        {
            var testi = _testimonialService.TGetById(id);
            if (testi == null)
            {
                return NoContent();
            }

            var model = _mapper.Map<UpdateTestimoniaDto>(testi);
            return View(model);
        }




        [HttpPost]
        public IActionResult UpdateTestimonial(UpdateTestimoniaDto testimoniaDto)
        {
            var testimonial = _mapper.Map<Testimonial>(testimoniaDto);

            _testimonialService.TUpdate(testimonial);
            return RedirectToAction("Index");
        }
      
    }
}
