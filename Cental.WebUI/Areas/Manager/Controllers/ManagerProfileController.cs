using Cental.BusinessLayer.Abstract;
using Cental.BusinessLayer.Concrete;
using Cental.DtoLayer.UserDtos;
using Cental.EntityLayer.Entities;
using Mapster;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Cental.WebUI.Areas.Manager.Controllers
{
    [Authorize(Roles = "Manager")]
    [Area("Manager")]
    public class ManagerProfileController(UserManager<AppUser> _userManager , IImageService _imageService) : Controller
    {
                

        public async Task<IActionResult> Index()
        {
            var manager = await _userManager.FindByNameAsync(User.Identity.Name);
            var profileEditDto = manager.Adapt<ProfileEditDto>();

            return View(profileEditDto);
        }

        [HttpPost]
        public async Task<IActionResult> Index(ProfileEditDto dto)
        {
            var manager = await _userManager.FindByNameAsync(User.Identity.Name);

            if (manager == null) return NotFound();

            manager.FirstName = dto.FirstName;
            manager.LastName = dto.LastName;
            manager.Email = dto.Email;
            manager.PhoneNumber = dto.PhoneNumber;
            manager.ImageUrl = dto.ImageUrl;

            var imageUrl = await _imageService.SaveImageAsync(dto.ImageFile);
            manager.ImageUrl = imageUrl;

            // Parola güncellenecekse
            if (!string.IsNullOrEmpty(dto.CurrentPassword))
            {
                manager.PasswordHash = _userManager.PasswordHasher.HashPassword(manager, dto.CurrentPassword);
            }

            var result = await _userManager.UpdateAsync(manager);

            if (result.Succeeded)
            {
                ViewBag.Message = "Profil başarıyla güncellendi.";
            }
            else
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }

            return View(dto);
        }

    }
}



