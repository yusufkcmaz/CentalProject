using Cental.DataAccessLayer.Context;
using Cental.EntityLayer.Entities;
using Cental.WebUI.ViewComponents.Contact;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NuGet.Packaging.Signing;

namespace Cental.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ContactInfoController(CentalContext _centalContext) : Controller
    {
        public async Task<IActionResult> Index()
        {
            var values = await _centalContext.ContactInfos.ToListAsync();

            return View(values);
        }

        [HttpGet]
        public IActionResult CreateInfo()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> createInfo(ContactInfo contactInfo)
        {
            _centalContext.ContactInfos.Add(contactInfo);
            await _centalContext.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> UpdateInfo(int id)
        {
            var values = await _centalContext.ContactInfos.FindAsync(id);
            return View(values);
        }

        [HttpPost]

        public async Task<IActionResult> UpdateInfo(ContactInfo contactInfo)
        {
            _centalContext.ContactInfos.Update(contactInfo);
            await _centalContext.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(int id)
        {
            var value = await _centalContext.ContactInfos.FindAsync(id);
            if (value != null)
            {
                _centalContext.ContactInfos.Remove(value);
                await _centalContext.SaveChangesAsync();
            }
            return RedirectToAction("Index");
        }


        public async Task<IActionResult> Cındex()
        {
            var values = await _centalContext.contactOffıces.ToListAsync();

            return View(values);
        }


        [HttpGet]
        public IActionResult AddOffice()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> AddOffice(ContactOffice contactOffice)
        {
            _centalContext.contactOffıces.Add(contactOffice);
            await _centalContext.SaveChangesAsync();
            return RedirectToAction("Cındex");
        }



        [HttpGet]
        public async Task<IActionResult> EditOffice(int id)
        {
            var values = await _centalContext.contactOffıces.FindAsync(id);
            return View(values);
        }

        [HttpPost]

        public async Task<IActionResult> EditOffice(ContactOffice contactOffice)
        {
            _centalContext.contactOffıces.Update(contactOffice);
            await _centalContext.SaveChangesAsync();
            return RedirectToAction("Cındex");
        }

        public async Task<IActionResult> Remove(int id)
        {
            var value = await _centalContext.contactOffıces.FindAsync(id);
            if (value != null)
            {
                _centalContext.contactOffıces.Remove(value);
                await _centalContext.SaveChangesAsync();
            }
            return RedirectToAction("Cındex");
        }

    }

}
