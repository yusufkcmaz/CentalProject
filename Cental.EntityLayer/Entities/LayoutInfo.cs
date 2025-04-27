using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cental.EntityLayer.Entities
{
    public class LayoutInfo
    {

        //Topbar
        public int LayoutInfoId { get; set; }

        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }

        public string AboutDescription { get; set; }

        public string WeekdayHours { get; set; }
        public string SaturdayHours { get; set; }
       
        public string FacebookUrl { get; set; }
        public string TwitterUrl { get; set; }
        public string InstagramUrl { get; set; }
        public string LinkedinUrl { get; set; }
    }
}
