using Cental.BusinessLayer.Abstract;
using Cental.DtoLayer.AboutDtos;
using Cental.WebUI.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace Cental.WebUI.ViewComponents.DefaultUI
{
    public class _DefaultBannerComponent (IBannerService _bannerService ): ViewComponent
    {
        public IViewComponentResult Invoke()

        {
            var values = _bannerService.TGetAll();
            return View(values);

        }



    }
}
