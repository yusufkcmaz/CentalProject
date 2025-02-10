using Cental.BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace Cental.WebUI.ViewComponents.DefaultUI
{
    public class _BookingComponent:ViewComponent
    {
        public IViewComponentResult Invoke()

        {
           
            return View();

        }
    }
}
