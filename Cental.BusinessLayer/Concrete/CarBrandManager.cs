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
    public class CarBrandManager : ICarBrandService
    {
        private readonly ICarBrandDal _carBrandDal;

        public CarBrandManager(ICarBrandDal carBrandDal)
        {
             _carBrandDal = carBrandDal;
        }

        public void TCreate(CarBrand entity)
        {
            _carBrandDal.Create(entity);    
        }

        public void TDelete(int id)
        {
            _carBrandDal .Delete(id);
        }

        public List<CarBrand> TGetAll()
        {
            return _carBrandDal.GetAll();   
        }

        public CarBrand TGetById(int id)
        {
            return _carBrandDal.GetById(id);
        }

        public void TUpdate(CarBrand entity)
        {
            _carBrandDal.Update(entity);
        }
    }
}
