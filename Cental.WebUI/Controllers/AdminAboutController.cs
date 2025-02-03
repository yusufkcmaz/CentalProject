using Cental.BusinessLayer.Abstract;
using Cental.DtoLayer.AboutDtos;
using Cental.EntityLayer.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Cental.WebUI.Controllers
{

    //[Authorize(Roles ="Admin")]
  
    public class AdminAboutController : Controller
    {
        private readonly IAboutService _aboutService;

        public AdminAboutController(IAboutService aboutService)
        {
            _aboutService = aboutService;
        }

        public IActionResult Index()
        {
            //Result Class
            var values  = _aboutService.TGetAll();
            var result = values.Select(about => new ResultAboutDto
            {
                AboutId = about.AboutId,
                Mission = about.Mission,
                Vision = about.Vision,

            }).ToList();

            return View(result);
        }

        [HttpGet]

        public IActionResult CreateAbout()
        {
            return View();  
        }


        [HttpPost]
        public IActionResult CreateAbout(CreateAboutDto createAboutDto)

            //Manuel mapping
        {
            _aboutService.TCreate(new About
            {
                Description1 = createAboutDto.Description1,
                Description2 = createAboutDto.Description2,
               ImageUrl1=createAboutDto.ImageUrl1,
               ImageUrl2=createAboutDto.ImageUrl2,
               İtem1=createAboutDto.İtem1,
               İtem2=createAboutDto.İtem2,
               İtem3=createAboutDto.İtem3,
               İtem4=createAboutDto.İtem4,
               JobTitle=createAboutDto.JobTitle,
               Mission=createAboutDto.Mission,
               NameSurname=createAboutDto.NameSurname,
               ProfilePicture=createAboutDto.ProfilePicture,
               StartYear=createAboutDto.StartYear,
               Vision=createAboutDto.Vision,


            });
            return RedirectToAction("Index");   
        }

        public IActionResult DeleteAbout(int id)
        {
            _aboutService.TDelete(id);
            return RedirectToAction("Index");
        }

        public IActionResult UpdateAbout(int id)
        {
            var updateAboutDto = _aboutService.TGetById(id);
            var about = new UpdateAboutDto
            {
                AboutId = updateAboutDto.AboutId,
                Description1 = updateAboutDto.Description1,
                Description2 = updateAboutDto.Description2,
                ImageUrl1 = updateAboutDto.ImageUrl1,
                ImageUrl2 = updateAboutDto.ImageUrl2,
                İtem1 = updateAboutDto.İtem1,
                İtem2 = updateAboutDto.İtem2,
                İtem3 = updateAboutDto.İtem3,
                İtem4 = updateAboutDto.İtem4,
                JobTitle = updateAboutDto.JobTitle,
                Mission = updateAboutDto.Mission,
                NameSurname = updateAboutDto.NameSurname,
                ProfilePicture = updateAboutDto.ProfilePicture,
                StartYear = updateAboutDto.StartYear,
                Vision = updateAboutDto.Vision,
            };
            return View(about);
        }

        [HttpPost]
        //Guncelleme Islemı.
        public IActionResult UpdateAbout(UpdateAboutDto updateAboutDto)
        {
            var about = new About
            {
                AboutId = updateAboutDto.AboutId,
                Description1 = updateAboutDto.Description1, 
                Description2 = updateAboutDto.Description2, 
                ImageUrl1 = updateAboutDto.ImageUrl1,
                ImageUrl2 = updateAboutDto.ImageUrl2,
                İtem1 = updateAboutDto.İtem1,
                İtem2 = updateAboutDto.İtem2,
                İtem3 = updateAboutDto.İtem3,
                İtem4 = updateAboutDto.İtem4,
                JobTitle = updateAboutDto.JobTitle, 
                Mission = updateAboutDto.Mission,
                NameSurname = updateAboutDto.NameSurname,
                ProfilePicture = updateAboutDto.ProfilePicture,
                StartYear = updateAboutDto.StartYear,
                Vision = updateAboutDto.Vision,
            };


            _aboutService.TUpdate(about);
            return RedirectToAction("Index");


        }
                    


    }
}
