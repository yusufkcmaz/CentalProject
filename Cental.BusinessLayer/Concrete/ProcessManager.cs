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
    public class ProcessManager(IProcessDal _processDal) : IProcessService
    {
        public void TCreate(Process entity)
        {
            _processDal.Create(entity);
        }

        public void TDelete(int id)
        {
            _processDal.Delete(id);
        }

        public List<Process> TGetAll()
        {
            return _processDal.GetAll();
        }

        public Process TGetById(int id)
        {
            return _processDal.GetById(id);
        }

        public void TUpdate(Process entity)
        {
            _processDal.Update(entity); 
        }
    }
}
