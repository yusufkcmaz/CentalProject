using Cental.BusinessLayer.Abstract;
using Cental.EntityLayer.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Cental.WebUI.Areas.Admin.Controllers
{
    public class AdminProcessController(IProcessService _processService ) : Controller
    {
        [Area("Admin")]
        [Authorize(Roles ="Admin")]
        public IActionResult Index()
        {
            var process = _processService.TGetAll();
            return View(process);
        }



        public IActionResult CreateProcess()
        {

            return View();
        }

        [HttpPost]

        public IActionResult CreateProcess(Process process)
        {
            _processService.TCreate(process);
            return RedirectToAction("Index");

        }

        public IActionResult DeleteProcess(int id)
        {
            _processService.TDelete(id);
            return RedirectToAction("Index");

        }


        //AutoMapper ve Dto kullanılacak !
        public IActionResult UpdateProcess(int id)
        {
            var Update = _processService.TGetById(id);


            return View(Update);
        }

        [HttpPost]

        public IActionResult UpdateProcess(Process process)
        {
            if (ModelState.IsValid)
            {
                _processService.TUpdate(process);  // Güncelleme işlemi
                return RedirectToAction("Index");
            }
            return View(process);
        }
    }
}
