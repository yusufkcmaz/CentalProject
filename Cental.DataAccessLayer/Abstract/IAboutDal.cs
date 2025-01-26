using Cental.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cental.DataAccessLayer.Abstract
{
    //Interface DE METOD YAZILDI. ICERIGINI (EFABOUT DA DOLDURULACAKTIR).
    //Generıcte oluşan (T) classı bu ınterface tanımlıyoruz.

    //IAboutDal --> IgenericDal'dan miras alır içerisinde crud işlemleri tanımlandığı için. 
    public interface IAboutDal : IGenericDal<About>
    {
       

    }
}
