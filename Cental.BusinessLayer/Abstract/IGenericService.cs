using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cental.BusinessLayer.Abstract
{
    //Ekleme silme işlemleri için kullanılır 
    public interface IGenericService <T> where T : class
    {

        List<T> TGetAll();
        T TGetById(int id);

        void TDelete(int id);

        void TCreate(T entity);
        void TUpdate(T entity);
    }
}
