using Microsoft.AspNetCore.Mvc;

namespace Cental.WebUI.ViewComponents.LayoutUI
{
    public class _DefaultFooterComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
