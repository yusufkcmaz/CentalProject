using Cental.DtoLayer.UserSocialDtos;
using Cental.EntityLayer.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Cental.WebUI.Areas.Manager.Controllers
{
    [Area("Manager")]
    [Authorize(Roles ="Manager")]
    public class MySocialController : Controller
    {
        public IActionResult Index()
        {
            
            return View();
        }

        public IActionResult CreateSocial()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateSocial(CreateUserSocialDto model)
        {
            //var newSocial = _mapper.Map<UserSocial>(model);
            //_userSocialService.TCreate(newSocial);
            return RedirectToAction("Index");

        }
    }
}
