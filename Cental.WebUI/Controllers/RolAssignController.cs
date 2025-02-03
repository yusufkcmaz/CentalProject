using Cental.EntityLayer.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Cental.WebUI.Controllers
{
    public class RolAssignController(UserManager<AppUser> _userManager) : Controller
    {
        public IActionResult Index()
        {
              

            return View();
        }
    }
}
