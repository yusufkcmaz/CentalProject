
using AutoMapper;
using Cental.BusinessLayer.Abstract;
using Cental.DtoLayer.TestimonialDtos;

using Microsoft.AspNetCore.Mvc;

namespace Cental.WebUI.ViewComponents.DefaultUI
{
    public class _DefaultTestimonialComponent(IMapper _mapper , ITestimonialService _testimonialService) : ViewComponent
    {
       
        public IViewComponentResult Invoke()
        {
            var testimonial = _testimonialService.TGetAll();
            var dtos = _mapper.Map<List<ResultTestimonialDto>>(testimonial);

            return View(dtos);
        }
    }
}
