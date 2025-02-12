using Cental.BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace Cental.WebUI.ViewComponents.DefaultUI
{
    public class _DefaultFeatureComponent(IFeatureService _featureService) : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            var valeus = _featureService.TGetAll();
            
            return View(valeus);
        }

    }
}
