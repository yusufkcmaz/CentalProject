using Cental.DataAccessLayer.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewEngines;

namespace Cental.WebUI.ViewComponents.Contact
{
    public class _ContactOffice(CentalContext _centalContext):ViewComponent

    {
        public IViewComponentResult Invoke()
        {
            var value = _centalContext.contactOffıces.ToList();
            return View(value);
        }

    }
}
