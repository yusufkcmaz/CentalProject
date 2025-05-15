using Cental.DtoLayer.UserDtos;
using Cental.EntityLayer.Entities;
using Mapster;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Cental.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
   
    public class RolAssignController(UserManager<AppUser> _userManager, RoleManager<AppRole> _roleManager) : Controller
    {
       
        //->Rol Atama işlemleri. ve listeleme.
        public async Task<IActionResult> Index()
        {
            var users = await _userManager.Users.ToListAsync();

            var userdto = new List<ResultUserDto>();
            foreach (var user in users)
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
            if (user == null)
            {
                TempData["Error"] = "Kullanıcı bulunamadı.";
                return RedirectToAction("Index"); // veya NotFound() ya da özel hata sayfası
            }

            ViewBag.fullName = $"{user.FirstName} {user.LastName}";

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

        public async Task<IActionResult> AssignRol(List<AssignRolDto> model)
        {
            var userId = model.Select(x => x.UserId).FirstOrDefault();

            var user = await _userManager.FindByIdAsync(userId.ToString());

            var userRoles = await _userManager.GetRolesAsync(user);

            foreach (var item in model)
            {
                // Admin rolünü kaldırmayı engelleme
                if (item.RoleName == "Admin" && user.UserName == "superadmin")
                {
                    // "SuperAdmin" rolünü silmeye çalışıyorsan işlem yapma
                    continue;
                }

                // Ekleme işlemi (rol varsa ve atanmadıysa)
                if (item.RoleExist && !userRoles.Contains(item.RoleName))
                {
                    await _userManager.AddToRoleAsync(user, item.RoleName);
                }
                // Silme işlemi (rol artık kaldırıldıysa)
                else if (!item.RoleExist && userRoles.Contains(item.RoleName))
                {
                    await _userManager.RemoveFromRoleAsync(user, item.RoleName);
                }
            }
            await _userManager.UpdateAsync(user);

            TempData["SuccessMessage"] = "Rol atamaları güncellendi.";
            return RedirectToAction("Index");

            //foreach (var item in model)
            //{
            //    if (item.RoleExist)
            //    {
            //        await _userManager.AddToRoleAsync(user , item.RoleName);
            //    }
            //    else
            //    {
            //        await _userManager.RemoveFromRoleAsync(user , item.RoleName);
            //    }

            //}
            //return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> RemoveRole(int userId)
        {
            // Kullanıcıyı ID'sine göre bul
            var user = await _userManager.FindByIdAsync(userId.ToString());

            if (user != null)
            {
                // Kullanıcıya bağlı olan rollerini sil
                var userRoles = await _userManager.GetRolesAsync(user);
                foreach (var role in userRoles)
                {
                    await _userManager.RemoveFromRoleAsync(user, role);
                }

                // Kullanıcıyı veritabanından sil
                var result = await _userManager.DeleteAsync(user);

                if (result.Succeeded)
                {
                    TempData["SuccessMessage"] = "Kullanıcı başarıyla silindi.";
                }
                else
                {
                    TempData["ErrorMessage"] = "Kullanıcı silinirken bir hata oluştu.";
                }
            }
            else
            {
                TempData["ErrorMessage"] = "Kullanıcı bulunamadı.";
            }

            return RedirectToAction("Index");
        }
    }

}

