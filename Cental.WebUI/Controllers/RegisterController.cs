using AutoMapper;
using Cental.DtoLayer.UserDtos;
using Cental.EntityLayer.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Cental.WebUI.Controllers
{
    [AllowAnonymous]
    public class RegisterController(UserManager<AppUser> _userManager ,IMapper _mapper) : Controller
    {
        public IActionResult Signup()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Signup(UserRegisterDto model) 
        {
            var user = _mapper.Map<AppUser>(model);
            if (!ModelState.IsValid) //--> Şifere uyumu kontrollü eşleşme oalyı.
            {
                return View(model);
            }


            //Şifre kısmının özlleitirme. Default ayarları
            var result = await _userManager.CreateAsync(user ,model.Password); 
            if(!result.Succeeded) //--> Şifre default özellikte değilse hata döndürür.
            {
                foreach(var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);

                }
                return View(model);
            }
            await _userManager.AddToRoleAsync(user, "User");
            return RedirectToAction("Index","Login");

           
        }
    }
}
