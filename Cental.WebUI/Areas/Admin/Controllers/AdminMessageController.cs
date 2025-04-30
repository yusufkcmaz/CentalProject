using Cental.BusinessLayer.Abstract;
using Cental.DataAccessLayer.Abstract;
using Cental.EntityLayer.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Security.Permissions;

namespace Cental.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminMessageController(ISendMessageService _messageService , ISendMessageDal _sendMessage) : Controller
    {
        public IActionResult Index()
        {
            var values = _messageService.TGetAll();
            return View(values);
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            var detail = _messageService.TGetById(id);
            if (detail == null) return NotFound();
            return View(detail);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var edit = _messageService.TGetById(id);
            if (edit == null) return NotFound();
            return View(edit);
        }

        [HttpPost]
        public IActionResult Edit(SendMessage send)
        {
            if (!ModelState.IsValid) return View(send);
            _messageService.TUpdate(send);
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
      
                _messageService.TDelete(id);
            
            return RedirectToAction("Index");
        }
    }
}
