using Cental.DataAccessLayer.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Cental.WebUI.Controllers
{
    public class RezervisonController (CentalContext _centalContext): Controller
    {
        public IActionResult GetALL()
        {
            var Cars = _centalContext.Cars.ToList();
            ViewBag.Cars = new SelectList(Cars, "ModelName");
            return View();
        }
    }
}
