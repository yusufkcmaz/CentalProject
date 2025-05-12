using Cental.BusinessLayer.Abstract;
using Cental.EntityLayer.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;





namespace Cental.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class AdminProcessController : Controller
    {

        private readonly IProcessService _processService;

        public AdminProcessController(IProcessService processService)
        {
            _processService = processService;
        }



        public IActionResult Index()
        {
            var process = _processService.TGetAll();
            return View(process);
        }

        [HttpGet]
        public IActionResult AddProcess()
        {
            return View();  
        }


        [HttpPost]
        public IActionResult AddProcess(Process process)
        {
            if (ModelState.IsValid)
            {
                _processService.TCreate(process);
                return RedirectToAction("Index");
               
            }
            return View(process);
        }

        public IActionResult UpdateProcess()
        {
            return View();
        }

        [HttpPost]  

        public IActionResult UpdateProcess(Process process)
        {
            if (ModelState.IsValid)
            { 
                _processService.TUpdate(process);
                return RedirectToAction("Index");
            }

            return View(process);

        }


        public IActionResult DeleteProcess(int id)
        {
            var process = _processService.TGetById(id);
            if (process != null)
            {
                _processService.TDelete(id);

            }
            return RedirectToAction("Index");
        }
    }
}

