using Cental.BusinessLayer.Abstract;
using Cental.EntityLayer.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Cental.WebUI.Controllers
{
    public class AdminServiceController(IServiceService _serviceService) : Controller
    {
        public IActionResult Index()
        {
            var service = _serviceService.TGetAll().ToList();
            return View(service);
        }

        [HttpGet]

        public IActionResult AddService()
        {

            return View();   
        }

        [HttpPost]

        public IActionResult AddService(Service service)
        {
            _serviceService.TCreate(service);
            return RedirectToAction("Index");
           
        }

        public IActionResult DeleteService(int id)
        {
            _serviceService.TDelete(id);
            return RedirectToAction("Index");
            
        }
      
        public IActionResult UpdateService(int id)
        {
            var Update = _serviceService.TGetById(id);
            

            return View(Update);
        }

        [HttpPost]

        public IActionResult UpdateService(Service service)
        {
            if (ModelState.IsValid)
            {
                _serviceService.TUpdate(service);  // Güncelleme işlemi
                return RedirectToAction("Index");
            }
            return View(service);
        }
    }
}
