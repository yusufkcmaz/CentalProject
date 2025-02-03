using Cental.DtoLayer.UserDtos;
using Cental.EntityLayer.Entities;
using Mapster;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Cental.WebUI.Controllers
{
    public class RolAssignController(UserManager<AppUser> _userManager , RoleManager<AppRole> _roleManager) : Controller
    {
        //->Rol Atama işlemleri. ve listeleme.
        public async Task<IActionResult> Index()
        {
            var users = await _userManager.Users.ToListAsync();

            var userdto = users.Adapt<List<ResultUserDto>>();
            return View(userdto);
        }  

        [HttpGet]  //->Kullanıcı id ile bilgilerini getirme.
        public async Task<ActionResult> AssignRol(int id)
        {
            var user = await _userManager.FindByIdAsync(id.ToString());

            var roles = await _roleManager.Roles.ToListAsync();

            var userRoles = await _userManager.GetRolesAsync(user);

            var assignRoleDtoList = new List<AssignRolDto>();   

            foreach (var item in roles)
            {
                var model = new AssignRolDto();
                model.RoleName = item.Name;
                model.RoleId = item.Id;
                model.RoleExist = userRoles.Contains(item.Name);

                assignRoleDtoList.Add(model);
            }
            return View(assignRoleDtoList);
                        
        }

        [HttpPost]
      
        public async Task<IActionResult>AssignRol(List<AssignRolDto>model)
        {
            var userId = model.Select(x=>x.UserId).FirstOrDefault();

            var user = await _userManager.FindByIdAsync(userId.ToString());

            foreach (var item in model)
            {
                if (item.RoleExist)
                {
                    await _userManager.AddToRoleAsync(user , item.RoleName);
                }
                else
                {
                    await _userManager.RemoveFromRoleAsync(user , item.RoleName);
                }
               
            }
            return RedirectToAction("Index");
        }
    }
}
