using Cental.BusinessLayer.Abstract;
using Cental.BusinessLayer.Concrete;
using Cental.DataAccessLayer.Abstract;
using Cental.DataAccessLayer.Concrete;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cental.BusinessLayer.Extensions
{
    public  static class ServiceRegistrations
    {
        public static void AddServiceRegistrations(this IServiceCollection Services)
        {

            Services.AddScoped<IAboutDal, EfAboutDal>(); //Interface'i --> EfaboutDal'da implement ettik.
            Services.AddScoped<IAboutService, AboutManager>();

            Services.AddScoped<IBannerDal, EfBannerDal>();
            Services.AddScoped<IBannerService, BannerManager>();

            Services.AddScoped<ICarBrandDal, EfCarBrandDal>();
            Services.AddScoped<ICarBrandService, CarBrandManager>();

            Services.AddScoped<ICarDal, EfCarDal>();
            Services.AddScoped<ICarService, CarManager>();

            Services.AddScoped<IFeatureDal, EfFeatureDal>();
            Services.AddScoped<IFeatureService, FeatureManager>();

            Services.AddScoped<IProcessDal, EfProcessDal>();
            Services.AddScoped<IProcessService, ProcessManager>();

            Services.AddScoped<IReviewDal, EfReviewDal>();
            Services.AddScoped<IReviewService, ReviewManager>();

            Services.AddScoped<IServiceDal, EfServiceDal>();
            Services.AddScoped<IServiceService, ServiceManager>();

            Services.AddScoped<ITestimonialDal, EfTestimonialDal>();
            Services.AddScoped<ITestimonialService, TestimonialManager>();

            Services.AddScoped<ICarDal ,  EfCarDal>();
            Services.AddScoped<ICarService , CarManager>();

            Services.AddScoped<IImageService , ImageService>();




        }



    }
}
