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
    public class ServiceManager : IServiceService
    {
        private readonly IServiceDal _serviceDal;

        public ServiceManager(IServiceDal serviceDal)
        {
            _serviceDal = serviceDal;
        }

        public void Create(Service entity)
        {
            _serviceDal.Create(entity);
        }

        public void Delete(int id)
        {
            _serviceDal.Delete(id); 
        }

        public List<Service> GetAll()
        {
            return _serviceDal.GetAll();    
        }

        public Service GetById(int id)
        {
            return _serviceDal.GetById(id);
        }

       
    }
}
