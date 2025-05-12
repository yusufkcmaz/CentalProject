using AutoMapper;
using Cental.BusinessLayer.Abstract;
using Cental.BusinessLayer.Concrete;
using Cental.DataAccessLayer.Context;
using Cental.DtoLayer.BannerDtos;
using Cental.EntityLayer.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Cental.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]

    [Authorize(Roles = "Admin")]

    public class AdminBannerController(IBannerService _bannerService, IMapper _mapper, CentalContext _centalContext, IMapper mapper) : Controller
    {

        public IActionResult Index()
        {
            var values = _bannerService.TGetAll();

            var banners = _mapper.Map<List<ResultBannerDto>>(values);
            return View(banners);
        }

        public IActionResult CreateBanner()
        {
            return View();
        }

        //AutoMap Ile Map
        [HttpPost]
        public IActionResult CreateBanner(CreateBannerDto bannerDto)
        {
            var banner = _mapper.Map<Banner>(bannerDto);
            _bannerService.TCreate(banner);

            return RedirectToAction("Index");
        }



        public IActionResult UpdateBanner(int id)
        {
            var UpdateBannerDto = _bannerService.TGetById(id);
            var Banner = new UpdateBannerDto
            {
                BannerId = UpdateBannerDto.BannerId,
                Title = UpdateBannerDto.Title,
                Description = UpdateBannerDto.Description,
                ImageUrl = UpdateBannerDto.ImageUrl,
            };

            return View(Banner);
        }

        [HttpPost]

        public IActionResult UpdateBanner(UpdateBannerDto bannerDto)

        {
            var Banner = new Banner
            {
                BannerId = bannerDto.BannerId,
                Title = bannerDto.Title,
                Description = bannerDto.Description,
                ImageUrl = bannerDto.ImageUrl
            };


            _bannerService.TUpdate(Banner);
            return RedirectToAction("Index");
        }


    }
}
