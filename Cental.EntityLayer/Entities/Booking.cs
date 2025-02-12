using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cental.EntityLayer.Entities
{
    public class Booking
    {
        public int BookingCarId { get; set; }
        public String Title { get; set; }
        public String Description { get; set; }
        public string PickUpLO { get; set; }
        public string DropOffLO { get; set; }
        public DateTime PickUpDate { get; set; }
        public DateTime DropOffDate { get; set; }
        public string PickUpTime { get; set; }  
        public string DropOffTime { get; set; }
    }



}

