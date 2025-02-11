using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cental.EntityLayer.Entities
{
    public class Booking
    {
        public int BookingId { get; set; }
        public String Title { get; set; }

        public virtual List<Car> Cars { get; set; }

        public String Description { get; set; }
    }
}
