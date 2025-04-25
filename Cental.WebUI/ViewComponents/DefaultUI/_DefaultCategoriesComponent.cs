using AutoMapper;
using Cental.BusinessLayer.Abstract;
using Cental.DtoLayer.CarDtos;
using Cental.EntityLayer.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Cental.WebUI.ViewComponents.DefaultUI
{
    public class _DefaultCategoriesComponent(IMapper _mapper , ICarService _carService) : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            var values = _carService.TGetAll().TakeLast(3);

            var Dto = _mapper.Map<List<ResultCarDto>>(values);
            return View(Dto);  
        }
    }
}
