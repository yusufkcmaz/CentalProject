using Cental.BusinessLayer.Abstract;
using Cental.BusinessLayer.Concrete;
using Cental.DataAccessLayer.Abstract;
using Cental.EntityLayer.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Cental.WebUI.ViewComponents.DefaultUI
{
    public class _DefaultServiceComponent(IServiceService _serviceService, IServiceDal _serviceDal) :ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            var Services = _serviceDal.GetAll();

            return View(Services);
        }
      

       
    }
}
