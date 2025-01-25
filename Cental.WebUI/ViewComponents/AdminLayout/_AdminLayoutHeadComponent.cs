using Microsoft.AspNetCore.Mvc;

namespace Cental.WebUI.ViewComponents.AdminLayout
{
    public class _AdminLayoutHeadComponent : ViewComponent
    {
        //Render Edilmesi.
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
