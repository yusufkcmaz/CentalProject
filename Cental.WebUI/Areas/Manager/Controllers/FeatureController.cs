using Cental.BusinessLayer.Abstract;
using Cental.EntityLayer.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Cental.WebUI.Areas.Manager.Controllers
{

    [Area("Admin")]
    [Authorize(Roles = "Admin")] //

    public class FeatureController(IFeatureService _featureService) : Controller
    {
        public IActionResult Index()
        {
            var features = _featureService.TGetAll();
            return View(features);
        }

        public IActionResult DeleteFeature(int id)
        {
            var feature = _featureService.TGetById(id);
            if (feature != null)
            {
                _featureService.TDelete(feature.FeatureId);

            }
            return RedirectToAction("Index");
        }

        public ActionResult UpdateFeature(int id)
        {
            var feature = _featureService.TGetById(id);
            return View(feature);
        }


        [HttpPost]
        public ActionResult UpdateFeature(int id,Feature __feature)
        {
            if (ModelState.IsValid)
            {
                _featureService.TUpdate(__feature);
                return RedirectToAction("Index");
            }

            return View(__feature);
        }

    }
}
