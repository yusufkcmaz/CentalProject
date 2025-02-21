using Cental.BusinessLayer.Abstract;
using Cental.DataAccessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace Cental.WebUI.ViewComponents.DefaultUI
{
    public class _DefaultProcessComponent(IProcessService _processService , IProcessDal _processDal) :ViewComponent
    {

        public IViewComponentResult Invoke()
        {
            var process = _processService.TGetAll();
            return View(process);
        }
    }
}
