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

            var userdto =new List<ResultUserDto>();
            foreach(var user in users)
            {
                var dto = new ResultUserDto();

                dto.Roles = await _userManager.GetRolesAsync(user);
                dto.Id = user.Id;
                dto.FirstName = user.FirstName;
                dto.UserName = user.UserName;
                dto.LastName = user.LastName;
                dto.Email = user.Email;

                userdto.Add(dto);
            }

            return View(userdto);

        }  




        [HttpGet]  //->Kullanıcı id ile bilgilerini getirme.
        public async Task<ActionResult> AssignRol(int id)
        {


            var user = await _userManager.FindByIdAsync(id.ToString());

            ViewBag.fullName = string.Join(" ", user.FirstName, user.LastName);

            var roles = await _roleManager.Roles.ToListAsync();

            var userRoles = await _userManager.GetRolesAsync(user);

            var assignRoleDtoList = new List<AssignRolDto>();   

            foreach (var item in roles)
            {
                var model = new AssignRolDto();
                model.UserId = user.Id;
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
