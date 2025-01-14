using Cental.BusinessLayer.Abstract;
using Cental.DataAccessLayer.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cental.BusinessLayer.Concrete
{
    public class GenericManager<T> : IGenericService<T> where T : class
    {
        private readonly IGenericDal<T> _genericDal;

        public GenericManager(IGenericDal<T> genericDal)
        {
            _genericDal = genericDal;
        }

        public void TCreate(T entity)
        {
            _genericDal.Create(entity);
        }

        public void TDelete(int id)
        {
            throw new NotImplementedException();
        }

        public List<T> TGetAll()
        {
            throw new NotImplementedException();
        }

        public T TGetById(int id)
        {
            throw new NotImplementedException();
        }

        public void TUpdate(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
