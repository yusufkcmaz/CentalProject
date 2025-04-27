using Cental.BusinessLayer.Abstract;
using Cental.DataAccessLayer.Abstract;
using Cental.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cental.BusinessLayer.Concrete
{
    public class LayoutInfoManager(ILayoutInfoDal _ınfoDal) : ILayoutInfoService
    {
        public void TCreate(LayoutInfo entity)
        {
            _ınfoDal.Create(entity);
        }

        public void TDelete(int id)
        {
            _ınfoDal.Delete(id);
        }

        public List<LayoutInfo> TGetAll()
        {
            return _ınfoDal.GetAll();
        }

        public LayoutInfo TGetById(int id)
        {
           return _ınfoDal.GetById(id);
        }

        public void TUpdate(LayoutInfo entity)
        {
             _ınfoDal.Update(entity);
        }
    }
}
