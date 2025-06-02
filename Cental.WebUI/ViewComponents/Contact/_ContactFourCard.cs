using Cental.DataAccessLayer.Context;
using Microsoft.AspNetCore.Mvc;

namespace Cental.WebUI.ViewComponents.Contact
{
    public class _ContactFourCard(CentalContext _centalContext) : ViewComponent 
    {
        public IViewComponentResult Invoke()
        {
            var values = _centalContext.ContactInfos.ToList();
            return View(values);
        }
    }
}
