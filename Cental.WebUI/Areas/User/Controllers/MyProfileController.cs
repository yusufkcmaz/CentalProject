using Cental.BusinessLayer.Abstract;
using Cental.BusinessLayer.Concrete;
using Cental.DtoLayer.UserDtos;
using Cental.EntityLayer.Entities;
using Humanizer;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Cental.WebUI.Areas.User.Controllers
{
    [Area("User")]
    public class MyProfileController : Controller
    {
        private readonly IUserService _userService;
        private readonly IBookingService _bookingService;
        private readonly UserManager<AppUser> _userManager;

        public MyProfileController(IUserService userService, UserManager<AppUser> userManager , IBookingService bookingService)
        {
            _userService = userService;
            _userManager = userManager;
            _bookingService = bookingService;
        }


        public async Task<IActionResult> Index()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return RedirectToAction("Index", "Default"); // Eğer kullanıcı bulunamazsa ana sayfaya yönlendir
            }

            // Kullanıcıyı profil sayfasına gönder
            var userProfile = new ProfileEditDto
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                PhoneNumber = user.PhoneNumber,
                ImageUrl = user.ImageUrl
            };

            return View(userProfile);
        }

        [HttpGet]
        public async Task<IActionResult> UpdateProfile()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return RedirectToAction("Index", "Defaultuı");
            }

            var model = new ProfileEditDto
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                PhoneNumber = user.PhoneNumber,
                ImageUrl = user.ImageUrl
            };

            return View(model); // Views/User/MyProfile/UpdateProfile.cshtml
        }





        // Profil güncelleme işlemi
        [HttpPost]
        public async Task<IActionResult> UpdateProfile(ProfileEditDto model)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.GetUserAsync(User); // Giriş yapan kullanıcının                 if (user != null)
                {
                    user.FirstName = model.FirstName;
                    user.LastName = model.LastName;
                    user.Email = model.Email;
                    user.PhoneNumber = model.PhoneNumber;
                    if (model.ImageFile != null)
                    {
                        var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", model.ImageFile.FileName);
                        using (var stream = new FileStream(filePath, FileMode.Create))
                        {
                            await model.ImageFile.CopyToAsync(stream);
                        }
                        user.ImageUrl = "/images/" + model.ImageFile.FileName;
                    }

                    if (!string.IsNullOrEmpty(model.CurrentPassword))
                    {
                        var passwordResult = await _userManager.ChangePasswordAsync(user, model.CurrentPassword, model.CurrentPassword);
                        if (!passwordResult.Succeeded)
                        {
                            ModelState.AddModelError(string.Empty, "Şifre güncellenirken bir hata oluştu.");
                            return View(model);
                        }
                    }

                    
                    var result = await _userManager.UpdateAsync(user);
                    if (result.Succeeded)
                    {
                        TempData["SuccessMessage"] = "Profil başarıyla güncellendi!";
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, "Profil güncellenirken bir hata oluştu.");
                    }
                }
            }
            return View(model);
        }


        public async Task<IActionResult> MyBookings()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return RedirectToAction("Index", "Defaultuı");
            }

            var bookings = _bookingService.GetBookingByUserId(user.Id); 

            return View(bookings);  
        }




    }

}


   