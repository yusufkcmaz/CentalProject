using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cental.EntityLayer.Entities
{
    public class CarBrand
    {
        public int CarBrandId { get; set; }
        public string? BrandName { get; set; }

        public virtual List<Car>? Cars { get; set; }


    }
}
