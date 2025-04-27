using Cental.BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace Cental.WebUI.ViewComponents.LayoutUI
{
    public class _DefaultTopbarComponent (ILayoutInfoService _ınfoService): ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            var values = _ınfoService.TGetAll().FirstOrDefault();

            return View(values);
        }
    }
}
