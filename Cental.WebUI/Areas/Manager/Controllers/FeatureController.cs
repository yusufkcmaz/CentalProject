using Cental.BusinessLayer.Abstract;
using Cental.BusinessLayer.Concrete;
using Cental.EntityLayer.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Cental.WebUI.Areas.Manager.Controllers
{

    [Area("Manager")]
    [Authorize(Roles = "Manager")]


    public class FeatureController(IFeatureService _featureService ) : Controller
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

        public IActionResult AddFeatrue()
        {
            return View();
        }


        [HttpPost]

        public IActionResult AddFeatrue(Feature feature)
        {
            if (ModelState.IsValid)
            {
                _featureService.TCreate(feature);

                return RedirectToAction("Index");
            }
           

            return View(feature);
        }
    }
}
